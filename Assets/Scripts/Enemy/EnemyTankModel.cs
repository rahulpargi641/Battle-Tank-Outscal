using UnityEngine;

public class EnemyTankModel: TankModel
{
    public EnemyTankController Controller { private get; set; }
  
    private EnemyTankScriptableObject enemyTankSO;

    public EnemyTankModel(EnemyTankScriptableObject enemyTankSO): base(enemyTankSO)
    {
        this.enemyTankSO = enemyTankSO;
    }
}
