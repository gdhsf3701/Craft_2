using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SkillCoolUI : MonoSingleton<SkillCoolUI>
{
    [SerializeField] private Image normalAttack1,normalAttack2,comboImage;
    [SerializeField] private List<Sprite> attackSprites;
    [SerializeField] private Image kickUI,knifeUI;

    private void Start()
    {
        SkillManager.Instance.GetSkill<KickSkill>().OnCooldownEvent += HandleKickUICool;
        SkillManager.Instance.GetSkill<KnifeSkill>().OnCooldownEvent += HandleKnifeUICool;
    }

    private void HandleKnifeUICool(float current, float total)
    {
        knifeUI.fillAmount = current / total;
    }

    private void HandleKickUICool(float current, float total)
    {
        kickUI.fillAmount = current/total;
    }

    private Tween _tween;
    public void NormalAttackCoolStart(float timer)
    {
        normalAttack1.fillAmount = 1;
        normalAttack1.DOFillAmount(0,timer);
    }

    public void NormalAttackSprite(int index)
    {
        normalAttack1.sprite = attackSprites[index];
        normalAttack2.sprite = attackSprites[index];
    }

    public void ComboImageSetUp()
    {
        _tween.Kill();
        comboImage.fillAmount = 0;
    }

    public void ComboCooldown()
    {
        _tween= comboImage.DOFillAmount(1f, 0.7f);
    }
}
