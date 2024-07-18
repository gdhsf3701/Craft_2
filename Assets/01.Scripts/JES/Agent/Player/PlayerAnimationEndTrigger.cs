using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEndTrigger : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void AnimationEndTrigger()
    {
        _player.AnimationEndTrigger();
    }
 
    private void AnimationAttackTrigger()
    {
        _player.Attack();
    }
}
