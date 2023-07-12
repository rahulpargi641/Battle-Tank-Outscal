using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : State
{
    public Idle(GameObject npc, NavMeshAgent navMeshAgent, Animator animator, Transform playerTransform) : base(npc, navMeshAgent, animator, playerTransform)
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

        if (Random.Range(0,100) < 10)
        {
            nextState = new Patrol(npc, navMeshAgent, animator, playerTransform);
            stage = EStage.Exit;
        }
    }

    public override void Exit()
    {
        //animator.ResetTrigger("IsIdle");
        base.Exit();
    }
}
