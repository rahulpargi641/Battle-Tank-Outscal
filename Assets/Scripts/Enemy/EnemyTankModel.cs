using UnityEngine;

public class EnemyTankModel: TankModel
{
    public EnemyTankController Controller { private get; set; }
  
    private EnemyTankScriptableObject enemyTankSO;

   // public NavmeshAgent NavmeshAgent { private set; get; }

    public Animator Animator { private set; get; }
    public Transform PlayerTransform { private set; get; }

    public EnemyTankModel(EnemyTankScriptableObject enemyTankSO): base(enemyTankSO)
    {
        this.enemyTankSO = enemyTankSO;
    }
}
