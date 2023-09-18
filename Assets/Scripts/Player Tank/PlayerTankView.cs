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

    private float movementInputValue;
    private float turnInputValue;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Rigidbody.isKinematic = false;
        movementInputValue = 0f;
        turnInputValue = 0f;
    }

    private void Start()
    {
        movementAxisName = "Vertical";
        turnAxisName = "Horizontal";
    }

    private void Update()
    {
        CameraService.Instance.AddTarget(transform);

        ReadMovementInput();

        PlayVaryingPtichEngineSound();

        PlayerTankController.TurnWheels(movementInputValue, turnInputValue);

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

    private void PlayVaryingPtichEngineSound()
    { 
        AudioService.Instance.PlayEngineSound(movementInputValue, turnInputValue);
    }

    private void ReadMovementInput()
    {
        movementInputValue = Input.GetAxis(movementAxisName);
        turnInputValue = Input.GetAxis(turnAxisName);
    }

    private void ProcessTankMovement()
    {
        if (movementInputValue != 0)
            PlayerTankController.MoveTank(movementInputValue);

        if (turnInputValue != 0)
           PlayerTankController.TurnTank(turnInputValue);
    }

    private void ProcessTurretSpinning()
    {
        if(Input.GetKey(KeyCode.Q))
            PlayerTankController.SpinTurretLeft();

        if (Input.GetKey(KeyCode.E))
            PlayerTankController.SpinTurretRight();
    }
}
