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
        Vector3 movement = playerTankView.transform.forward * movementInput * playerTankModel.MoveSpeed * Time.fixedDeltaTime;
        playerTankView.Rigidbody.MovePosition(playerTankView.Rigidbody.position + movement); // moves to the absolute position you give it
    }

    public void TurnTank(float turnInput)
    {
        float turn = turnInput * playerTankModel.TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        playerTankView.Rigidbody.MoveRotation(playerTankView.Rigidbody.rotation * turnRotation);
    }

    public void TurnWheels(float movementInput, float turnInput)
    {
        float wheelRotation = movementInput * playerTankModel.WheelRotationSpeed * Time.deltaTime;

        // Move the left wheels
        foreach(Wheel wheel in playerTankView.LeftWheels)
        {
            if(wheel)
                wheel.transform.Rotate(wheelRotation - turnInput * playerTankModel.WheelRotationSpeed * Time.deltaTime, 0.0f, 0.0f); // rotate in x dir
        }

        // Move the right wheels
        foreach (Wheel wheel in playerTankView.RightWheels)
        {
            if (wheel)
                wheel.transform.Rotate(wheelRotation + turnInput * playerTankModel.WheelRotationSpeed * Time.deltaTime, 0.0f, 0.0f); // rotate in x dir
        }
    }

    public void SpinTurretLeft()
    {
        playerTankView.Turret.transform.Rotate(Vector3.up, playerTankModel.TurretSpinSpeed * Time.deltaTime);
    }

    public void SpinTurretRight()
    {
        playerTankView.Turret.transform.Rotate(Vector3.up, -playerTankModel.TurretSpinSpeed * Time.deltaTime);
    }

    //public void RotateTank(float yawRotatationInput)
    //{
    //    float rotateSpeed = tankModel.turnSpeed;
    //    Vector3 rotationAngle = new Vector3(0f, yawRotatationInput * rotateSpeed, 0f);
    //    Quaternion deltaRotation = Quaternion.Euler(rotationAngle * Time.deltaTime);
    //    rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
    //}
}
