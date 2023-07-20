using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModel
{
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }
    public bool IsDead { get; set; }

    public HealthModel(float maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        IsDead = false;
    }
}
