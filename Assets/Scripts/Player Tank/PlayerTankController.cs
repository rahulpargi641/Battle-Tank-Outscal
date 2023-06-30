using UnityEngine;

public class PlayerTankController 
{
    private PlayerTankModel tankModel;
    private PlayerTankView tankView;

    private Rigidbody rigidbody;
    private AudioSource movementAudio;

    public PlayerTankController(PlayerTankModel tankModel, PlayerTankView tankView)
    {
        this.tankModel = tankModel;
        this.tankView = tankView;
        rigidbody = this.tankView.GetComponent<Rigidbody>();
        movementAudio = this.tankView.m_MovementAudio;

        this.tankModel.playerTankController = this;
        this.tankView.playerTankController = this;
    }

    public void MoveTank(float yMovementInput)
    {
        float movementSpeed = tankModel.movementSpeed;
        rigidbody.velocity = tankView.transform.forward * yMovementInput * movementSpeed;
    }
    public void RotateTank(float yawRotatationInput)
    {
        float rotateSpeed = tankModel.rotationSpeed;
        Vector3 rotationAngle = new Vector3(0f, yawRotatationInput * rotateSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(rotationAngle * Time.deltaTime);
        rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
    }
}
