using UnityEngine;
using UnityEngine.AI;

public class EnemyTankView : MonoBehaviour
{
    public EnemyTankController EnemyTankController { private get; set; }

    Rigidbody rigidbody;

    NavMeshAgent navMeshAgent;
    private Transform target;
    private float shootingDistance;
    [SerializeField] LayerMask groundLayer, playerLayer;
    Vector3 randomDestinationPos;
    bool isWalkPointSet;
    float range = 200f;

    public float pathUpdateDelay = 0.2f;
    float pathUpdateDeadline;

    internal void Disable()
    {
        gameObject.SetActive(false);
    }

    internal void Enabled()
    {
        throw new System.NotImplementedException();
    }

    bool playerFound = false;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        shootingDistance = navMeshAgent.stoppingDistance;
    }

    private void Update()
    {
        if(!playerFound)
        Patrol();

        if (target != null)
        {
            bool inRange = Vector3.Distance(transform.position, target.position) <= shootingDistance;

            if(inRange)
            {
                LookAtTarget();
            }
            else
            {
                UpdatePath();
            }
        }
        else
        {
            

        }
    }

    private void UpdatePath()
    {
        if(Time.time >= pathUpdateDeadline)
        {
            Debug.Log("Updating path");
            pathUpdateDeadline = Time.time + pathUpdateDelay;
            navMeshAgent.SetDestination(target.position);
        }
    }

    private void LookAtTarget()
    {
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }

    void Patrol()
    {
        Debug.Log("Value of setdestination" + isWalkPointSet);
        if (!isWalkPointSet) SetRandomDestinationPosition();
        if (isWalkPointSet) navMeshAgent.SetDestination(randomDestinationPos);
        if (Vector3.Distance(transform.position, randomDestinationPos) < 5) isWalkPointSet = false;
    }

    void SetRandomDestinationPosition()
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);
        randomDestinationPos = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        if (Physics.Raycast(randomDestinationPos, Vector3.down, groundLayer))
        { isWalkPointSet = true; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerTankView>())
        {
            playerFound = true;
            target = other.transform;
            Debug.Log("Found Player");
        }
    }
}
