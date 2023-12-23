using UnityEngine;
using UnityEngine.AI;

public class EnemyAIView : MonoBehaviour
{
    public Transform[] PatrolPoints => patrolPoints;
    public Transform FireTransform => fireTransform;
    public EnemyTankController Controller { private get; set; }

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private Transform[] patrolPoints;
  
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private EnemyState currentState;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        gameObject.SetActive(true);
    }

    private void Start()
    {
        currentState = new Idle(this, navMeshAgent, animator, playerTransform);
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState = currentState.Process();
        }
        else
        {
            Debug.Log("Current state is null");
        }
    }

    private void OnDisable()
    {
        gameObject.SetActive(false);
    }
}
