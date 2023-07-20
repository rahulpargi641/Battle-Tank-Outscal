using UnityEngine;

public class ParticlePoolService : PoolServiceGeneric<ParticleSystem>
{
    private ParticleSystem particleSystemPrefab;

    // Initialize
    public override void Initialize(ParticleSystem item)
    {
        particleSystemPrefab = item;
    }

    public ParticleSystem GetParticleSystem()
    {
        return GetItemFromPool();
    }

    protected override ParticleSystem CreateItem()
    {
        return Instantiate(particleSystemPrefab);
    }
}
