using UnityEngine;

public class TankScriptableObject : ScriptableObject
{
    [Header("Properties")]
    public TankType TankType;
    public ShellType BulletType;
    public int Health;

    //public int Damage;

    //[Header("Movement")]
    //public float MovementSpeed;
    //public float RotationSpeed;
}
