using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class Pursue : EnemyState
{
    private const float AttackStoppingDistance = 1.5f;
    private const int CameraRemovalDelayMilliseconds = 6000;

    public Pursue(EnemyAIView enemyAIView, NavMeshAgent navMeshAgent, Animator animator, Transform playerTransform)
        : base(enemyAIView, navMeshAgent, animator, playerTransform)
    {
        state = EState.Pursue;

        navMeshAgent.speed = 5f;
        navMeshAgent.isStopped = false;
    }

    public override void Enter()
    {
        CameraService.Instance.AddTarget(enemyAIView.gameObject.transform);
        base.Enter();
    }

    public override void Update()
    {
        UpdatePathToPlayer();

        if (IsAttackingPlayer())
        {
            TransitionToState<Attack>();
        }
        else if (ShouldReturnToPatrol())
        {
            _ = RemoveCameraAsync();
            TransitionToState<Patrol>();
        }
    }

    private void UpdatePathToPlayer()
    {
        //navMeshAgent.SetDestination(playerTransform.position);
        UpdatePath(playerTransform.position);
    }

    private bool IsAttackingPlayer()
    {
        return CanAttackPlayer();
    }

    private bool ShouldReturnToPatrol()
    {
        return !CanSeePlayer() || (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= AttackStoppingDistance);
    }

    private async Task RemoveCameraAsync()
    {
        await Task.Delay(CameraRemovalDelayMilliseconds);
        CameraService.Instance.RemoveTarget(enemyAIView.gameObject.transform);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
