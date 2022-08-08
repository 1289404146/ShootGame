using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class User 
{
    /// <summary>
    /// 用户名
    /// </summary>
    public string Username { get; set; }
    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; set; }
    /// <summary>
    /// 昵称
    /// </summary>
    public string NickName { get; set; }
    /// <summary>
    /// 金币
    /// </summary>
    public int Coin { get; set; }
    /// <summary>
    /// 用户的背包
    /// </summary>
    private Dictionary<string, Equip> bagDict;
    public User()
    {
        bagDict = new Dictionary<string, Equip>();
    }
    /// <summary>
    /// 购买装备
    /// </summary>
    /// <param name="equip"></param>
    /// <returns></returns>
    public int BuyEquip(Equip equip)
    {
        if (Coin > equip.Price)
        {
            if (bagDict.ContainsKey(equip.EquipName))
            {
                bagDict[equip.EquipName].Count++;
            }
            else
            {
                equip.Count = 1;
                bagDict.Add(equip.EquipName, equip);
            }
            Coin -= equip.Price;
            return 0;
        }
        return -1;
    }
    public int SellEquip(Equip equip)
    {
        if (bagDict.ContainsKey(equip.EquipName))
        {
            bagDict[equip.EquipName].Count--;
            if (bagDict[equip.EquipName].Count <= 0)
            {
                bagDict.Remove(equip.EquipName);
            }
            Coin += equip.Price / 2;
            return 0;
        }
        else
        {
            Debug.Log("背包中不存在此装备");
            return -1;
        }
    }
    public int UseEquip(Equip equip)
    {
        if (bagDict.ContainsKey(equip.EquipName))
        {
            bagDict[equip.EquipName].Count--;
            GameManager.Instance.UseEquip(equip);
            if (bagDict[equip.EquipName].Count <= 0)
            {
                bagDict.Remove(equip.EquipName);
            }
            return 0;
        }
        else
        {
            Debug.Log("背包中不存在此装备,无法使用");
            return -1;
        }
    }
    public List<Equip> GetUserBagEquipList
    {
        get
        {
            return bagDict.Values.ToList();
        }
    }
    /// <summary>
    /// 得到装备的数量
    /// </summary>
    /// <param name="equipName"></param>
    /// <returns></returns>
    public int GetCountEquipName(string equipName)
    {
        if (bagDict.ContainsKey(equipName))
        {
            return bagDict[equipName].Count;
        }
        else
        {
            return 0;
        }
    }
}
