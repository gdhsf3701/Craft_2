using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManger : MonoBehaviour
{
    [SerializeField] private SoundSO _bgmSO;

    private void Start()
    {
        SoundPlayer soundPlayer = PoolManager.Instance.Pop("SoundPlayer") as SoundPlayer;
        soundPlayer.PlaySound(_bgmSO);
    }
}
