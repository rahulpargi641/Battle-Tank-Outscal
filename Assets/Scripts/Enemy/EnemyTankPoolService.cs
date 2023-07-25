
public class EnemyTankPoolService : PoolServiceGeneric<EnemyTankController>
{
    private EnemyTankModel model;
    private EnemyAIView view;

    public EnemyTankController GetEnemyTankContoller(EnemyTankModel model, EnemyAIView view)
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
