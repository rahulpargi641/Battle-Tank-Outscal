using UnityEngine;

public class ParticleService : MonoSingletonGeneric<ParticleService>
{
    [SerializeField] ParticleSystemBox[] particleSystemBoxes;
    private ParticleSystemController particleSystemController;

    private void Start()
    {
        ParticleSystemModel particleSystemModel = new ParticleSystemModel(particleSystemBoxes);
        particleSystemController = new ParticleSystemController(particleSystemModel);
    }

    public void HandleParticleEvent(ParticleEvent particleEvent)
    {
        particleSystemController.SpawnParticles(particleEvent);
    }
}
