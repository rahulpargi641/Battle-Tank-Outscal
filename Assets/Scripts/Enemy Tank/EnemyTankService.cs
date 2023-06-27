using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankService : MonoSingletonGeneric<EnemyTankService>
{
    [SerializeField] TankScriptableObjectList enemyTankSOList;

    [SerializeField] int numberOfTanks = 5; // Number of tanks to spawn
    [SerializeField] float spawnRadius = 10f; // Radius within which tanks will be spawned


    public List<EnemyTankController> CreateEnemyTanks()
    {
        List<EnemyTankController> spawnedEnemyControllers = new List<EnemyTankController>();
        for (int i = 0; i < numberOfTanks; i++)
        { 
            TankScriptableObject tankScriptableObject = enemyTankSOList.tanks[0];
            EnemyTankModel enemyTankModel = new EnemyTankModel(tankScriptableObject);
            EnemyTankView enemyTankView = SpawnRandomlyInsideSpehre(tankScriptableObject);
            EnemyTankController enemyTankController = new EnemyTankController(enemyTankModel, tankScriptableObject.EnemyTankView);
            spawnedEnemyControllers.Add(enemyTankController);
        }
        return spawnedEnemyControllers;
    }

    private EnemyTankView SpawnRandomlyInsideSpehre(TankScriptableObject tankScriptableObject)
    {
        Vector3 randomPosition = transform.position + UnityEngine.Random.insideUnitSphere * spawnRadius;
        EnemyTankView enemyTankView = Instantiate(tankScriptableObject.EnemyTankView, randomPosition, Quaternion.identity);
        return enemyTankView;
    }
}