using UnityEngine;

public class AchievementService : MonoSingletonGeneric<AchievementService>
{
    private AchievementView achievementView;
   
    void Start()
    {
        AchievementModel achievementModel= new AchievementModel();
        achievementView = new AchievementView(achievementModel);

        EventService.Instance.OnEnemyDeathAction += EnemyDestroyed;
    }

    private void EnemyDestroyed()
    {
        achievementView.EnemyDestroyed();
    }

    public void ShotFired()
    {
        achievementView.ShotFired();
    }
}
