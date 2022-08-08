using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagPanel : BaseShopBagPanel
{
    private Button sellButton;
    protected override void Awake()
    {
        base.Awake();
        sellButton = transform.Find("Bg/SellButton").GetComponent<Button>();
    }
    protected override void Start()
    {
        base.Start();
        sellButton.onClick.AddListener(SellButtonClick);
        if (YLDataManager.Instance.CurrentUser.GetUserBagEquipList.Count > 0)
        {
            foreach (Equip equip in YLDataManager.Instance.CurrentUser.GetUserBagEquipList)
            {
                AddItem(itemPrefab, equip);
            }
            content.GetChild(0).GetComponent<Toggle>().isOn = true;
            selectGoods = content.GetChild(0).GetComponent<Goods>();
            SetInfoImage();
        }
    }
    public override GameObject AddItem(GameObject itemPrefab, Equip equip)
    {
        GameObject item= base.AddItem(itemPrefab, equip);
        Goods goods= item.GetComponent<Goods>();
        goods.SetCountLableActive(true);
        goods.SetCountLabel(equip.Count);
        return item;
    }
    private void SellButtonClick()
    {
        YLDataManager.Instance.SellEquipToUser(selectGoods);
        YLUIManager.Instance.GetPanel<MainPanel>().UpdateCoin();
    }
    protected override void CloseButtonClick()
    {
        base.CloseButtonClick();
        YLUIManager.Instance.ClosePanel<BagPanel>();
    }
}
