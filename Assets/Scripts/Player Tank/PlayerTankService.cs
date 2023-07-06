using UnityEngine;

public class PlayerTankService : MonoSingletonGeneric<PlayerTankService>
{
    //[SerializeField] TankView tankView;
    //public TankScriptableObject[] tankConfigs;
    [SerializeField] PlayerTankScriptableObjectList playerTankSOList;
    private PlayerTankController playerTankController;
    public PlayerTankController CreatePlayerTank()
    {
        //TankScriptableObject tankScriptableObject = tankConfigs[2];
        PlayerTankScriptableObject tankScriptableObject = playerTankSOList.PlayerTanks[0];
        //TankModel tankModel = new TankModel(10, 20);
        PlayerTankModel playerTankModel = new PlayerTankModel(tankScriptableObject);
        PlayerTankView playerTankView = GameObject.Instantiate<PlayerTankView>(tankScriptableObject.PlayerTankView);
        playerTankController = new PlayerTankController(playerTankModel, playerTankView);
        return playerTankController;
    }


    private void Update()
    {
        playerTankController.Update();
    }
}
