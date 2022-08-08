using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YLUnitySingleton<T> : YLBaseMono where T:YLBaseMono 
{
    private readonly static object lockObj = new object();
    protected static T instance = null;
    /// <summary>
    /// 获取组件
    /// </summary>
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = (T)GameObject.FindObjectOfType<T>();
                    if (FindObjectsOfType<T>().Length >= 1)
                    {
                        return instance;
                    }
                    instance = GameObject.Find("GameRoot").AddComponent<T>();
                }
            }
            return instance;
        }
    }
    /// <summary>
    /// 移除组件
    /// </summary>
    public  void RemoveComponent()
    {
        Component com = GameObject.Find("GameRoot").GetComponent<T>();
        if (com = null)
        {
            Destroy(com);
        }
        else
        {
            Debug.Log("没有此组件");
        }
    }
}
