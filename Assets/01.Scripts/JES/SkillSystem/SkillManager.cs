using System;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    Dash
}
public class SkillManager : MonoSingleton<SkillManager>
{
    private Dictionary<Type, Skill> _skills;
    private Player _player;

    private void Awake()
    {
        _skills = new Dictionary<Type, Skill>();
    }

    private void Start()
    {
        _player = PlayerManager.Instance.Player;
        foreach (SkillType skillType in Enum.GetValues(typeof(SkillType)))
        {
            Skill skillCompo = GetComponent($"{skillType.ToString()}Skill") as Skill;
            skillCompo.Initialize(_player);
            Type type = skillCompo.GetType();
            
            _skills.Add(type,skillCompo);
        }
    }

    public T GetSkill<T>() where T : Skill
    {
        Type t = typeof(T);
        if (_skills.TryGetValue(t, out Skill targetSkill))
        {
            return targetSkill as T;
        }

        return null;
    }
}