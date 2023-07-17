using UnityEngine;

public class PlayerTankView: MonoBehaviour
{   
    public PlayerTankController PlayerTankController { private get; set; }
    public Rigidbody Rigidbody { get; private set; }

    private string movementAxisName;
    private string turnAxisName;

    private float turnSpeed = 60; // remove it
    private float moveSpeed = 8f; // remove it

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
        ReadMovementInput();
        PlayVaryingPtichEngineSound();
    }

    private void OnDisable()
    {
        Rigidbody.isKinematic = true;
    }

    private void PlayVaryingPtichEngineSound()
    { 
        AudioService.Instance.PlayEngineSound(movementInputValue, turnInputValue);
    }

    private void FixedUpdate()
    {
        ProcessTankMovement();
        //playerTankController.MoveTank(m_MovementInputValue);
        ////Move();
        //playerTankController.Turn(m_TurnInputValue);
        ////Turn();
    }

    private void ReadMovementInput()
    {
        movementInputValue = Input.GetAxis(movementAxisName);
        turnInputValue = Input.GetAxis(turnAxisName);
    }

    private void ProcessTankMovement()
    {
        //if (m_MovementInputValue != 0)
        //    playerMainTankController.MoveTank(m_MovementInputValue);

        //if (m_TurnInputValue != 0)
        //    playerMainTankController.TurnTank(m_TurnInputValue);

        Turn();
        Move();

    }

    private void Turn()
    {
        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        Rigidbody.MoveRotation(Rigidbody.rotation * turnRotation);
    }

    //Done Refactoring
    private void Move()
    {
        Vector3 movement = transform.forward * movementInputValue * moveSpeed * Time.deltaTime;
        Rigidbody.MovePosition(Rigidbody.position + movement); // moves to the absolute position you give it
    }
}
