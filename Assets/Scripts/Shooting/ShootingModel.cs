
public class ShootingModel
{
    public float MinLaunchForce { get; private set; }
    public float MaxLaunchForce { get; private set; }
    public float MaxChargeTime { get; private set; }
    public string FireButton { get; set; }
    public float CurrentLaunchForce { get; set; }
    public float ChargeSpeed { get; set; }
    public bool Fired { get; set; }
    public int NSHotsFired { get; set; }
    public ShootingModel()
    {
        MinLaunchForce = 15f;
        MaxLaunchForce = 30f;
        MaxChargeTime = 0.75f;
    }
}
