using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public float PlayTime { get; private set; }

    private void Start()
    {
        PlayTime = SaveManager.Instance.saveData.playTime;
    }

    private void Update()
    {
        PlayTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.B))
        {
            SaveManager.Instance.SavingData();
        }
    }
}
