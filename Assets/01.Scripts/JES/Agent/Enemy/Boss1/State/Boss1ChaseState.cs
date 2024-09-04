using UnityEngine;

public class Boss1ChaseState : EnemyState
{
    public Boss1ChaseState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();

        
        Vector2 dir = (_enemy.targerTrm.position - _enemy.transform.position);
        float dis = dir.magnitude;
        
        _enemy.MovementCompo.SetMoveMent(Mathf.Sign(dir.x));

        if (_enemy.attackRadius > dis)
        {
            if (((Boss)_enemy).faseNum == 1)
            {
                if(_enemy.lastAttackTime + _enemy.attackCooldown < Time.time)
                    _stateMachine.ChangeState(EnemyEnum.Attack1);
            }
            else if (((Boss)_enemy).faseNum == 2)
            {
                Boss1DataSO data = ((Boss1)_enemy).gunData;
                if (!data.gun.ReloadCheck())//장전 해야하는지 안하는지
                {
                    if (data.gun.TryShot())// 쿨타임이 돌았는지
                    {
                        _stateMachine.ChangeState(data.attackEnum);
                    }  
                }
                else
                {
                    data.gun.Reload();
                    _stateMachine.ChangeState(data.reloadEnum);
                }
            }
        }
    }
}