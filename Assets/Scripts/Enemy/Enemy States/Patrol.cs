using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : State
{
    int currentIndex = -1;

    public Patrol(GameObject npc, NavMeshAgent navMeshAgent, Animator animator, Transform playerTransform) : base(npc, navMeshAgent, animator, playerTransform)
    {
        state = EState.Patrol;
        navMeshAgent.speed = 4;
        navMeshAgent.isStopped = false;
    }

    public override void Enter()
    {
        currentIndex = 0;
        //animator.SetTrigger("IsWalking");
        base.Enter();
    }
    public override void Update()
    {
        //base.Update();
        if (navMeshAgent.remainingDistance < 1)
        {
            if (currentIndex >= EnvironmentService.Instance.PatrolPoints.Count - 1)
                currentIndex = 0;
            else
                currentIndex++;

            Vector3 patrolPoint = EnvironmentService.Instance.PatrolPoints[currentIndex].transform.position;
            navMeshAgent.SetDestination(patrolPoint); 
        }
    }

    public override void Exit()
    {
        //animator.ResetTrigger("IsWalking");
        base.Exit();
    }
}
