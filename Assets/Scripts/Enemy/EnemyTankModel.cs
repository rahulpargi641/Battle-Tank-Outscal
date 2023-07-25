
using UnityEngine;

public class EnemyTankModel: TankModel
{
    public EnemyTankController Controller { private get; set; }
  
    private EnemyTankScriptableObject enemyTankScriptableObject;

   // public NavmeshAgent NavmeshAgent { private set; get; }

    public Animator Animator { private set; get; }
    public Transform PlayerTransform { private set; get; }


    public EnemyTankModel(EnemyTankScriptableObject enemyTankScriptableObject): base(enemyTankScriptableObject)
    {
        this.enemyTankScriptableObject = enemyTankScriptableObject;
    }
}
