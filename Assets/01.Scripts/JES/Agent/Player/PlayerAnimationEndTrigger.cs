using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAnimationEndTrigger : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SoundSO _moveRightSound,_moveLeftSound;
    private void AnimationEndTrigger()
    {
        _player.AnimationEndTrigger();
    }

    public void SetWalkSound(SoundSO right, SoundSO left)
    {
        _moveRightSound = right;
        _moveLeftSound = left;
    }
    private void AnimationAttackTrigger()
    {
        _player.AttackSetting();
    }

    private void AnimationSKillTrigger()
    {
        _player.CastDamage();
    }

    private void MoveRightSoundPlayTrigger()
    {
        SoundPlayer soundPlayer = PoolManager.Instance.Pop("SoundPlayer") as SoundPlayer;
        soundPlayer.PlaySound(_moveRightSound);
    }
    private void MoveLeftSoundPlayTrigger()
    {
        SoundPlayer soundPlayer = PoolManager.Instance.Pop("SoundPlayer") as SoundPlayer;
        soundPlayer.PlaySound(_moveLeftSound);
    }
}
