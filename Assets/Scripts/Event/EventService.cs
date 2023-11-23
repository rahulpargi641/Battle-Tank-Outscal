using System;

public class EventService : MonoSingletonGeneric<EventService>
{
    public event Action<int> OnShotsFiredAction;
    public event Action<int> OnEnemiesDestroyedAction;

    public event Action OnPlayerDeathAction;
    public event Action OnEnemyDeathAction;

    public event Action onLevelCompleteAction;

    //public event Action<ParticleEffectType, Vector3> onGameObjectDestroyed;

    private void Awake()
    {
        base.Awake();
    }

    public void InvokeShotsFiredEvent(int nShotsFired)
    {
        OnShotsFiredAction?.Invoke(nShotsFired);
    }

    public void InvokeEnemiesDestroyedEvent(int nEnemiesDestroyed)
    {
        OnEnemiesDestroyedAction?.Invoke(nEnemiesDestroyed);
    }

    internal void InvokePlayerDeathEvent()
    {
        OnPlayerDeathAction?.Invoke();
    }
    public void InvokeEnemyDeathEvent()
    {
        OnEnemyDeathAction?.Invoke();
    }

    public void InvokeLevelCompleteEvent()
    {
        onLevelCompleteAction?.Invoke();
    }
}
