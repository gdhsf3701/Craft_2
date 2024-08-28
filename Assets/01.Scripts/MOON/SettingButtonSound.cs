using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButtonSound : MonoBehaviour
{
    [SerializeField] SoundSO sound;

    public void ButtonSound()
    {
        SoundPlayer soundPlayer = PoolManager.Instance.Pop("SoundPlayer") as SoundPlayer;
        soundPlayer.PlaySound(sound);
    }
}
