using UnityEngine;
using UnityEngine.AI;

public class Patrol : EnemyState
{
    private int currentIndex = 0;
    private int nPatrolPoints;

    public Patrol(EnemyAIView enemyAIView, NavMeshAgent navMeshAgent, Animator animator, Transform playerTransform)
        : base(enemyAIView, navMeshAgent, animator, playerTransform)
    {
        state = EState.Patrol;
        InitializePatrolParameters();
    }

    private void InitializePatrolParameters()
    {
        navMeshAgent.speed = 2;
        navMeshAgent.isStopped = false;
        nPatrolPoints = enemyAIView.PatrolPoints.Length;
    }

    public override void Enter()
    {
        DetermineClosestPatrolPoint();
        base.Enter();
    }

    private void DetermineClosestPatrolPoint()
    {
        float lastDist = Mathf.Infinity;
        for (int i = 0; i < nPatrolPoints; i++)
        {
            Transform currPatrolPoint = enemyAIView.PatrolPoints[i];
            float distance = Vector3.Distance(enemyAIView.transform.position, currPatrolPoint.position);
            if (distance < lastDist)
            {
                currentIndex = i;
                lastDist = distance;
            }
        }
    }

    public override void Update()
    {
        base.Update();

        HandlePatrolMovement();

        if (CanSeePlayer())
        {
            TransitionToState<Pursue>();
        }
    }

    private void HandlePatrolMovement()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            UpdateCurrentPatrolPoint();
        }
    }

    private void UpdateCurrentPatrolPoint()
    {
        if (currentIndex >= nPatrolPoints)
            currentIndex = 0;

        Vector3 patrolPoint = enemyAIView.PatrolPoints[currentIndex].position;
        UpdatePath(patrolPoint);
        currentIndex++;
    }

    public override void Exit()
    {
        base.Exit();
    }
}
