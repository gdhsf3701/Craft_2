using System;
using UnityEngine;

public class WalkSoundTrigger : MonoBehaviour
{
    [SerializeField] private SoundSO right, left;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerManager.Instance.Player.SetWalkSound(right, left);
    }
}