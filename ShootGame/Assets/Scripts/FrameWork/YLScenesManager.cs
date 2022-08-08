using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType
{
    Lancher=0,
    Login,
    Main,
    Game
}

public class YLScenesManager : YLUnitySingleton<YLScenesManager>,IBaseManager
{
    public void Initailize()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }
    /// <summary>
    /// 监听场景是否切换
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="arg1"></param>
    private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode arg1)
    {
        SceneType index = (SceneType)scene.buildIndex;
        switch (index)
        {
            case SceneType.Lancher:
                Debug.Log("Lancher加载了");
                break;
            case SceneType.Login:
                YLSingleton<Login>.Instance.Intialize();
                break;
            case SceneType.Main:
                YLSingleton<Main>.Instance.Intialize();
                break;
            case SceneType.Game:
                YLSingleton<Game>.Instance.Intialize();
                break;
            default:
                break;
        }
    }
    public void LoadScene(SceneType scenType)
    {
        SceneManager.LoadScene((int)scenType);
    }
    public void Deinitialize()
    {
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
