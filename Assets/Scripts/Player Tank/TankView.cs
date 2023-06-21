using UnityEngine;

public class TankView : MonoBehaviour
{   
    public TankController tankController { private get; set; }
    public Rigidbody rigidbody { get; private set; }

    private float yMovementInput;
    private float yawRotationInput;

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

        ProcessTankMovement();
    }

    private void ReadMovementInput()
    {
        yMovementInput = Input.GetAxis("Vertical");
        yawRotationInput = Input.GetAxis("Horizontal");
    }

    private void ProcessTankMovement()
    {
        if (yMovementInput != 0)
        {
            tankController.MoveTank(yMovementInput);
        }

        if (yawRotationInput != 0)
        {
            tankController.RotateTank(yawRotationInput);
        }
    }
}
