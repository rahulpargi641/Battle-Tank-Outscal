using UnityEngine;

public class PlayerTankController
{
    private PlayerTankModel playerTankModel;
    private PlayerTankView playerTankView;

    public PlayerTankController(PlayerTankModel playerTankModel, PlayerTankView playerTankView)
    {
        this.playerTankModel = playerTankModel;
        this.playerTankView = playerTankView;

        playerTankModel.PlayerTankController = this;
        playerTankView.PlayerTankController = this;
    }

    public void MoveTank(float movementInput)
    {

        Vector3 movement = playerTankView.transform.forward * movementInput * playerTankModel.MoveSpeed * Time.deltaTime;
        playerTankView.Rigidbody.MovePosition(playerTankView.Rigidbody.position + movement); // moves to the absolute position you give it
    }

    public void TurnTank(float turnInputValue)
    {
        float turn = turnInputValue * playerTankModel.TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        playerTankView.Rigidbody.MoveRotation(playerTankView.Rigidbody.rotation * turnRotation);
    }

    //public void RotateTank(float yawRotatationInput)
    //{
    //    float rotateSpeed = tankModel.turnSpeed;
    //    Vector3 rotationAngle = new Vector3(0f, yawRotatationInput * rotateSpeed, 0f);
    //    Quaternion deltaRotation = Quaternion.Euler(rotationAngle * Time.deltaTime);
    //    rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
    //}
}
