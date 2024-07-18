using Cinemachine;
using UnityEngine;


[RequireComponent(typeof(CinemachineImpulseSource))]
public class ImpulseFeedback : Feedback
{
    [SerializeField] private float _impulsePower = 0.3f;
    private CinemachineImpulseSource _source;

    private void Awake()
    {
        _source = GetComponent<CinemachineImpulseSource>();
    }

    public override void PlayFeedback()
    {
            _source.GenerateImpulse(_impulsePower);
    }

    public override void StopFeedback()
    {
        
    }
}
