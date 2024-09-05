using UnityEngine;

public class BossAnimator : MonoBehaviour,IBossComponent
{
    private Boss _enemy;
    private Animator _animator;
    private readonly int _fazeNumHash = Animator.StringToHash("fazeNum");
    private readonly int _attackTriggerhash = Animator.StringToHash("attack");
    private readonly int _sturnTriggerhash = Animator.StringToHash("sturn");
    private readonly int _reloadTriggerhash = Animator.StringToHash("reloadTrigger");
    private readonly int _atkIndexHash = Animator.StringToHash("atkIndex");
    private readonly int _reloadHash = Animator.StringToHash("reload");
    public void Initialize(Boss enemy)
    {
        _enemy = enemy;
        _animator = GetComponent<Animator>();

        _enemy.FazeNumChangeEvent += HandleFazeNumChange;
        _enemy.GetCompo<BossAttack>().AttackStartEvent += HandleAttackStart;
    }

    public void ReloadAnimation(int index)
    {
        _animator.SetInteger(_reloadHash,index);
        _animator.SetTrigger(_reloadTriggerhash);
    }
    private void HandleAttackStart(int obj)
    {
        _animator.SetInteger(_atkIndexHash,obj);
        _animator.SetTrigger(_attackTriggerhash);
    }

    public void SturnAnimStart()
    {
        _animator.SetTrigger(_sturnTriggerhash);
    }

    private void HandleFazeNumChange(int num)
    {
        _animator.SetInteger(_fazeNumHash,num);
    }

    private void AnimaionEnd() => _enemy.AnimationTrigger();

    private void Attack()
    {
        _enemy.damageCaster.CastDamage(1, _enemy.enemyData.knockbackPower);
    }
}