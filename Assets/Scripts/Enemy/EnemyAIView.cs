using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIView : MonoBehaviour
{
    public EnemyTankController Controller { get; set; }
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform fireTransform;

    public Transform FireTransform => fireTransform;

    NavMeshAgent navMeshAgent;
    Animator animator;
    State currentState;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //anim = GetComponent<Animator>();
        currentState = new Idle(gameObject, navMeshAgent, animator, playerTransform);
    }

    internal void Enabled()
    {
        throw new NotImplementedException();
    }

    internal void Disable()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Process();
    }
}
