using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManger : MonoSingleton<BgmManger>
{
    [SerializeField] private SoundSO _bgmSO;
    [SerializeField] private SoundSO _bgmSO2;
    private SoundPlayer _soundPlayer;
    private void Start()
    {
        BGMStart();
    }

    public void BGMStop()
    {
        _soundPlayer.StopAndGoToPool();
    }
    public void BGMStart()
    {
        _soundPlayer = PoolManager.Instance.Pop("SoundPlayer") as SoundPlayer;
        _soundPlayer.PlaySound(_bgmSO);
    }
    public void BGM2Start()
    {
        _bgmSO = _bgmSO2;
        BGMStart();
    }
}
