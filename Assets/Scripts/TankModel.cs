using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    TankType tankType { get; }
    public float movementSpeed { get; }
    //public float movementSpeedLive { get { return tankScriptableObject.MovementSpeed; } }
    public float rotationSpeed { get; }
    public int damage { get; }

    public TankModel(TankScriptableObject tankScriptableObject)
    {
        //this.tankScriptableObject = tankScriptableObject;
        this.tankType = tankScriptableObject.TankType;
        this.movementSpeed = tankScriptableObject.MovementSpeed;
        this.rotationSpeed = tankScriptableObject.RotationSpeed;
        this.damage = tankScriptableObject.Damage;
    }
}
