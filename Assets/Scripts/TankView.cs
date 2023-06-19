using UnityEngine;

public class TankView : MonoBehaviour
{    public TankController tankController { private get; set; }
    public Rigidbody rigidbody { get; private set; }

    private float movement;
    private float rotation;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        GameObject camera = GameObject.Find("CameraRig");
        camera.transform.SetParent(gameObject.transform);
    }

    private void Update()
    {
        ReadMovementInput();

        if (movement != 0)
        {
            tankController.MoveTank(movement);
        }

        if (rotation != 0)
        {
            tankController.RotateTank(rotation);
        }
    }

    private void ReadMovementInput()
    {
        movement = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");
    }
}
