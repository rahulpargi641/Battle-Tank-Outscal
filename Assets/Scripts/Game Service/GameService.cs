using System.Collections.Generic;
using UnityEngine;

public class GameService : MonoSingletonGeneric<GameService>
{
    PlayerTankController playerTankController;
    List<EnemyTankController> enemyTankControllers = new List<EnemyTankController>();
    private void Start()
    {
        PlayerTankController playerTankController = PlayerTankService.Instance.CreatePlayerTank();
        enemyTankControllers = EnemyTankService.Instance.CreateEnemyTanks();
    }
}
