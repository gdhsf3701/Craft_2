using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class SaveBtn : MonoBehaviour
{
    [Header("UI")] 
    [SerializeField] private TextMeshProUGUI _mainTex;
    [SerializeField] private TextMeshProUGUI _dateTex;
    [SerializeField] private TextMeshProUGUI _timeTex;

    private SaveData _saveData;

    public string SaveSlot = "SaveData";

    private void Start()
    {
        string path = SaveManager.Instance.GetFilePath(SaveSlot);
        if (!File.Exists(path))
        {
            _mainTex.text = "Empty Slot";
            _dateTex.text = "";
            _timeTex.text = "";
            return;
        }
        _saveData = SaveManager.Instance.JsonToData(SaveSlot);
        _mainTex.text = $"{_saveData.StageNumber} / 5";
        _dateTex.text = _saveData.playDate;
        TimeSpan timeSpan = TimeSpan.FromSeconds(_saveData.playTime);
        _timeTex.text = string.Format("{0:D2} : {1:D2} : {2:D2}",timeSpan.Hours,timeSpan.Minutes,timeSpan.Seconds);
    }

    public void BtnClick()
    {
        SaveManager.Instance.dataPath = SaveSlot;
        SaveManager.Instance.saveData = _saveData;
        //SceneManager.LoadScene(_saveData.currentScene); 나중에 씬 다 만들어지면 쓸거
        SceneManager.LoadScene(0);
    }
}
