using UnityEngine;

public class EnemyTankView : MonoBehaviour
{
    public EnemyTankController EnemyTankController { private get; set; }

    Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

}
