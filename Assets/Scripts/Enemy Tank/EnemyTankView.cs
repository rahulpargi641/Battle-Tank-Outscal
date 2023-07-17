using UnityEngine;
using UnityEngine.AI;

public class EnemyTankView : MonoBehaviour
{
    public EnemyTankController EnemyTankController { private get; set; }

    Rigidbody rigidbody;

    NavMeshAgent navMeshAgent;
    [SerializeField] LayerMask groundLayer, playerLayer;
    Vector3 randomDestinationPos;
    bool isWalkPointSet;
    float range = 200f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Patrol();
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
}
