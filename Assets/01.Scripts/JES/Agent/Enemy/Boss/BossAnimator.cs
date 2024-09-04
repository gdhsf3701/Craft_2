using UnityEngine;

public class BossAnimator : MonoBehaviour,IBossComponent
{
    private Boss _enemy;
    private Animator _animator;
    private readonly int _moveSpeedHash = Animator.StringToHash("moveSpeed");
    private readonly int _attackTriggerhash = Animator.StringToHash("attack");
    private readonly int _atkIndexHash = Animator.StringToHash("atkIndex");
    public void Initialize(Boss enemy)
    {
        _enemy = enemy;
        _animator = GetComponent<Animator>();

        _enemy.GetCompo<BossMovement>().VelocityChangeEvnet += HandleVelocityChange;
        _enemy.GetCompo<BossAttack>().AttackStartEvent += HandleAttackStart;
    }

    private void HandleAttackStart(int obj)
    {
        _animator.SetInteger(_atkIndexHash,obj);
        _animator.SetTrigger(_attackTriggerhash);
    }

    private void HandleVelocityChange(Vector2 velocity)
    {
        _animator.SetFloat(_moveSpeedHash,velocity.sqrMagnitude);
    }

    private void AnimaionEnd() => _enemy.AnimationTrigger();
}