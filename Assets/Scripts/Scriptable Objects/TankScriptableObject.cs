using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/TankScriptableObject")]
public class TankScriptableObject : ScriptableObject
{
    [Header("Properties")]
    public TankType TankType;
    public TankView TankView; // you can have standard blue tank or legendary blue tank with particle effects, Use required component
    public float Health;
    public int Damage;

    [Header("Movement")]
    public float MovementSpeed;
    public float RotationSpeed;

    [Header("Projectiles")]
    public ProjectileType ProjectileType;
}
