using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : BaceScene,IScene
{
    public void Intialize()
    {
        YLUIManager.Instance.OpenPanel<MainPanel>();
    }
    public void DeIntialize()
    {
        YLUIManager.Instance.CloseAll();
    }
}
