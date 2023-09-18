using System;

public class EventService : MonoSingletonGeneric<EventService>
{
    public event Action<int> OnShotsFiredAction;
    public event Action<int> OnEnemiesDestroyedAction;

    public event Action OnPlayerDeathAction;
    public event Action OnEnemyDeathAction;
    //public event Action<ParticleEffectType, Vector3> onGameObjectDestroyed;
  
    public void InvokeShotsFiredAction(int nShotsFired)
    {
        OnShotsFiredAction?.Invoke(nShotsFired);
    }

    public void InvokeEnemiesDestroyedAction(int nEnemiesDestroyed)
    {
        OnEnemiesDestroyedAction?.Invoke(nEnemiesDestroyed);
    }

    internal void InvokePlayerDeathAction()
    {
        OnPlayerDeathAction?.Invoke();
    }
    public void InvokeEnemyDeathAction()
    {
        OnEnemyDeathAction?.Invoke();
    }
}
