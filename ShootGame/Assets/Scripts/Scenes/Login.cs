using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login : BaceScene,IScene
{
    public void Intialize()
    {
        YLUIManager.Instance.OpenPanel<LoginPanel>();
    }
    public void DeIntialize()
    {
        YLUIManager.Instance.CloseAll();
    }
}
