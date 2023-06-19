using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    public TankController tankController { private get; set; }
    public float movementSpeed { get; private set; }
    public float rotationSpeed { get; private set; }

    public TankModel(float movementSpeed, float rotationSpeed)
    {
        this.movementSpeed = movementSpeed;
        this.rotationSpeed = rotationSpeed;
    }
}
