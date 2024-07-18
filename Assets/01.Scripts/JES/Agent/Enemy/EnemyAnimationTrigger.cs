using UnityEngine;

public class EnemyAnimationTrigger : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private void AnimaionEndTrigger()
    {
        _enemy.AnimationEndTrigger();
    }
    private void AnimaionAttackTrigger()
    {
        _enemy.Attack();
    }
}
