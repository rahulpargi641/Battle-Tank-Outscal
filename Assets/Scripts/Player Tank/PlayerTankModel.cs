using UnityEngine;

public class PlayerTankModel: TankModel
{
    public PlayerTankController PlayerTankController { private get;  set; }
    //TankType tankType { get; }
    public float MoveSpeed { get; }
    public float MovementSpeedLive { get { return playerTankScriptableObject.MoveSpeed; } }
    public float TurnSpeed { get; }
    public int Damage { get; }
    public float WheelRotationSpeed { get; private set; }
    public float TurretSpinSpeed { get; private set; }

    private PlayerTankScriptableObject playerTankScriptableObject;
    public PlayerTankModel(PlayerTankScriptableObject playerTankScriptableObject) : base(playerTankScriptableObject)
    {
        this.playerTankScriptableObject = playerTankScriptableObject;
        MoveSpeed = playerTankScriptableObject.MoveSpeed;
        TurnSpeed = playerTankScriptableObject.TurnSpeed;

        WheelRotationSpeed = playerTankScriptableObject.wheelRotationSpeed;

        TurretSpinSpeed = playerTankScriptableObject.TurretSpinSpeed;
    }
}
