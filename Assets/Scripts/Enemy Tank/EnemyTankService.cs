using System.Collections.Generic;
using UnityEngine;

public class EnemyTankService : MonoSingletonGeneric<EnemyTankService>
{
    [SerializeField] EnemyTankScriptableObjectList enemyTankSOList;

    [SerializeField] int numberOfTanks = 5; // Number of tanks to spawn
    [SerializeField] float spawningRange = 15f; // Radius within which tanks will be spawned


    public List<EnemyTankController> CreateEnemyTanks()
    {
        List<EnemyTankController> spawnedEnemyControllers = new List<EnemyTankController>();
        for (int i = 0; i < numberOfTanks; i++)
        { 
            EnemyTankScriptableObject enemyTankScriptableObject = enemyTankSOList.EnemyTanks[0];
            EnemyTankModel enemyTankModel = new EnemyTankModel(enemyTankScriptableObject);
            EnemyTankView enemyTankView = SpawnRandomlyInsideSpehre(enemyTankScriptableObject);
            EnemyTankController enemyTankController = new EnemyTankController(enemyTankModel, enemyTankScriptableObject.EnemyTankView);
            spawnedEnemyControllers.Add(enemyTankController);
        }
        return spawnedEnemyControllers;
    }

    private EnemyTankView SpawnRandomlyInsideSpehre(EnemyTankScriptableObject tankScriptableObject)
    {
        float randomXPos = UnityEngine.Random.Range(-spawningRange, spawningRange);
        float randomZPos = UnityEngine.Random.Range(-spawningRange, spawningRange);
        Vector3 randomPosition = new Vector3(transform.position.x + randomXPos, transform.position.y, transform.position.z + randomZPos);
        EnemyTankView enemyTankView = Instantiate(tankScriptableObject.EnemyTankView, randomPosition, Quaternion.identity);
        return enemyTankView;
    }
}