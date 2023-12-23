using System;
using UnityEngine;
using UnityEngine.AI;

public enum EState
{
    Idle, Patrol, Pursue, Attack
};

public enum EStage
{
    Enter, Update, Exit
};

public class EnemyState
{
    protected EState state;
    protected EStage stage;
    protected EnemyAIView enemyAIView;
    protected NavMeshAgent navMeshAgent;
    protected Animator animator;
    protected Transform playerTransform;
    protected EnemyState nextState;

    private float visibleDist = 17.0f;
    private float visibleAngle = 90.0f;
    private float shootDist = 14.0f;
    private float pathUpdateDelay = 0.2f;
    private float pathUpdateDeadline;

    public EnemyState(EnemyAIView enemyAIView, NavMeshAgent navMeshAgent, Animator animator, Transform playerTransform)
    {
        this.enemyAIView = enemyAIView ?? throw new ArgumentNullException(nameof(enemyAIView));
        this.navMeshAgent = navMeshAgent ?? throw new ArgumentNullException(nameof(navMeshAgent));
        this.animator = animator ?? throw new ArgumentNullException(nameof(animator));
        this.playerTransform = playerTransform ?? throw new ArgumentNullException(nameof(playerTransform));

        EventService.Instance.OnEnemyDeathAction += EnemyDestroyed;
    }

    public virtual void Enter() { stage = EStage.Update; }
    public virtual void Update() { stage = EStage.Update; }
    public virtual void Exit() { stage = EStage.Exit; }

    public EnemyState Process()
    {
        ProcessStage();
        return stage == EStage.Exit ? nextState : this;
    }

    private void ProcessStage()
    {
        if (stage == EStage.Enter) Enter();
        if (stage == EStage.Update) Update();
        if (stage == EStage.Exit) Exit();
    }

    protected void TransitionToState<T>() where T : EnemyState
    {
        nextState = Activator.CreateInstance(typeof(T), enemyAIView, navMeshAgent, animator, playerTransform) as T;
        stage = EStage.Exit;
    }

    protected void UpdatePath(Vector3 targetPoint)
    {
        if (Time.time >= pathUpdateDeadline)
        {
            Debug.Log("Updating path");
            pathUpdateDeadline = Time.time + pathUpdateDelay;
            navMeshAgent.SetDestination(targetPoint);
        }
    }

    public bool CanSeePlayer()
    {
        Vector3 playerDirection = playerTransform.position - enemyAIView.transform.position;
        float facingAngle = Vector3.Angle(playerDirection, enemyAIView.transform.forward);

        return playerDirection.magnitude < visibleDist && facingAngle < visibleAngle;
    }

    public bool CanAttackPlayer()
    {
        Vector3 playerDirection = playerTransform.position - enemyAIView.transform.position;
        return playerDirection.magnitude < shootDist;
    }

    protected virtual void EnemyDestroyed()
    {
        Debug.Log("Enemy Destroyed");
        // gets implemented in the attack state to stop firing when destroyed
    }
}
