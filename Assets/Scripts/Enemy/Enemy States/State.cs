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
    protected GameObject npcGO;
    protected NavMeshAgent navMeshAgent;
    protected Animator animator;
    protected Transform playerTransform;
    protected State nextState;

    float visibleDist = 20.0f; // 10f
    float visibleAngle = 90.0f; // 30f
    float shootDist = 15.0f; // 7f

    public State(GameObject npcGO, NavMeshAgent navMeshAgent, Animator animator, Transform playerTransform)
    {
        this.npcGO = npcGO;
        this.navMeshAgent = navMeshAgent;
        this.animator = animator;
        this.playerTransform = playerTransform;
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

    public bool CanSeePlayer()
    {
        Vector3 playerDirection = playerTransform.position - npcGO.transform.position;
        float facingAngle = Vector3.Angle(playerDirection, npcGO.transform.forward);

        if (playerDirection.magnitude < visibleDist && facingAngle < visibleAngle)
            return true;
        else
            return false;
    }

    public bool CanAttackPlayer()
    {
        Vector3 playerDirection = playerTransform.position - npcGO.transform.position;
        if (playerDirection.magnitude < shootDist)
            return true;
        else
            return false;
    }
}
