using System.Collections.Generic;

public class PoolServiceGeneric<T> : MonoSingletonGeneric<PoolServiceGeneric<T>> where T : class
{
    private List<PooledItem<T>> pooledItems = new List<PooledItem<T>>();

    protected virtual T GetItemFromPool()
    {
        if (pooledItems.Count > 0)
        {
            PooledItem<T> pooledItem = pooledItems.Find(item => item.IsUsed == false);
            if (pooledItem != null)
            {
                pooledItem.IsUsed = true;
                return pooledItem.Item;
            }
        }

        return CreateNewItemAndStoreInPool();
    }
           

    private T CreateNewItemAndStoreInPool()
    {
        PooledItem<T> item = new PooledItem<T>();
        item.Item = CreateItem();
        item.IsUsed = true;

        pooledItems.Add(item);

        return item.Item;
    }

    public virtual void ReturnItem(T gameObjectToReturn)
    {
        PooledItem<T> item = pooledItems.Find(item => item.Item.Equals(gameObjectToReturn));
        item.IsUsed = false;
        print("Item returned to the pool" + item.Item);
    }
    protected virtual T CreateItem()
    {
        return null;
    }

    public virtual void Initialize(T item)
    {
        // item will be used to assign the member variable in child classes
    }

    private class PooledItem<T>
    {
        public T Item;
        public bool IsUsed;
    }
}
