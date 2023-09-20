using UnityEngine;

public class AchievementView : MonoBehaviour
{
    AchievementModel achievementModel;

   public AchievementView(AchievementModel achievementModel)
    {
        this.achievementModel = achievementModel;
    }

    public void ShotFired()
    {
        achievementModel.NShotsFired++;
        if(achievementModel.NShotsFired == achievementModel.ShotsFiredThreshold)
        {
            EventService.Instance.InvokeShotsFiredAction(achievementModel.NShotsFired);
        }
    }

    public void EnemyDestroyed()
    {
        achievementModel.NEnemiesDestroyed++;

        if (achievementModel.NEnemiesDestroyed % achievementModel.EnemiesDestroyedThreshold == 0)
        {
            EventService.Instance.InvokeEnemiesDestroyedAction(achievementModel.NEnemiesDestroyed);
            //GameAudioService.Instance.PlayAudio(GameAudio.SoundType.Explosion);
            Debug.Log("Enemies Destroyed achiement");
        }

        if (achievementModel.NEnemiesDestroyed == achievementModel.MaxEnemies)
            EventService.Instance.InvokeLevelCompleteAction();
    }
}
