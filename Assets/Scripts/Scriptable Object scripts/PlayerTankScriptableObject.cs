using UnityEngine;

[CreateAssetMenu(fileName = "PlayerTankScriptableObject", menuName = "ScriptableObjects/PlayerTankScriptableObject")]
public class PlayerTankScriptableObject: TankScriptableObject
{
    public PlayerTankView PlayerTankView;

    [Header("Movement")]
    public float MoveSpeed;
    public float TurnSpeed;

    [Header("Wheels")]
    public float wheelRotationSpeed;

    [Header("Turret")]
    public float TurretSpinSpeed;
}
