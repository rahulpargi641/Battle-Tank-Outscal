using UnityEngine;

public class TankController
{
    private TankModel tankModel;

    private TankView tankView;

    private Rigidbody rigidbody;

    public TankController(TankModel tankModel, TankView tankView)
    {
        this.tankModel = tankModel;
        this.tankView = GameObject.Instantiate<TankView>(tankView);
        rigidbody = this.tankView.rigidbody;

        this.tankModel.tankController = this;
        this.tankView.tankController = this;
    }

    public void MoveTank(float yMovementInput)
    {
        //float movementSpeed = tankModel.movementSpeed;
        //rigidbody.velocity = tankView.transform.forward * yMovementInput * movementSpeed * Time.deltaTime;

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
