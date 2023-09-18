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

public class State
{
    public EState state;
    protected EStage stage;
    protected EnemyAIView enemyAIView;
    protected NavMeshAgent navMeshAgent;

    protected Animator animator;
    protected Transform playerTransform;
    protected State nextState;


    float visibleDist = 17.0f; // 10f
    float visibleAngle = 90.0f; // 30f
    float shootDist = 14.0f; // 7f

    private float pathUpdateDelay = 0.2f;
    private float pathUpdateDeadline;


    public State(EnemyAIView enemyAIView, NavMeshAgent navMeshAgent, Animator animator, Transform playerTransform)
    {
        this.enemyAIView = enemyAIView;
        this.navMeshAgent = navMeshAgent;
        this.animator = animator;
        this.playerTransform = playerTransform;

        EventService.Instance.OnEnemyDeathAction += EnemyDestroyed;
    }

    public virtual void Enter() { stage = EStage.Update; }
    public virtual void Update() { stage = EStage.Update; }
    public virtual void Exit() { stage = EStage.Exit; }

    // get run from outside and progress state through each of the different stages
    public State Process()
    {
        if (stage == EStage.Enter) Enter();
        if (stage == EStage.Update) Update();
        if(stage == EStage.Exit)
        {
            Exit();
            return nextState;
        }
        return this; // we keep returning the same state
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

        if (playerDirection.magnitude < visibleDist && facingAngle < visibleAngle)
            return true;
        else
            return false;
    }

    public bool CanAttackPlayer()
    {
        Vector3 playerDirection = playerTransform.position - enemyAIView.transform.position;
        if (playerDirection.magnitude < shootDist)
            return true;
        else
            return false;
    }

    internal void Initialize()
    {
        throw new NotImplementedException();
    }
    protected virtual void EnemyDestroyed()
    {
        //nextState = null;
        Debug.Log("Enemy Destroyed");
    }
}
