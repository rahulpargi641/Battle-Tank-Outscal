using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentService : MonoSingletonGeneric<EnvironmentService> // yet to implement
{
   [SerializeField] List<Transform> patrolPoints; // partrol points parent transform for each enemy tank

    public List<Transform> PatrolPoints => patrolPoints; 
}
