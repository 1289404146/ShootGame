using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBagPanel : BaseShopBagPanel
{
    private Button useButton;
    protected override void Awake()
    {
        base.Awake();
        useButton = transform.Find("Bg/UseButton").GetComponent<Button>();
    }
    protected override void Start()
    {
        base.Start();
        useButton.onClick.AddListener(UseButtonClick);
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
        else
        {
            useButton.interactable = false;
        }
    }
    public override GameObject AddItem(GameObject itemPrefab, Equip equip)
    {
        GameObject item = base.AddItem(itemPrefab, equip);
        Goods goods = item.GetComponent<Goods>();
        goods.SetCountLableActive(true);
        goods.SetCountLabel(equip.Count);
        return item;
    }
    private void UseButtonClick()
    {
        int ret = YLDataManager.Instance.UseEquipToUser(selectGoods);
        if (ret == 0)
        {
            if (YLDataManager.Instance.CurrentUser.GetUserBagEquipList.Count <= 0)
            {
                Destroy(selectGoods.gameObject);
                useButton.interactable = false;
            }
            else
            {
                int count= (YLDataManager.Instance.GetEquipByEquipNameBag(selectGoods.name));
                if (count >= 0)
                {
                    selectGoods.SetCountLabel(count);
                }
                useButton.interactable = true;
            }
        }

    }

    protected override void CloseButtonClick()
    {
        base.CloseButtonClick();
        YLUIManager.Instance.ClosePanel<GameBagPanel>();
    }


}
