using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : YLBasePanel
{
    private Button closeButton;
    private Slider bgmSlider;
    private Slider effectSlider;
    private Toggle bgmToggle;
    private Toggle effectToggle;
    private void Awake()
    {
        closeButton = transform.Find("Bg/CloseButton").GetComponent<Button>();
        bgmSlider = transform.Find("Bg/BGMSlider").GetComponent<Slider>();
        effectSlider = transform.Find("Bg/EffectSlider").GetComponent<Slider>();
        bgmToggle = transform.Find("Bg/BGMToggle").GetComponent<Toggle>();
        effectToggle = transform.Find("Bg/EffectToggle").GetComponent<Toggle>();
    }
    protected override void Start()
    {
        base.Start();
        closeButton.onClick.AddListener(CloseButtonClick);

        bgmSlider.value = YLAudioSourceManager.Instance.GetBGMVolume();
        bgmToggle.isOn = YLAudioSourceManager.Instance.GetBGMMute();
        effectSlider.value = YLAudioSourceManager.Instance.GetEffectVolume();
        effectToggle.isOn = YLAudioSourceManager.Instance.GetEffetMute();

        bgmSlider.onValueChanged.AddListener(BGMSliderChanged);
        effectSlider.onValueChanged.AddListener(EffectSliderChanged);
        bgmToggle.onValueChanged.AddListener(BGMToggleChanged);
        effectToggle.onValueChanged.AddListener(EffectToggleChanged);
    }

    private void EffectToggleChanged(bool mute)
    {
        YLAudioSourceManager.Instance.SetEffectMute(mute);
    }

    private void BGMToggleChanged(bool mute)
    {
        YLAudioSourceManager.Instance.SetBGMMute(mute);
    }

    private void EffectSliderChanged(float volume)
    {
        YLAudioSourceManager.Instance.SetEffectVolume(volume);
    }

    private void BGMSliderChanged(float volume)
    {
        YLAudioSourceManager.Instance.SetBgVolume(volume);
    }

    /// <summary>
    /// 关闭设置面板
    /// </summary>
    private void CloseButtonClick()
    {
        YLUIManager.Instance.ClosePanel<SettingPanel>();
    }
}
