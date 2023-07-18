using UnityEngine;
using UnityEngine.AI;

public class Idle : State
{
    public Idle(GameObject npcGO, NavMeshAgent navMeshAgent, Animator animator, Transform playerTransform) 
        : base(npcGO, navMeshAgent, animator, playerTransform)
    {
        state = EState.Idle;
    }

    public override void Enter()
    {
        //animator.SetTrigger("IsIdle");
        base.Enter();
    }

    public override void Update()
    {
        //base.Update();
        if(CanSeePlayer())
        {
            nextState = new Pursue(npcGO, navMeshAgent, animator, playerTransform);
            stage = EStage.Exit;
        }
        else if (Random.Range(0,100) < 10)
        {
            nextState = new Patrol(npcGO, navMeshAgent, animator, playerTransform);
            stage = EStage.Exit;
        }
    }

    public override void Exit()
    {
        //animator.ResetTrigger("IsIdle");
        base.Exit();
    }
}
