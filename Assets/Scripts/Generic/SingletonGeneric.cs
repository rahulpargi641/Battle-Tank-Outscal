using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonGeneric<T> where T : SingletonGeneric<T>, new()
{
    private static readonly T instance = new T();

    // Private constructor prevents instantiation from other classes.
    protected SingletonGeneric() { }

    // Public static property to access the instance.
    public static T Instance => instance;
}
