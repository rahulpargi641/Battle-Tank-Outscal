using UnityEngine;

public class ParticleSystemService : MonoSingletonGeneric<ParticleSystemService>
{
    [SerializeField] ParticleBox[] particleSystemBoxes;
    private ParticleSystemController particleSystemController;

    private void Start()
    {
        ParticleSystemModel particleSystemModel = new ParticleSystemModel(particleSystemBoxes);
        particleSystemController = new ParticleSystemController(particleSystemModel);
    }

    public void SpawnParticles(ParticleEvent particleEvent)
    {
        particleSystemController.HandleParticleEvent(particleEvent);
    }
}
