using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private float _saveCoolTime=30f;
    private float _curTime = 0;
    private void Update()
    {
        _curTime += Time.deltaTime;
        if (_curTime >= _saveCoolTime)
        {
            SaveManager.Instance.SetTime(_curTime);
            _curTime = 0;
        }
    }
}
