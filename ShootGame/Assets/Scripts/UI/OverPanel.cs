using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverPanel : YLBasePanel
{
    private Text rewardText;
    private Button confirmButton;
    private void Awake()
    {
        rewardText = transform.Find("Bg/Info/RewardText").GetComponent<Text>();
        confirmButton = transform.Find("Bg/Info/ConfirmButton").GetComponent<Button>();
    }
    protected override void Start()
    {
        base.Start();
        confirmButton.onClick.AddListener(ConfirmButtonClick);
    }
    public void SetRewardText(int coin)
    {
        rewardText.text = string.Format("{0}金币",coin);
    }
    private void ConfirmButtonClick()
    {
        //YLDataManager.Instance.
        YLScenesManager.Instance.LoadScene(SceneType.Main);
    }
}
