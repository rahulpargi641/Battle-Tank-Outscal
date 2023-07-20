
public class ShellModel
{
    public float MaxDamage { get; private set; }
    public float ExplosionForce { get; private set; }
    public float MaxLifeTime  { get; private set; }
    public float ExplosionRadius { get; private set; }

    public ShellModel()
    {
        MaxDamage = 50f;
        ExplosionForce = 1000f;
        MaxLifeTime = 2f;
        ExplosionRadius = 7f;
    }
}
