
public class GameService : MonoSingletonGeneric<GameService>
{
    //[SerializeField] TankView tankView;
    //public TankScriptableObject[] tankConfigs;
    public TankScriptableObjectList tankScriptableObjectList;
    private void Start()
    {
        CreatePlayerTank();
    }

    private TankController CreatePlayerTank()
    {
        //TankScriptableObject tankScriptableObject = tankConfigs[2];
        TankScriptableObject tankScriptableObject = tankScriptableObjectList.tanks[0];
        //TankModel tankModel = new TankModel(10, 20);
        TankModel tankModel = new TankModel(tankScriptableObject);
        TankController tank = new TankController(tankModel, tankScriptableObject.TankView);
        return tank;
    }
}
