using System.Collections.Generic;
using UnityEngine;

public class EnemyTankService : MonoSingletonGeneric<EnemyTankService>
{
    [SerializeField] EnemyTankScriptableObjectList enemyTankSOList;

    [SerializeField] int numberOfTanks = 5; // Number of tanks to spawn
    [SerializeField] float spawningRange = 15f; // Radius within which tanks will be spawned

    EnemyTankController enemyTankController;

    EnemyTankPoolService tankPoolService;

    private void Start()
    {
        tankPoolService = new EnemyTankPoolService();
    }

    public List<EnemyTankController> CreateEnemyTanks()
    {
        List<EnemyTankController> spawnedEnemyControllers = new List<EnemyTankController>();
        for (int i = 0; i < numberOfTanks; i++)
        { 
            EnemyTankScriptableObject enemyTankSO = enemyTankSOList.EnemyTanks[0];
            EnemyTankModel enemyTankModel = new EnemyTankModel(enemyTankSO);
            EnemyAIView enemyTankView = SpawnRandomlyInsideSpehre(enemyTankSO);
            //enemyTankController = new EnemyTankController(enemyTankModel, enemyTankSO.EnemyTankView);
            enemyTankController = tankPoolService.GetEnemyTankContoller(enemyTankModel, enemyTankView);
            enemyTankController.Enable();
            spawnedEnemyControllers.Add(enemyTankController);
        }
        return spawnedEnemyControllers;
    }

    private EnemyAIView SpawnRandomlyInsideSpehre(EnemyTankScriptableObject tankScriptableObject)
    {
        float randomXPos = UnityEngine.Random.Range(-spawningRange, spawningRange);
        float randomZPos = UnityEngine.Random.Range(-spawningRange, spawningRange);
        Vector3 randomPosition = new Vector3(transform.position.x + randomXPos, transform.position.y, transform.position.z + randomZPos);
        EnemyAIView enemyTankView = Instantiate(tankScriptableObject.EnemyTankView, randomPosition, Quaternion.identity); // put this line inside enemycontroller
        return enemyTankView;
    }

    void ReturnTank()
    {
        enemyTankController.OnDisable();
        tankPoolService.ReturnItem(enemyTankController);
    }
}