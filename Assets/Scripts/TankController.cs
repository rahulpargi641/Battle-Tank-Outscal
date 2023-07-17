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

    public void MoveTank(float verticalMovement)
    {
        float movementSpeed = tankModel.movementSpeed;
        rigidbody.velocity = tankView.transform.forward * verticalMovement * movementSpeed;
    }
    public void RotateTank(float yawRotatation)
    {
        float rotateSpeed = tankModel.rotationSpeed;
        Vector3 vector = new Vector3(0f, yawRotatation * rotateSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
        rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
    }
}
