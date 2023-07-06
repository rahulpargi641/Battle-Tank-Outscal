using UnityEngine;

public class PlayerTankController
{
    private PlayerTankModel playerTankModel;
    private PlayerTankView playerTankView;

    private ShootingController shootingController;

    private Rigidbody rigidbody;
    private float moveSpeed;

    private bool m_Fired;

    public PlayerTankController(PlayerTankModel playerTankModel, PlayerTankView playerTankView)
    {
        this.playerTankModel = playerTankModel;
        this.playerTankView = playerTankView;

        playerTankModel.PlayerTankController = this;
        playerTankView.playerMainTankController = this;

        shootingController = new ShootingController();

        InitializeMemberVariables();
    }

    private void InitializeMemberVariables()
    {
        rigidbody = playerTankView.Rigidbody;
        moveSpeed = playerTankModel.MoveSpeed;
    }

    public void MoveTank(float movementInput)
    {
        Vector3 movement = playerTankView.transform.forward * movementInput * moveSpeed * Time.deltaTime;
        rigidbody.MovePosition(rigidbody.position + movement); // moves to the absolute position you give it
    }

    public void TurnTank(float turnInputValue)
    {
        float turn = turnInputValue * playerTankModel.TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rigidbody.MoveRotation(rigidbody.rotation * turnRotation);
    }


    public void Update()
    {

    }
    //public void Fire()
    //{
    //    m_Fired = true;

    //    Rigidbody shellInstance = GameObject.Instantiate(playerTankView.m_Shell, playerTankView.m_FireTransform.position, playerTankView.m_FireTransform.rotation) as Rigidbody;
    //    shellInstance.velocity = playerTankView.m_CurrentLaunchForce * playerTankView.m_FireTransform.forward;

    //    playerTankView.m_ShootingAudio.clip = playerTankView.m_FireClip;
    //    playerTankView.m_ShootingAudio.Play();

    //    m_CurrentLaunchForce = m_MinLaunchForce;
    //}

  

    //public void RotateTank(float yawRotatationInput)
    //{
    //    float rotateSpeed = tankModel.turnSpeed;
    //    Vector3 rotationAngle = new Vector3(0f, yawRotatationInput * rotateSpeed, 0f);
    //    Quaternion deltaRotation = Quaternion.Euler(rotationAngle * Time.deltaTime);
    //    rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
    //}
}
