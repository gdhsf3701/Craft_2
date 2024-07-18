using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SkillCoolUI : MonoSingleton<SkillCoolUI>
{
    [SerializeField] private Image normalAttack,comboImage;
    [SerializeField] private List<Sprite> attackSprites;

    private Tween _tween;
    public void NormalAttackCoolStart(float timer)
    {
        normalAttack.fillAmount = 0;
        normalAttack.DOFillAmount(1,timer);
    }

    public void NormalAttackSprite(int index)
    {
        normalAttack.sprite = attackSprites[index];
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
