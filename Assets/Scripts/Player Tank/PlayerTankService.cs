using UnityEngine;

public class PlayerTankService : MonoSingletonGeneric<PlayerTankService>
{
    [SerializeField] private PlayerTankScriptableObjectList playerTankSOList;
    [SerializeField] private PlayerTankView playerTankView;
    private PlayerTankController playerTankController;

    protected override void Awake()
    {
        base.Awake();
        CreatePlayerTank();
    }
    public PlayerTankController CreatePlayerTank()
    {
        PlayerTankScriptableObject tankScriptableObject = playerTankSOList.PlayerTanks[0];
        PlayerTankModel playerTankModel = new PlayerTankModel(tankScriptableObject);
        //PlayerTankView playerTankView = GameObject.Instantiate<PlayerTankView>(tankScriptableObject.PlayerTankView);
        playerTankController = new PlayerTankController(playerTankModel, playerTankView);
        return playerTankController;
    }
}
