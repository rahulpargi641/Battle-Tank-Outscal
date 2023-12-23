using System.Collections.Generic;
using UnityEngine;

public class EnemyTankService : MonoSingletonGeneric<EnemyTankService>
{
    [SerializeField] private EnemyTankScriptableObjectList enemyTankSOList;
    [SerializeField] private int numberOfTanks = 5; // Number of tanks to spawn
    [SerializeField] private float spawningRange = 15f; // Radius within which tanks will be spawned

    private EnemyTankController enemyTankController;
    private EnemyTankPoolService tankPoolService;

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
            enemyTankController.OnEnable();

            spawnedEnemyControllers.Add(enemyTankController);
        }
        return spawnedEnemyControllers;
    }

    private EnemyAIView SpawnRandomlyInsideSpehre(EnemyTankScriptableObject tankScriptableObject)
    {
        float randomXPos = Random.Range(-spawningRange, spawningRange);
        float randomZPos = Random.Range(-spawningRange, spawningRange);
        Vector3 randomPosition = new Vector3(transform.position.x + randomXPos, transform.position.y, transform.position.z + randomZPos);
        EnemyAIView enemyTankView = Instantiate(tankScriptableObject.EnemyTankView, randomPosition, Quaternion.identity); 
        return enemyTankView;
    }

    public void ReturnTankToPool()
    {
        enemyTankController.OnDisable();
        tankPoolService.ReturnItem(enemyTankController);
    }
}