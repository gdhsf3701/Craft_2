using UnityEngine;

public class EnemyVFX : MonoBehaviour
{
    [SerializeField] private bool _canGenerateAfterImage;
    [SerializeField]
    private float _generateTerm;

    private float _currentTime;
    private Enemy _enemy;
    public void Initalize(Enemy enemy)
    {
        _enemy = enemy;
    }
    public void ToggleAfterImage(bool value)
    {
        _canGenerateAfterImage = value;
    }

    private void Update()
    {
        if(!_canGenerateAfterImage) return;

        _currentTime += Time.deltaTime;
        if (_currentTime >= _generateTerm)
        {
            _currentTime = 0;
            AfterImage img =PoolManager.Instance.Pop("AfterImage") as AfterImage;
            //Sprite sprite= _enemy.EnemySpriteRender.sprite;
            bool isFlip = !_enemy.IsFacingRight();
            //
            //img.SetAfterImage(sprite,transform.position,0.2f,isFlip);
        }
    }
}