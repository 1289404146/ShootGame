using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : YLBasePanel
{
    private Image bloodPre;
    private Text bloodText;
    private Text coinText;
    private Text nicknameText;
    private Button bagButton;
    private Button settingButton;
    private Button exitButton;


    private void Awake()
    {
        coinText = transform.Find("Bg/CoinText").GetComponent<Text>();
        nicknameText = transform.Find("Bg/NicknameText").GetComponent<Text>();
        bagButton = transform.Find("Bg/BagButton").GetComponent<Button>();
        settingButton = transform.Find("Bg/SettingButton").GetComponent<Button>();
        exitButton = transform.Find("Bg/ExitButton").GetComponent<Button>();
        bloodPre = transform.Find("Bg/BloodBg/BloodPre").GetComponent<Image>();
        bloodText = transform.Find("Bg/BloodBg/BloodText").GetComponent<Text>();
    }
    protected override void Start()
    {
        base.Start();
        nicknameText.text = YLDataManager.Instance.CurrentUser.NickName;
        bagButton.onClick.AddListener(BagButtonClick);
        exitButton.onClick.AddListener(ExitButtonClick);
        settingButton.onClick.AddListener(SettingButonClick);
        ///初始化金币
        UpdateCoin(0);
    }
    /// <summary>
    /// 局内设置点击事件
    /// </summary>
    private void SettingButonClick()
    {
        YLUIManager.Instance.OpenPanel<SettingPanel>();
    }
    /// <summary>
    /// 退出游戏点击事件
    /// </summary>
    private void ExitButtonClick()
    {
        YLSingleton<Game>.Instance.DeIntialize();
        YLScenesManager.Instance.LoadScene(SceneType.Main);
    }
    /// <summary>
    /// 局内背包点击事件
    /// </summary>
    private void BagButtonClick()
    {
        YLUIManager.Instance.OpenPanel<GameBagPanel>();
    }
    /// <summary>
    /// 更新晚间血量
    /// </summary>
    /// <param name="currentHp"></param>
    /// <param name="maxHp"></param>
    public void UpdateHp(int currentHp, int maxHp)
    {
        bloodPre.fillAmount = currentHp * 1.0f / maxHp;
        bloodText.text = string.Format("{0}/{1}", currentHp, maxHp);
    }
    public void UpdateCoin(int coin)
    {
        coinText.text = string.Format("金币:{0}",coin);
    }
}
