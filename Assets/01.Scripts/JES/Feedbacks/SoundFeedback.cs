using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFeedback : Feedback
{
    [SerializeField] private SoundSO _soundData;
    public override void PlayFeedback()
    {
        SoundPlayer soundPlayer = PoolManager.Instance.Pop("SoundPlayer") as SoundPlayer;
        soundPlayer.PlaySound(_soundData);
    }

    public override void StopFeedback()
    {
        
    }
}
