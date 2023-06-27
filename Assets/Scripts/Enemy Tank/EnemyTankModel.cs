
public class EnemyTankModel: TankModel
{
    public EnemyTankController EnemyTankController { private get; set; }
  
    TankScriptableObject enemyTankScriptableObject;
    public EnemyTankModel(TankScriptableObject enemyTankScriptableObject): base(enemyTankScriptableObject)
    {
        this.enemyTankScriptableObject = enemyTankScriptableObject;
    }
}
