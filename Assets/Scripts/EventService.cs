using System;


public class EventService : MonoSingletonGeneric<EventService>
{
    public event Action onShotsFiredAction;
    public event Action onEnemyDeathAction;
    public event Action onPlayerDeathAction;
    //public event Action<ParticleEffectType, Vector3> onGameObjectDestroyed;
  
    public void OnShotsFiredAction(string nShotsFiredText)
    {
        onShotsFiredAction?.Invoke();
    }

    public void OnEnemyDeathAction(string nEnemiesKilledText)
    {
        onEnemyDeathAction?.Invoke();
    }

    internal void OnPlayerDeathAction()
    {
        onPlayerDeathAction?.Invoke();
    }
}
