
public class AchievementService : MonoSingletonGeneric<AchievementService>
{
    private int nShotsFired;
    private int nEnemiesKilled;

    private void OnEnable()
    {
        EventService.Instance.onShotsFiredAction += ShotsFired;
        EventService.Instance.onEnemyDeathAction += EnemyKilled;
    }

    protected override void Awake()
    {
        base.Awake();
        nShotsFired = 0;
        nEnemiesKilled = 0;
    }

    public void ShotsFired()
    {
        //GameAudioService.Instance.PlayAudio(GameAudio.SoundType.ShotFired);
        nShotsFired += 1;
        if (nShotsFired % 10 == 0)
        {
            string achievementText = nShotsFired + " SHOTS FIRED :)";
            EventService.Instance.OnShotsFiredAction(achievementText);
        }
    }

    public void EnemyKilled()
    {
        //GameAudioService.Instance.PlayAudio(GameAudio.SoundType.Explosion);
        nEnemiesKilled += 1;
        if (nEnemiesKilled % 5 == 0)
        {
            string achievementText = nEnemiesKilled + " ENEMIES KILLED :)";
            EventService.Instance.OnEnemyDeathAction(achievementText);
        }
    }

    private void OnDisable()
    {
        EventService.Instance.onShotsFiredAction -= ShotsFired;
        EventService.Instance.onEnemyDeathAction -= EnemyKilled;
    }
}
