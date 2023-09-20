
public class AchievementModel
{
    public int NShotsFired { get; set; }
    public int NEnemiesDestroyed { get; set; }
    public int ShotsFiredThreshold { get; private set; }
    public int EnemiesDestroyedThreshold { get; private set; }
    public int MaxEnemies { get; private set; }

    public AchievementModel()
    {
        ShotsFiredThreshold = 50;
        EnemiesDestroyedThreshold = 5;
        MaxEnemies = 6;
    }
}
