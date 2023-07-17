using UnityEngine;

public class PlayerTankModel: TankModel
{
    public PlayerTankController PlayerTankController { private get;  set; }
    //TankType tankType { get; }
    public float MoveSpeed { get; }
    public float MovementSpeedLive { get { return playerTankScriptableObject.MoveSpeed; } }
    public float TurnSpeed { get; }
    public int Damage { get; }


    private PlayerTankScriptableObject playerTankScriptableObject;
    public PlayerTankModel(PlayerTankScriptableObject playerTankScriptableObject) : base(playerTankScriptableObject)
    {
        this.playerTankScriptableObject = playerTankScriptableObject;
        this.MoveSpeed = playerTankScriptableObject.MoveSpeed;
        this.TurnSpeed = playerTankScriptableObject.turnSpeed;
    }
}
