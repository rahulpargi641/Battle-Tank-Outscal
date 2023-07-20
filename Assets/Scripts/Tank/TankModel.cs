
using UnityEngine;

public class TankModel
{
    public int Health { private set; get; }
    public TankType TankType { private set; get; }
    public ShellType ShellType { private set; get; }

    protected TankModel(TankScriptableObject tankScriptableObject)
    {
        this.Health = tankScriptableObject.Health;
        this.TankType = tankScriptableObject.TankType;
        this.ShellType = tankScriptableObject.BulletType;
    }
}
