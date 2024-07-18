using UnityEngine;

public class PlayEffectFeedback : Feedback
{
    [SerializeField] private string _effectName;
    public override void PlayFeedback()
    {
        EffectPlayer effect = PoolManager.Instance.Pop(_effectName) as EffectPlayer;
        effect.SetPositionAndPlay(transform.position);
    }

    public override void StopFeedback()
    {
        
    }
}
