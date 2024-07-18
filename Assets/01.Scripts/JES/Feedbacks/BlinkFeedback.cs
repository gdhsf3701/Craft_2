using System.Collections;
using UnityEngine;

public class BlinkFeedback : Feedback
{
    [SerializeField] private SpriteRenderer _targetRenderer;
    [SerializeField] private float _flashTime = 0.1f;

    private Material _targetMat;

    private readonly int _isHitHash = Shader.PropertyToID("_IsHit");

    private void Awake() 
    {
        //스프라이트 렌더러에 있는 매티리얼을 가져온다.
        _targetMat = _targetRenderer.material; 
    }

    public override void PlayFeedback()
    {        
        _targetMat.SetInt(_isHitHash, 1);
        StartCoroutine(DelayBlink());
    }

    private IEnumerator DelayBlink()
    {
        yield return new WaitForSeconds(_flashTime);
        _targetMat.SetInt(_isHitHash, 0);
    }

    public override void StopFeedback()
    {
        StopAllCoroutines(); //내 모노비해비어에 돌고 있는 모든 코루틴 종료
        _targetMat.SetInt(_isHitHash, 0);
    }
}