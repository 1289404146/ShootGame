using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goods : YLBaseMono
{
    /// <summary>
    /// 装备名字
    /// </summary>
    public string EquipName { get; set; }
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

    private Text lable;
    private Toggle toggle;
    public Action<Goods> ChangeSelectItem;
    private void Awake()
    {
        lable = transform.Find("Label").GetComponent<Text>();
        toggle = GetComponent<Toggle>();
    }
    private void Start()
    {
        toggle.onValueChanged.AddListener(ToggleClick);
    }

    private void ToggleClick(bool ison)
    {
        if (ison)
        {
            ChangeSelectItem.Invoke(this);
        }
    }

    /// <summary>
    /// 设置文本显示
    /// </summary>
    /// <param name="enable"></param>
    public void SetCountLableActive(bool enable)
    {
        lable.enabled = enable;
    }
    public void SetCountLabel(int count)
    {
        lable.text = count.ToString();
    }
    /// <summary>
    /// 设置商品显示信息
    /// </summary>
    /// <param name="equip"></param>
    public void SetDate(Equip equip)
    {
        EquipName = equip.EquipName;
        Price = equip.Price;
        Icon = equip.Icon;
        Info = equip.Info;
        SpeedValue = equip.SpeedValue;
        BloodValue = equip.BloodValue;
        Count = equip.Count;
    }

}
