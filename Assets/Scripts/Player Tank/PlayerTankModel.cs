using UnityEngine;

public class PlayerTankModel: TankModel
{
    public PlayerTankController playerTankController { private get;  set; }
    TankType tankType { get; }
    public float movementSpeed { get; }
    public float movementSpeedLive { get { return playerTankScriptableObject.MovementSpeed; } }
    public float rotationSpeed { get; }
    public int damage { get; }

    PlayerTankScriptableObject playerTankScriptableObject;
    public PlayerTankModel(PlayerTankScriptableObject playerTankScriptableObject) : base(playerTankScriptableObject)
    {
        this.playerTankScriptableObject = playerTankScriptableObject;
        this.movementSpeed = playerTankScriptableObject.MovementSpeed;
        this.rotationSpeed = playerTankScriptableObject.RotationSpeed;
    }
}
