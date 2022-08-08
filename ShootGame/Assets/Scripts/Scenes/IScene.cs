using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 规范场景
/// </summary>
public interface IScene 
{
    /// <summary>
    /// 初始化场景
    /// </summary>
    void Intialize();
    /// <summary>
    /// 结束场景
    /// </summary>
    void DeIntialize();

}
