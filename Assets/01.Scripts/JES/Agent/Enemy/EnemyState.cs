using UnityEngine;

public abstract class EnemyState
{
    protected Enemy _enemy;
    protected EnemyStateMachine _stateMachine;

    protected int _animBoolHash;
    protected bool _endTriggerCalled;

    public EnemyState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName)
    {
        _enemy = enemy;
        _stateMachine = stateMachine;
        _animBoolHash = Animator.StringToHash(animBoolName);
    }

    public virtual void UpdateState()
    {
        
    }

    public virtual void Enter()
    {
        _enemy.AnimatorCompo.SetBool(_animBoolHash, true);
        _endTriggerCalled = false;
    }

    public virtual void Exit()
    {
        _enemy.AnimatorCompo.SetBool(_animBoolHash, false);
    }

    public void AnimationEndTrigger()
    {
        _endTriggerCalled = true;
    }
}
