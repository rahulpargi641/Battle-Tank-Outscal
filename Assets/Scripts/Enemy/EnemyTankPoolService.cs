
public class EnemyTankPoolService : PoolServiceGeneric<EnemyTankController>
{
    private EnemyTankModel model;
    private EnemyTankView view;

    public EnemyTankController GetEnemyTankContoller(EnemyTankModel model, EnemyTankView view)
    {
        this.model = model;
        this.view = view;

        return GetItemFromPool();
    }

    protected override EnemyTankController CreateItem()
    {
        EnemyTankController controller = new EnemyTankController(model, view);
        return controller;
    }
}
