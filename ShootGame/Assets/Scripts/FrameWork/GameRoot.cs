using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    void Start()
    {
        // 切换场景不销毁该物体
        DontDestroyOnLoad(gameObject);
        YLUIManager.Instance.Initailize();
        YLScenesManager.Instance.Initailize();
        YLDataManager.Instance.Initailize();
        YLAudioSourceManager.Instance.Initailize();
        YLScenesManager.Instance.LoadScene(SceneType.Login);

    }
    private void OnDestroy()
    {
        YLAudioSourceManager.Instance.Deinitialize();
        YLDataManager.Instance.Deinitialize();
        YLScenesManager.Instance.Deinitialize();
        YLUIManager.Instance.Deinitialize();
    }
}
