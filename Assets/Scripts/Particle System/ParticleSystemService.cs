using System;
using System.Collections;
using UnityEngine;

public class ParticleSystemService : MonoSingletonGeneric<ParticleSystemService>
{
    [SerializeField] ParticleBox[] particleSystemBoxes;
    private ParticlePoolService particlePoolService;

    private void Start()
    {
        particlePoolService = new ParticlePoolService();
    }

    public void SpawnParticles(ParticleEvent particleEvent)
    {
        ParticleBox particleSystemBox = FindParticleSystemBox(particleEvent.EventType);
        ParticleSystem particleSystemPrefab = particleSystemBox?.particleSystem;

        if (particleSystemPrefab != null)
        {
            ParticleSystem particleSystem = GetPooledParticleSystem(particleSystemPrefab);
            if (particleSystem != null)
            {
                SetupAndPlayParticleSystem(particleSystem, particleEvent.Position);
                StartCoroutine(ReturnParticleSystemToPool(particleSystem));
            }
        }
        else
        {
            Debug.LogError("Particle system not found for event type: " + particleEvent.EventType);
        }
    }

    private ParticleSystem GetPooledParticleSystem(ParticleSystem prefab)
    {
        particlePoolService.Initialize(prefab);
        return particlePoolService.GetParticleSystem();
    }

    private void SetupAndPlayParticleSystem(ParticleSystem particleSystem, Vector3 position)
    {
        particleSystem.gameObject.SetActive(true);
        particleSystem.transform.position = position;
        particleSystem.Play();
    }

    private IEnumerator ReturnParticleSystemToPool(ParticleSystem particleSystem)
    {
        while (particleSystem != null && particleSystem.isPlaying)
        {
            yield return null;
        }

        if (particleSystem != null)
        {
            DeactivateAndReturnToPool(particleSystem);
        }
    }

    private void DeactivateAndReturnToPool(ParticleSystem particleSystem)
    {
        particleSystem.gameObject.SetActive(false);
        particlePoolService.ReturnItem(particleSystem);
        Debug.Log("Particle system returned to the pool: " + particleSystem);
    }

    private ParticleBox FindParticleSystemBox(ParticleEventType particleEventType)
    {
        return Array.Find(particleSystemBoxes, particleSystemBox => particleSystemBox.particleEventType == particleEventType);
    }
}
