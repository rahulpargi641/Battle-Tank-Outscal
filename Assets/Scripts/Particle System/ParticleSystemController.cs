using System;
using System.Threading.Tasks;
using UnityEngine;

public class ParticleSystemController : ParticleEventObserver
{
    private ParticleSystemModel model;
    ParticlePoolService particlePoolService;

    public ParticleSystemController(ParticleSystemModel model)
    {
        this.model = model;
        particlePoolService = new ParticlePoolService();
    }

    public void HandleParticleEvent(ParticleEvent particleEvent)
    {
        ParticleSystem particleSystemPrefab = GetParticleSystem(particleEvent.EventType);
        if(particleSystemPrefab)
        {
            //ParticleSystem particleSystem = GameObject.Instantiate(particleSystemPrefab) as ParticleSystem;
            particlePoolService.Initialize(particleSystemPrefab);
            ParticleSystem particleSystem = particlePoolService.GetParticleSystem();
            particleSystem.gameObject.SetActive(true);
            particleSystem.transform.position = particleEvent.Position;
            particleSystem.Play();
            ReturnParticleSystemToPoolAsync(particleSystem);
        }
        else
        {
            Debug.LogError("Particle system not found for event type: " + particleEvent.EventType);
        }
    }

    public async void ReturnParticleSystemToPoolAsync(ParticleSystem particleSystem)
    {
        while (particleSystem && particleSystem.isPlaying)
        {
            await Task.Yield();
        }

        if (particleSystem)
        {
            particleSystem.gameObject.SetActive(false);
            particlePoolService.ReturnItem(particleSystem);

            Debug.Log("Particle system returned to the pool: " + particleSystem);
        }
    }

    private ParticleSystem GetParticleSystem(ParticleEventType particleEventType)
    {
        ParticleBox particleSystemBox = FindParticleSystemBox(particleEventType);
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

    private ParticleBox FindParticleSystemBox(ParticleEventType particleEventType)
    {
        return Array.Find(model.particleBoxes, particleSystemBox => particleSystemBox.particleEventType == particleEventType);
    }
}
