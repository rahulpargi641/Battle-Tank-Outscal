
using UnityEngine;

public class TankModel
{
    public int Health { private set; get; }
    public TankType TankType { private set; get; }
    public ShellTypes BulletType { private set; get; }

    protected TankModel(TankScriptableObject tankScriptableObject)
    {
        this.Health = tankScriptableObject.Health;
        this.TankType = tankScriptableObject.TankType;
        this.BulletType = tankScriptableObject.BulletType;
    }
}
