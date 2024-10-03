using System;
using EasySave.Json;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveBtn : MonoBehaviour
{
    [Header("UI")] 
    [SerializeField] private TextMeshProUGUI _mainTex;
    [SerializeField] private TextMeshProUGUI _timeTex;

    private SaveData _saveData;

    public string SaveSlot = "SaveData";

    private void Start()
    {
        if (!EasyToJson.IsExistJson(SaveSlot))
        {
            _mainTex.text = "Empty Slot";
            _timeTex.text = "";
            return;
        }
        _saveData = EasyToJson.FromJson<SaveData>(SaveSlot);
        _mainTex.text = $"{_saveData.stageNumber} / 5";
        TimeSpan timeSpan = TimeSpan.FromSeconds(_saveData.playTime);
        _timeTex.text = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
    }

    public void BtnClick()
    {
        SaveManager.Instance.SetDataPath(SaveSlot,_saveData);
        SceneManager.LoadScene(_saveData.currentScene);
    }
}
