using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIView : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    NavMeshAgent agent;
    Animator anim;
    State currentState;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //anim = GetComponent<Animator>();
        currentState = new Idle(gameObject, agent, anim, playerTransform);
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Process(); 
    }
}
