using System.Collections;
using UnityEngine;

public class PlayerTankView: MonoBehaviour
{
    [SerializeField] Wheel[] leftWheels;
    [SerializeField] Wheel[] rightWheels;
    [SerializeField] GameObject turret;
    public Wheel[] LeftWheels => leftWheels;
    public Wheel[] RightWheels => rightWheels;
    public GameObject Turret => turret;
    public PlayerTankController PlayerTankController { private get; set; }
    public Rigidbody Rigidbody { get; private set; }

    private string movementAxisName;
    private string turnAxisName;

    private float moveInput;
    private float turnInput;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Rigidbody.isKinematic = false;
        moveInput = 0f;
        turnInput = 0f;
    }

    private void Start()
    {
        gameObject.SetActive(true);

        movementAxisName = "Vertical";
        turnAxisName = "Horizontal";

        AudioService.Instance.PlayEngineSound(0.1f, 0.1f); // plays engine idle sound at the start
    }

    private void Update()
    {
        CameraService.Instance.AddTarget(transform); // camera focuses on the player

        ReadMovementInput();

        PlayVaryingPitchEngineSound();

        PlayerTankController.TurnWheels(moveInput, turnInput);

        ProcessTurretSpinning();
    }

    private void FixedUpdate()
    {
        ProcessTankMovement();
    }

    private void OnDisable()
    {
        Rigidbody.isKinematic = true;
    }

    private void PlayVaryingPitchEngineSound()
    { 
        AudioService.Instance.PlayEngineSound(moveInput, turnInput);
    }

    private void ReadMovementInput()
    {
        moveInput = Input.GetAxis(movementAxisName);
        turnInput = Input.GetAxis(turnAxisName);
    }

    private void ProcessTankMovement()
    {
        if (moveInput != 0)
            PlayerTankController.MoveTank(moveInput);

        if (turnInput != 0)
           PlayerTankController.TurnTank(turnInput);
    }

    private void ProcessTurretSpinning()
    {
        if(Input.GetKey(KeyCode.Q))
            PlayerTankController.SpinTurretLeft();

        if (Input.GetKey(KeyCode.E))
            PlayerTankController.SpinTurretRight();
    }
}
