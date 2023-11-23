using UnityEngine;

public class PlayerTankModel: TankModel
{
    public PlayerTankController PlayerTankController { private get;  set; }
    //TankType tankType { get; }
    public float MoveSpeed { get; }
    public float MovementSpeedLive { get { return playerTankSO.MoveSpeed; } }
    public float TurnSpeed { get; }
    public int Damage { get; }
    public float WheelRotationSpeed { get; private set; }
    public float TurretSpinSpeed { get; private set; }

    private PlayerTankScriptableObject playerTankSO;
    public PlayerTankModel(PlayerTankScriptableObject playerTankSO) : base(playerTankSO)
    {
        this.playerTankSO = playerTankSO;
        MoveSpeed = playerTankSO.MoveSpeed;
        TurnSpeed = playerTankSO.TurnSpeed;

        WheelRotationSpeed = playerTankSO.wheelRotationSpeed;

        TurretSpinSpeed = playerTankSO.TurretSpinSpeed;
    }
}
