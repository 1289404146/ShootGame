using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YLAudioSourceManager : YLUnitySingleton<YLAudioSourceManager>, IBaseManager
{
    /// <summary>
    /// 背景音乐
    /// </summary>
    private AudioSource bgmAudioSourcee;
    /// <summary>
    /// 音效的大小
    /// </summary>
    private float effectVolume;
    /// <summary>
    /// 音效是否静音
    /// </summary>
    private bool effectMute;
    private void Awake()
    {
        bgmAudioSourcee = GetComponent<AudioSource>();
    }
    public void Initailize()
    {
        bgmAudioSourcee.volume = 0.1f;
        bgmAudioSourcee.mute = false;
        effectVolume = 0.6f;
        effectMute = false;
    }
    /// <summary>
    /// 设置背景音乐的大小
    /// </summary>
    /// <param name="volume"></param>
    public void SetBgVolume(float volume)
    {
        bgmAudioSourcee.volume = volume;
    }
    /// <summary>
    /// 获取背景音乐大小
    /// </summary>
    /// <returns></returns>
    public float GetBGMVolume()
    {
        return bgmAudioSourcee.volume;
    }
    /// <summary>
    /// 设置背景音乐是否静音
    /// </summary>
    /// <param name="mute"></param>
    public void SetBGMMute(bool mute)
    {
        bgmAudioSourcee.mute = mute;
        bgmAudioSourcee.Play();
    }
    /// <summary>
    /// 获取背景音乐是否静音
    /// </summary>
    /// <returns></returns>
    public bool GetBGMMute()
    {
        return bgmAudioSourcee.mute;
    }
    /// <summary>
    /// 设置音效大小
    /// </summary>
    /// <param name="volume"></param>
    public void SetEffectVolume(float volume)
    {
        effectVolume = volume;
    }
    /// <summary>
    /// 获得音效的大小
    /// </summary>
    /// <returns></returns>
    public float GetEffectVolume()
    {
        return effectVolume;
    }
    /// <summary>
    /// 设置音效静音
    /// </summary>
    /// <param name="mute"></param>
    public void SetEffectMute(bool mute)
    {
        effectMute = mute;
    }
    /// <summary>
    /// 获得音效是否静音
    /// </summary>
    /// <returns></returns>
    public bool GetEffetMute()
    {
        return effectMute;
    }
    /// <summary>
    /// 设置
    /// </summary>
    /// <param name="audioSource"></param>
    /// <param name="audioClip"></param>
    public void SetEffectVolume(AudioSource audioSource, string audioClipName)
    {
        AudioClip audioClip= GetAudioClip(audioClipName);
        audioSource.volume = effectVolume;
    }
    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="audioSource"></param>
    /// <param name="audioclipName"></param>
    public void Play(AudioSource audioSource, string audioclipName)
    {
        AudioClip audioClip = GetAudioClip(audioclipName);
        if (audioClip == null)
        {
            Debug.Log("音乐片段不存在");
            return;
        }
        audioSource.clip = audioClip;
        audioSource.volume = effectVolume;
        audioSource.mute = effectMute;
        audioSource.Play();
    }
    /// <summary>
    /// 播放一次
    /// </summary>
    /// <param name="audioSource"></param>
    /// <param name="audioclipName"></param>
    public void PlayOnce(AudioSource audioSource,string audioclipName)
    {
        if (audioSource.isPlaying)
        {
            return;
        }
        Play(audioSource, audioclipName);
    }
    /// <summary>
    /// 获取音效片段
    /// </summary>
    /// <param name="audioClipName"></param>
    /// <returns></returns>
    private AudioClip GetAudioClip(string audioClipName )
    {
        return Resources.Load<AudioClip>(audioClipName);
    }
    public void Deinitialize()
    {
    }
}
