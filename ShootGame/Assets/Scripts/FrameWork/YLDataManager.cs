using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class YLDataManager : YLUnitySingleton<YLDataManager>, IBaseManager
{
    private Dictionary<string, User> userDict;
    private Dictionary<string, Equip> equipDict;

    public User CurrentUser { get;private set; }
    public void Initailize()
    {
        userDict = new Dictionary<string, User>();
        equipDict = new Dictionary<string, Equip>();
        User user = new User()
        {
            Username = "yy",
            NickName = "齐天大圣孙悟空",
            Password = "yy",
            Coin = 3000
        };
        userDict.Add(user.Username, user);
        Equip equip = new Equip()
        {
            EquipName = "冷静之靴",
            Price = 720,
            Icon = "Shoes",
            Info = "这是一个可以加成速度的鞋子",
            SpeedValue = 5,
            BloodValue = 0,
            EquipType = EquipType.Speed
        };
        equipDict.Add(equip.EquipName, equip);
         equip = new Equip()
        {
            EquipName = "生命之水",
            Price = 720,
            Icon = "Blood",
            Info = "这是一个可以加血的装备",
            SpeedValue = 0,
            BloodValue = 200,
            EquipType = EquipType.Blood
        };
        equipDict.Add(equip.EquipName, equip);
    }
    public List<Equip> GetEquipList
    {
        get 
        {
            return equipDict.Values.ToList();
        }
    }
    /// <summary>
    /// 注册
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="nickname"></param>
    /// <returns></returns>
    public int Register(string username, string password, string nickname)
    {
        if (userDict.ContainsKey(username))
        {
            // 用户已经存在，注册失败
            return -1;
        }
        User user = new User()
        {
            Username = username,
            Password = password,
            NickName = nickname,
            Coin = 10000
        };
        userDict.Add(user.Username, user);
        //注册成功
        return 0;
    }
    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public int Login(string username, string password)
    {
        if (userDict.ContainsKey(username))
        {
            User user = userDict[username];
            if (user.Password == password)
            {
                CurrentUser = user;
                //登录成功
                return 0;
            }
            else
            {
                //用户或密码错误
                return -2;
            }
        }
        else
        {
            // 用户不存在
            return -1;
        }
    }
    public int CaculateReward(int coin)
    {
        int temp= coin / 10 ;
        if (temp >=1000)
        {
            temp += (coin - 1000) / 5;
        }
        CurrentUser.Coin += temp;
        return temp;
    }
    public void Deinitialize()
    {
        userDict.Clear();
    }
    /// <summary>
    /// 给用户添加装备
    /// </summary>
    /// <param name="goods"></param>
    /// <returns></returns>
    public int BuyEquipToUser(Goods goods)
    {
        Equip equip = new Equip()
        {
            EquipName = goods.EquipName,
            Price = goods.Price,
            Icon = goods.Icon,
            Info = goods.Info,
            SpeedValue = goods.SpeedValue,
            BloodValue = goods.BloodValue,
            Count = 0,
            EquipType = goods.EquipType
        };
        return CurrentUser.BuyEquip(equip);
    }
    /// <summary>
    /// 出售装备
    /// </summary>
    /// <param name="goods"></param>
    /// <returns></returns>
    public int SellEquipToUser(Goods goods)
    {
        Equip equip = new Equip()
        {
            EquipName = goods.EquipName,
            Price = goods.Price,
            Icon = goods.Icon,
            Info = goods.Info,
            SpeedValue = goods.SpeedValue,
            BloodValue = goods.BloodValue,
            Count = 0,
            EquipType = goods.EquipType
        };
        return CurrentUser.SellEquip(equip);
    }
    /// <summary>
    /// 使用装备
    /// </summary>
    /// <param name="goods"></param>
    /// <returns></returns>
    public int UseEquipToUser(Goods goods)
    {
        Equip equip = new Equip()
        {
            EquipName = goods.EquipName,
            Price = goods.Price,
            Icon = goods.Icon,
            Info = goods.Info,
            SpeedValue = goods.SpeedValue,
            BloodValue = goods.BloodValue,
            Count = 0,
            EquipType = goods.EquipType
        };
        return CurrentUser.UseEquip(equip);
    }
    /// <summary>
    /// 通过装备的名字得到装备的数量
    /// </summary>
    /// <param name="equipName"></param>
    /// <returns></returns>
    public int GetEquipByEquipNameBag(string equipName)
    {
        return CurrentUser.GetCountEquipName(equipName);
    }       
}
