
public class ParticleSystemModel
{
    public ParticleBox[] particleBoxes { get; private set; }

    public ParticleSystemModel(ParticleBox[] particleBoxes)
    {
        this.particleBoxes = particleBoxes;
    }
}
