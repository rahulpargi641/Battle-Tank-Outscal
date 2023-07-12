using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EState
{ Idle, Patrol, Pursue, Attack };

public enum EStage
{
    Enter, Update, Exit
};

public class State
{
    public EState state;
    protected EStage stage;
    protected GameObject npc;
    protected NavMeshAgent navMeshAgent;
    protected Animator animator;
    protected Transform playerTransform;
    protected State nextState;

    float visDist = 10.0f;
    float visAngle = 30.0f;
    float shootDist = 7.0f;

    public State(GameObject npc, NavMeshAgent navMeshAgent, Animator animator, Transform playerTransform)
    {
        this.npc = npc;
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
}
