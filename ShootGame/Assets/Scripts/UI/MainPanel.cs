using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : YLBasePanel
{
    private Button gameButton;
    private Button bagButton;
    private Button shopButton;
    private Button settingButton;
    private Button backButton;
    private Text nicknameText;
    private Text coinText;


    private void Awake()
    {
        nicknameText = transform.Find("Bg/NicnameText").GetComponent<Text>();
        coinText = transform.Find("Bg/CoinText").GetComponent<Text>();
        gameButton = transform.Find("Bg/GameButton").GetComponent<Button>();
        bagButton = transform.Find("Bg/BagButton").GetComponent<Button>();
        shopButton = transform.Find("Bg/ShopButton").GetComponent<Button>();
        settingButton = transform.Find("Bg/SettingButton/").GetComponent<Button>();
        backButton = transform.Find("Bg/BackButton").GetComponent<Button>();
       
    }
    protected override void Start()
    {
        base.Start();
        gameButton.onClick.AddListener(GameButtonClick);
        bagButton.onClick.AddListener(BagButtonClick);
        shopButton.onClick.AddListener(ShopButtonClick);
        settingButton.onClick.AddListener(SettingButtonClick);
        backButton.onClick.AddListener(BackButtonClick);
        nicknameText.text = YLDataManager.Instance.CurrentUser.NickName;
        UpdateCoin();
    }
    public void UpdateCoin()
    {
        coinText.text = "金币" + YLDataManager.Instance.CurrentUser.Coin.ToString();
    }
    /// <summary>
    /// 返回到Login场景
    /// </summary>
    private void BackButtonClick()
    {
        YLScenesManager.Instance.LoadScene(SceneType.Login);
        YLSingleton<Main>.Instance.DeIntialize();
    }

    private void SettingButtonClick()
    {
        YLUIManager.Instance.OpenPanel<SettingPanel>();
    }

    private void ShopButtonClick()
    {
        YLUIManager.Instance.OpenPanel<ShopPanel>();
    }

    private void BagButtonClick()
    {
        YLUIManager.Instance.OpenPanel<BagPanel>();
    }
    /// <summary>
    /// 进入游戏点击事件
    /// </summary>
    private void GameButtonClick()
    {
        YLScenesManager.Instance.LoadScene(SceneType.Game);
        YLSingleton<Main>.Instance.DeIntialize();
    }
}
