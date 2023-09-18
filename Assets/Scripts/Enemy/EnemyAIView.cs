using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIView : MonoBehaviour
{
    public EnemyTankController Controller { private get; set; }
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform fireTransform;
    [SerializeField] Transform[] patrolPoints;
    public Transform[] PatrolPoints => patrolPoints;

    public Transform FireTransform => fireTransform;

    NavMeshAgent navMeshAgent;
    Animator animator;
    State currentState;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    internal void OnEnable()
    {
        gameObject.SetActive(true);
    }

    private void Start()
    {
        currentState = new Idle(this, navMeshAgent, animator, playerTransform);
    }

    void Update()
    {
        if (currentState != null)
            currentState = currentState.Process();
        else
            Debug.Log("Current state null");
    }

    public void OnDisable()
    {
        gameObject.SetActive(false);
    }
}
