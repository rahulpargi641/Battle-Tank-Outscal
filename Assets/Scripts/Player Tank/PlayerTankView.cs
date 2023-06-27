using UnityEngine;

public class PlayerTankView: MonoBehaviour
{   
    public PlayerTankController playerTankController { private get; set; }
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
            playerTankController.MoveTank(yMovementInput);
        }

        if (yawRotationInput != 0)
        {
            playerTankController.RotateTank(yawRotationInput);
        }
    }
}
