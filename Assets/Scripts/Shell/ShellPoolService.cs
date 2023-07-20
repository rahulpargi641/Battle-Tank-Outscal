using UnityEngine;

public class ShellPoolService : PoolServiceGeneric<ShellView>
{
    [SerializeField] ShellView shellPrefab;

    public ShellView GetShell()
    {
        return GetItemFromPool();
    }

    protected override ShellView CreateItem()
    {
        return Instantiate(shellPrefab);
    }
}
