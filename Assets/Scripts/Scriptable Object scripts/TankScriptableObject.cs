using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/TankScriptableObject")]
public class TankScriptableObject : ScriptableObject
{
    [Header("Properties")]
    public TankType TankType;
    public PlayerTankView PlayerTankView; // you can have standard blue tank or legendary blue tank with particle effects, Use required component
    public EnemyTankView EnemyTankView;
    public float Health;
    public int Damage;

    [Header("Movement")]
    public float MovementSpeed;
    public float RotationSpeed;

    [Header("Bullets")]
    public BulletTypes BulletType;
}
