using System;
using UnityEngine;
using UnityEngine.AI;

public class Idle : EnemyState
{
    private const float PatrolChance = 10f;

    public Idle(EnemyAIView enemyAIView, NavMeshAgent navMeshAgent, Animator animator, Transform playerTransform)
        : base(enemyAIView, navMeshAgent, animator, playerTransform)
    {
        state = EState.Idle;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (CanSeePlayer())
        {
            TransitionToState<Pursue>();
        }
        else if (ShouldStartPatrol())
        {
            TransitionToState<Patrol>();
        }
    }

    private bool ShouldStartPatrol()
    {
        return UnityEngine.Random.Range(0, 100) < PatrolChance;
    }

    public override void Exit()
    {
        base.Exit();
    }
}
