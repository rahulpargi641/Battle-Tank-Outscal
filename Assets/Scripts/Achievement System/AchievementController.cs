using UnityEngine;

public class AchievementController : MonoBehaviour
{
    private AchievementModel model;

    public AchievementController(AchievementModel model)
    {
        this.model = model;
    }

    public void ShotFired()
    {
        model.NShotsFired++;

        if(model.NShotsFired == model.ShotsFiredThreshold)
            EventService.Instance.InvokeShotsFiredEvent(model.NShotsFired);
    }

    public void EnemyDestroyed()
    {
        model.NEnemiesDestroyed++;

        if (model.NEnemiesDestroyed % model.EnemiesDestroyedThreshold == 0)
            EventService.Instance.InvokeEnemiesDestroyedEvent(model.NEnemiesDestroyed);

        if (model.NEnemiesDestroyed == model.MaxEnemies)
            EventService.Instance.InvokeLevelCompleteEvent();
    }
}
