using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : BaceScene, IScene
{
    public void Intialize()
    {
        YLUIManager.Instance.OpenPanel<GamePanel>();
        GameManager.Instance.Initailize();
    }
    public void DeIntialize()
    {
        GameManager.Instance.RemoveComponent();
        //GameManager.Instance.Deinitialize();
        YLUIManager.Instance.CloseAll();
    }
}
