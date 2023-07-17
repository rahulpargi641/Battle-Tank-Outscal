using System;

public class EventService : MonoSingletonGeneric<EventService>
{
    public event Action<int> onShotsFiredAction;
    public event Action<int> onEnemyDeathAction;
    public event Action onPlayerDeathAction;
    //public event Action<ParticleEffectType, Vector3> onGameObjectDestroyed;
  
    public void InvokeShotsFiredAction(int nShotsFired)
    {
        onShotsFiredAction?.Invoke(nShotsFired);
    }

    public void InvokeEnemyDeathAction(int nEnemiesDestroyed)
    {
        onEnemyDeathAction?.Invoke(nEnemiesDestroyed);
    }

    internal void OnPlayerDeathAction()
    {
        onPlayerDeathAction?.Invoke();
    }
}
