using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : BaseShopBagPanel
{
    private Button buyButton;
    protected override void Awake()
    {
        base.Awake();
        buyButton = transform.Find("Bg/BuyButton").GetComponent<Button>();
    }
    protected override void Start()
    {
        base.Start();
        buyButton.onClick.AddListener(BuyButtonClick);

        foreach (Equip equip in YLDataManager.Instance.GetEquipList)
        {
            AddItem(itemPrefab, equip);
        }
        content.GetChild(0).GetComponent<Toggle>().isOn = true;
        selectGoods = content.GetChild(0).GetComponent<Goods>();
        SetInfoImage();
    }

    public override GameObject AddItem(GameObject itemPrefab, Equip equip)
    {
        GameObject item = base.AddItem(itemPrefab, equip);
        item.GetComponent<Goods>().SetCountLableActive(false);
        return item;
    }

    private void BuyButtonClick()
    {
        int ret= YLDataManager.Instance.BuyEquipToUser(selectGoods);
        if (ret == 0)
        {
            //TODO购买成功界面
            Debug.Log("购买成功");
        }
        else if (ret == -1)
        {
            //TODO金币不足界面
            Debug.Log("金币不足");
        }
        else
        {
            //TODO购买失败界面
            Debug.Log("购买失败");
        }
        YLUIManager.Instance.GetPanel<MainPanel>().UpdateCoin();
    }
    protected override void CloseButtonClick()
    {
        base.CloseButtonClick();
        YLUIManager.Instance.ClosePanel<ShopPanel>();
    }

}
