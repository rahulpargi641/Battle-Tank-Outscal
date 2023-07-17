using UnityEngine;

public class AchievementService : MonoSingletonGeneric<AchievementService>
{
    private AchievementView achievementView;
   
    void Start()
    {
        AchievementModel achievementModel= new AchievementModel();
        achievementView = new AchievementView(achievementModel);
        Debug.Log("Achievement Service created");

    }
    public void ShotFired()
    {
        achievementView.ShotFired();
    }

    public void EnemyKilled()
    {
        achievementView.EnemyDestroyed();
    }
}
