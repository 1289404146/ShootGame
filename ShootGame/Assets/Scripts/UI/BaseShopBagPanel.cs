using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseShopBagPanel : YLBasePanel
{
    protected Button closeButton;
    protected Transform content;
    protected Transform infoImage;
    protected Text equipNameText;
    protected Text equipPriceText;
    protected Text equipDetailText;
    protected ToggleGroup toggleGroup;
    protected GameObject itemPrefab;
    protected Goods selectGoods;
    protected virtual void Awake()
    {
        content = transform.Find("Bg/ScrollView/Viewport/Content");
        infoImage = transform.Find("Bg/InfoImage");
        equipNameText = infoImage.Find("EquipNameText").GetComponent<Text>();
        equipPriceText = infoImage.Find("EquipPricesText").GetComponent<Text>();
        equipDetailText = infoImage.Find("EquipDetailText").GetComponent<Text>();
        closeButton = transform.Find("Bg/CloseButton").GetComponent<Button>();
        toggleGroup = content.GetComponent<ToggleGroup>();
    }

    protected override void Start()
    {
        base.Start();
        closeButton.onClick.AddListener(CloseButtonClick);
        itemPrefab = Resources.Load<GameObject>("UI/Item");
    }
    public virtual GameObject AddItem(GameObject itemPrefab, Equip equip)
    {
        GameObject item = GameObject.Instantiate(itemPrefab);
        item.transform.SetParent(content);
        Goods goods= item.AddComponent<Goods>();
        goods.ChangeSelectItem = ChangeSelect;
        item.name = equip.EquipName;
        goods.SetDate(equip);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
        item.transform.localScale = Vector3.one;
        Image image = item.transform.Find("Background").GetComponent<Image>();
        image.sprite = Resources.Load<Sprite>(equip.Icon);
        item.GetComponent<Toggle>().group = toggleGroup;
        return item;
    }
    public virtual void SetInfoImage()
    {
        equipNameText.text = selectGoods.EquipName;
        equipDetailText.text = selectGoods.Info;
        equipPriceText.text = selectGoods.Price.ToString();
    }
    protected void ChangeSelect(Goods goods)
    {
        selectGoods = goods;
        SetInfoImage();
    }
    protected virtual void CloseButtonClick()
    {
    }
  
}
