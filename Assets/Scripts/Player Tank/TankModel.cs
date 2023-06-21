using UnityEngine;

public class TankModel
{
    public TankController tankController { private get;  set; }
    TankType tankType { get; }
    public float movementSpeed { get; }
    public float movementSpeedLive { get { return tankScriptableObject.MovementSpeed; } }
    public float rotationSpeed { get; }
    public int damage { get; }

    TankScriptableObject tankScriptableObject;
    public TankModel(TankScriptableObject tankScriptableObject)
    {
        this.tankScriptableObject = tankScriptableObject;
        this.tankType = tankScriptableObject.TankType;
        this.movementSpeed = tankScriptableObject.MovementSpeed;
        this.rotationSpeed = tankScriptableObject.RotationSpeed;
        this.damage = tankScriptableObject.Damage;
    }
}
