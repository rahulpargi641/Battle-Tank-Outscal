using UnityEngine;

public class AchievementService : MonoSingletonGeneric<AchievementService>
{
    private AchievementController achievementController;
   
    void Start()
    {
        AchievementModel achievementModel= new AchievementModel();
        achievementController = new AchievementController(achievementModel);

        EventService.Instance.OnEnemyDeathAction += EnemyDestroyed;
    }

    private void OnDestroy()
    {
        EventService.Instance.OnEnemyDeathAction -= EnemyDestroyed;
    }

    private void EnemyDestroyed()
    {
        achievementController.EnemyDestroyed();
    }

    public void ShotFired()
    {
        achievementController.ShotFired();
    }
}
