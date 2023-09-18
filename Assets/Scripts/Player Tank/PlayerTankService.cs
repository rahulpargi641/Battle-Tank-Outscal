using UnityEngine;

public class PlayerTankService : MonoSingletonGeneric<PlayerTankService>
{
    //public TankScriptableObject[] tankConfigs;
    [SerializeField] PlayerTankScriptableObjectList playerTankSOList;
    [SerializeField] PlayerTankView playerTankView;
    private PlayerTankController playerTankController;

    private void Awake()
    {
        base.Awake();
        CreatePlayerTank();
    }
    public PlayerTankController CreatePlayerTank()
    {
        //TankScriptableObject tankScriptableObject = tankConfigs[2];
        PlayerTankScriptableObject tankScriptableObject = playerTankSOList.PlayerTanks[0];
        PlayerTankModel playerTankModel = new PlayerTankModel(tankScriptableObject);
        //PlayerTankView playerTankView = GameObject.Instantiate<PlayerTankView>(tankScriptableObject.PlayerTankView);
        playerTankController = new PlayerTankController(playerTankModel, playerTankView);
        return playerTankController;
    }
}
