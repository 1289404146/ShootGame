using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipType
{
    Speed=0,
    Blood
}
public class Equip 
{
    /// <summary>
    /// 装备名字
    /// </summary>
    public  string EquipName { get; set; }
    /// <summary>
    /// 价格
    /// </summary>
    public int Price { get; set; }
    /// <summary>
    /// 装备图标的名字
    /// </summary>
    public string Icon { get; set; }
    /// <summary>
    /// 装备的描述信息
    /// </summary>
    public string Info { get; set; }
    /// <summary>
    /// 速度加成
    /// </summary>
    public int SpeedValue { get; set; }
    /// <summary>
    /// 血量加成
    /// </summary>
    public int BloodValue { get; set; }
    /// <summary>
    /// 数量
    /// </summary>
    public int Count { get; set; }
    /// <summary>
    /// 装备类型
    /// </summary>
    public EquipType EquipType { get; set; }

}
