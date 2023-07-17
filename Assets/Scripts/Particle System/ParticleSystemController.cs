using System;
using UnityEngine;

public class ParticleSystemController
{
    private ParticleSystemModel model;

    public ParticleSystemController(ParticleSystemModel model)
    {
        this.model = model;       
    }

    public void SpawnParticles(ParticleEvent particleEvent)
    {
        ParticleSystem particleSystem = GetParticleSystem(particleEvent.EventType);
        if(particleSystem)
        {
            // Spawn particles at the specified position using the corresponding particle system
            ParticleSystem instance = GameObject.Instantiate(particleSystem) as ParticleSystem;
            instance.transform.position = particleEvent.Position;
            instance.Play();
            Debug.Log("Particles spawned succesfully");
        }
        else
        {
            Debug.LogError("Particle system not found for event type: " + particleEvent.EventType);
        }
    }

    private ParticleSystem GetParticleSystem(ParticleEventType particleEventType)
    {
        ParticleSystemBox particleSystemBox = FindParticleSystemBox(particleEventType);
        if (particleSystemBox != null)
        {
            return particleSystemBox.particleSystem;
        }
        else
        {
            Debug.LogError("Particle Box  not found for particle event type: " + particleEventType);
            return null;
        }
    }

    private ParticleSystemBox FindParticleSystemBox(ParticleEventType particleEventType)
    {
        return Array.Find(model.particleSystemBoxes, particleSystemBox => particleSystemBox.particleEventType == particleEventType);
    }
}
