using System;
using DG.Tweening;
using UnityEngine;

public class AfterImage : MonoBehaviour,Ipoolable
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private string _poolName = "AfterImage";
    
    public string PoolName => _poolName;
    public GameObject ObjectPrefab => gameObject;
    public void ResetItem()
    {
        _spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetAfterImage(Sprite sprite, Vector3 position, float fadeTime,bool isFlip)
    {
        transform.position = position;
        _spriteRenderer.sprite = sprite;
        _spriteRenderer.flipX = isFlip;
        _spriteRenderer.DOFade(0f, fadeTime).OnComplete(() => PoolManager.Instance.Push(this));
    }
}