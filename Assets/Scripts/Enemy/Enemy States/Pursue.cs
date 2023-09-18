using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class Pursue : State
{ 
    public Pursue(EnemyAIView enemyAIView, NavMeshAgent navMeshAgent, Animator animator, Transform playerTransform)
        : base(enemyAIView, navMeshAgent, animator, playerTransform)
    {
        state = EState.Pursue;
        navMeshAgent.speed = 5f;
        navMeshAgent.isStopped = false;
    }

    public override void Enter()
    {
        //animator.SetTrigger("IsRunning");
        CameraService.Instance.AddTarget(enemyAIView.gameObject.transform);
        base.Enter();
    }

    public override void Update()
    {
        //navMeshAgent.SetDestination(playerTransform.position);
        UpdatePath(playerTransform.position);
        if (navMeshAgent.hasPath) // means following the player       
        {
            if (CanAttackPlayer())
            {
                nextState = new Attack(enemyAIView, navMeshAgent, animator, playerTransform);
                stage = EStage.Exit;
            }
            else if (!CanSeePlayer() || !navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                _ = RemoveCameraAsync();
                nextState = new Patrol(enemyAIView, navMeshAgent, animator, playerTransform);
                stage = EStage.Exit;
            }
        }
    }

    private async Task RemoveCameraAsync()
    {
        await Task.Delay(6000);
        CameraService.Instance.RemoveTarget(enemyAIView.gameObject.transform);
    }

    public override void Exit()
    {
        //animator.ResetTrigger("IsRunning");

        base.Exit();
    }
}
