
public class EnemyTankController
{
    private EnemyTankModel model;
    private EnemyAIView view;
    public EnemyTankController(EnemyTankModel model, EnemyAIView view)
    {
        this.model = model;
        this.view = view;

        this.model.Controller = this;
        this.view.Controller = this;
    }

    public void OnDisable()
    {
        view.Disable();
    }

    public void Enable()
    {
        view.Enabled();
    }
}
