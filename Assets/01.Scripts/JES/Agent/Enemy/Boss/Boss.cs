using System;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;
using System.Linq;

public class Boss : MonoBehaviour
{
    public BossDataSO enemyData;
    
    
    [field: SerializeField] public bool IsFacingRight { get; private set; } = true;
    private Dictionary<Type,IBossComponent> _components;

    private int _fazeNum = 1;
    public event Action<int> FazeNumChangeEvent;
    
    private BehaviorTree _bt;
    private SharedBool _animTrigger;
    public Health healthCompo { get; private set; }
    public DamageCaster damageCaster { get; private set; }
    private void Awake()
    {
        _components = new Dictionary<Type, IBossComponent>();
        
        GetComponentsInChildren<IBossComponent>().ToList().ForEach(compo => _components.Add(compo.GetType(), compo));
        
        _components.Values.ToList().ForEach(compo => compo.Initialize(this));

        healthCompo = GetComponent<Health>();
        damageCaster = GetComponentInChildren<DamageCaster>();
        
        _bt = GetComponent<BehaviorTree>();
        _animTrigger = _bt.GetVariable("animTrigger") as SharedBool;
        
    }

    public T GetCompo<T>() where T : class
    {
        if(_components.TryGetValue(typeof(T),out IBossComponent compo))
        {
            return compo as T;
        }
        
        return default;
    }

    public void Faze2Set()
    {
       var num = _bt.GetVariable("FazeNum") as SharedInt;
       num.Value = 2;
       _fazeNum = 2;
       FazeNumChangeEvent?.Invoke(_fazeNum);
    }

    public void Flip()
    {
        if(IsFacingRight)
            transform.rotation = Quaternion.Euler(0,180f,0);
        else
            transform.rotation = Quaternion.identity;
        IsFacingRight = !IsFacingRight;
    }

    public void AnimationTrigger()
    {
        _animTrigger.Value = true;
    }
}

public class SharedEnemy : SharedVariable<Boss>
{
    public static implicit operator SharedEnemy(Boss value)
    {
        return new SharedEnemy {Value = value};
    }
}
