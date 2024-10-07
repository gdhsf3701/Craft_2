using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _sfxSl, _bgmSl;
    private void Start()
    {
        _sfxSl.value = SaveManager.Instance.ReturnSFXVolume();
        _bgmSl.value = SaveManager.Instance.ReturnBGMVol();
    }

    public void SetMusicVolume(float volume)
    {
        _audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }
    public void SetSFXVolume(float volume)
    {
        _audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }
}
