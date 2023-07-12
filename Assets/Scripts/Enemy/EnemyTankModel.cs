
public class EnemyTankModel: TankModel
{
    public EnemyTankController EnemyTankController { private get; set; }
  
    EnemyTankScriptableObject enemyTankScriptableObject;
    public EnemyTankModel(EnemyTankScriptableObject enemyTankScriptableObject): base(enemyTankScriptableObject)
    {
        this.enemyTankScriptableObject = enemyTankScriptableObject;
    }
}
