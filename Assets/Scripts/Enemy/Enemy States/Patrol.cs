using UnityEngine;
using UnityEngine.AI;

public class Patrol : State
{
    int currentIndex = -1;

    public Patrol(GameObject npc, NavMeshAgent navMeshAgent, Animator animator, Transform playerTransform) 
        : base(npc, navMeshAgent, animator, playerTransform)
    {
        state = EState.Patrol;
        navMeshAgent.speed = 2;
        navMeshAgent.isStopped = false;
    }

    public override void Enter()
    {
        //currentIndex = 0;

        float lastDist = Mathf.Infinity;
        for(int i=0; i < EnvironmentService.Instance.PatrolPoints.Count; i++)
        {
            Transform currPatrolPoint = EnvironmentService.Instance.PatrolPoints[i];
            float distance = Vector3.Distance(npcGO.transform.position, currPatrolPoint.position);
            if(distance < lastDist)
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
            if (currentIndex >= EnvironmentService.Instance.PatrolPoints.Count - 1)
                currentIndex = 0;

            Vector3 patrolPoint = EnvironmentService.Instance.PatrolPoints[currentIndex].position;
            //navMeshAgent.SetDestination(patrolPoint);
            UpdatePath(patrolPoint);
            currentIndex++;
        }

        if (CanSeePlayer())
        {
            nextState = new Pursue(npcGO, navMeshAgent, animator, playerTransform);
            stage = EStage.Exit;
        }
    }

    public override void Exit()
    {
        //animator.ResetTrigger("IsWalking");
        base.Exit();
    }
}
