using UnityEngine;

public class PlayerTankModel :TankModel
{
    public PlayerTankController playerTankController { private get;  set; }
    //TankType tankType { get; }
    //public float movementSpeed { get; }
    //public float movementSpeedLive { get { return tankScriptableObject.MovementSpeed; } }
    //public float rotationSpeed { get; }
    //public int damage { get; }

    TankScriptableObject playerTankScriptableObject;
    public PlayerTankModel(TankScriptableObject tankScriptableObject) : base(tankScriptableObject)
    {
        this.playerTankScriptableObject = tankScriptableObject;
        //this.tankType = tankScriptableObject.TankType;
        //this.movementSpeed = tankScriptableObject.MovementSpeed;
        //this.rotationSpeed = tankScriptableObject.RotationSpeed;
        //this.damage = tankScriptableObject.Damage;
    }
}
