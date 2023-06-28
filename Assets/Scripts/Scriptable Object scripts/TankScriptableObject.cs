using UnityEngine;

public class TankScriptableObject : ScriptableObject
{
    [Header("Properties")]
    public TankType TankType;
    public BulletTypes BulletType;
    //public PlayerTankView PlayerTankView; // you can have standard blue tank or legendary blue tank with particle effects, Use required component
    public int Health;
    //public int Damage;

    //[Header("Movement")]
    //public float MovementSpeed;
    //public float RotationSpeed;
}
