using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YLUIManager : YLUnitySingleton<YLUIManager>,IBaseManager
{
    /// <summary>
    /// 挂载面板的canvas
    /// </summary>
    private Transform canvas;
    /// <summary>
    /// 保存打开的面板
    /// </summary>
    private Dictionary<string, YLBasePanel> panelDict;
    private void Awake()
    {
        canvas = GameObject.Find("UICanvas").transform;
    }
    /// <summary>
    /// 初始化UImanager
    /// </summary>
    public void Initailize()
    {
        panelDict = new Dictionary<string, YLBasePanel>();
    }
    /// <summary>
    /// 结束UImanager
    /// </summary>
    public void Deinitialize()
    {
        panelDict.Clear();
    }
    void Start()
    {
    }
    /// <summary>
    /// 打开面板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T OpenPanel<T>()where T:YLBasePanel
    {
        string panelName = typeof(T).Name;
        if (panelDict.ContainsKey(panelName))
        {
            return panelDict[panelName] as T;
        }
        GameObject panelPrefab = Resources.Load<GameObject>("UI/" + panelName);
        // 克隆游戏对象，添加脚本
        T panel = GameObject.Instantiate(panelPrefab).AddComponent<T>();
        //不能省略
        panel.name = panelName;
        panel.transform.SetParent(canvas);
        panel.transform.localPosition = Vector3.zero;
        panel.transform.localRotation = Quaternion.identity;
        panel.transform.localScale = Vector3.one;
        panelDict.Add(panelName, panel);
        return panel;
    }
    /// <summary>
    /// 获取面板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetPanel<T>() where T: YLBasePanel
    {
        string panelName = typeof(T).Name;
        if (panelDict.ContainsKey(panelName))
        {
            return panelDict[panelName] as T;
        }
        return null;
    }
    /// <summary>
    /// 关闭面板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void ClosePanel<T>()
    {
        string panelName = typeof(T).Name;
        if (panelDict.ContainsKey(panelName))
        {
            //销毁场景中的游戏对象
            Destroy(panelDict[panelName].gameObject);
            //销毁内存中的引用
            panelDict.Remove(panelName);
        }
    }
    /// <summary>
    /// 关闭所有的面板
    /// </summary>
    public void  CloseAll()
    {
        foreach (var item in panelDict)
        {
            Destroy(panelDict[item.Key].gameObject);
        }
        panelDict.Clear();
    }
}
