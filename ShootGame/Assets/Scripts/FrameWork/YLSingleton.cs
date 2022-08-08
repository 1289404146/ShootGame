using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YLSingleton<T> where T : class, new()
{
    private readonly static object lockobj = new object();
    protected static T instance = null;
    public static T Instance
    {
        get
        {
            lock (lockobj)
            {
                if (instance == null)
                {
                    instance = new T();
                    return instance;
                }
            }
            return instance;
        }
    }
        
}
