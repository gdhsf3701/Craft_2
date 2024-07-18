using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingUI : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private InputReader _playerInput;

    public void SetMusicVolume(float volume)
    {
        _audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }
    public void SetSFXVolume(float volume)
    {
        _audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

    public void RightPlayer()
    {
        _playerInput._controls.RightPlayer.Enable();
        _playerInput._controls.LeftPlayer.Disable();
    }
    public void LeftPlayer()
    {
        _playerInput._controls.RightPlayer.Disable();
        _playerInput._controls.LeftPlayer.Enable();
    }
}
