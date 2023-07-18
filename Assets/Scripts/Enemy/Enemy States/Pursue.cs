using UnityEngine;
using UnityEngine.AI;

public class Pursue : State
{ 
    public Pursue(GameObject npcGO, NavMeshAgent navMeshAgent, Animator animator, Transform playerTransform)
        : base(npcGO, navMeshAgent, animator, playerTransform)
    {
        state = EState.Pursue;
        navMeshAgent.speed = 5f;
        navMeshAgent.isStopped = false;
    }

    public override void Enter()
    {
        //animator.SetTrigger("IsRunning");
        base.Enter();
    }

    public override void Update()
    {
        navMeshAgent.SetDestination(playerTransform.position);
        if (navMeshAgent.hasPath) // means following the player       
        {
            if (CanAttackPlayer())
            {
                nextState = new Attack(npcGO, navMeshAgent, animator, playerTransform);
                stage = EStage.Exit;
            }
            else if (!CanSeePlayer() || !navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                nextState = new Patrol(npcGO, navMeshAgent, animator, playerTransform);
                stage = EStage.Exit;
            }
        }
    }

    public override void Exit()
    {
        //animator.ResetTrigger("IsRunning");
        base.Exit();
    }
}
