
using UnityEngine;

public class PlayerTankService : MonoSingletonGeneric<PlayerTankService>
{
    //[SerializeField] TankView tankView;
    //public TankScriptableObject[] tankConfigs;
    [SerializeField] TankScriptableObjectList playerTankSOList;
    private void Start()
    {
        //CreatePlayerTank();
    }

    public PlayerTankController CreatePlayerTank()
    {
        //TankScriptableObject tankScriptableObject = tankConfigs[2];
        TankScriptableObject tankScriptableObject = playerTankSOList.tanks[0];
        //TankModel tankModel = new TankModel(10, 20);
        PlayerTankModel playerTankModel = new PlayerTankModel(tankScriptableObject);
        PlayerTankView playerTankView = GameObject.Instantiate<PlayerTankView>(tankScriptableObject.PlayerTankView);
        PlayerTankController playerTankController = new PlayerTankController(playerTankModel, playerTankView);
        return playerTankController;
    }
}
