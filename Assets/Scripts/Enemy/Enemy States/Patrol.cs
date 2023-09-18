using UnityEngine;
using UnityEngine.AI;

public class Patrol : State
{
    int currentIndex = 0;
    int nPatrolPoints;

    public Patrol(EnemyAIView enemyAIView, NavMeshAgent navMeshAgent, Animator animator, Transform playerTransform) 
        : base(enemyAIView, navMeshAgent, animator, playerTransform)
    {
        state = EState.Patrol;
        navMeshAgent.speed = 2;
        navMeshAgent.isStopped = false;
        nPatrolPoints = enemyAIView.PatrolPoints.Length;
    }

    public override void Enter()
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
        //animator.SetTrigger("IsWalking");
        base.Enter();
    }

    public override void Update()
    {
        //base.Update();
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            if (currentIndex >= nPatrolPoints)
                currentIndex = 0;

            Vector3 patrolPoint = enemyAIView.PatrolPoints[currentIndex].position;
            UpdatePath(patrolPoint);
            currentIndex++;
        }

        if (CanSeePlayer())
        {
            nextState = new Pursue(enemyAIView, navMeshAgent, animator, playerTransform);
            stage = EStage.Exit;
        }
    }

    public override void Exit()
    {
        //animator.ResetTrigger("IsWalking");
        base.Exit();
    }
}
