using UnityEngine;

[CreateAssetMenu(fileName = "PlayerTankScriptableObject", menuName = "ScriptableObjects/PlayerTankScriptableObject")]
public class PlayerTankScriptableObject: TankScriptableObject
{
    public PlayerTankView PlayerTankView;

    [Header("Movement")]
    public float MoveSpeed;
    public float turnSpeed;
}
