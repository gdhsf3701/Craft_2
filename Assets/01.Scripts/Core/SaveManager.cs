using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using EasySave.Json;
using UnityEngine.SceneManagement;

public class SceneName
{
    public const string Start = "StartScene";
    public const string Stage0 = "Stage0Scene";
    public const string Stage1 = "Stage1Scene";
    public const string Stage2 = "Stage2Scene";
    public const string Stage3 = "Stage3Scene";
    public const string Stage4 = "Stage4Scene";
    public const string Stage5 = "Stage5Scene";
    public const string End = "EndScene";
}
public class SaveManager : MonoBehaviour
{
    private SaveData _saveData;
    public static SaveManager Instance;
    private Transform _playerTrm;
    
    public string dataPath = "SaveData1";
    
    private static readonly string LocalPath = Application.dataPath + "/SaveFolder/";
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        _saveData = new SaveData();
    }
    public void SetDataPath(string path,SaveData saveData)
    {
        dataPath = path;
        _saveData = saveData;
    }

    public int ReturnSFXVolume()
    {
        return _saveData.sfxVol;
    }
    public int ReturnBGMVol()
    {
        return _saveData.bgmVol;
    }
    public void SetStageNumber(int stageNumber)
    {
        _saveData.stageNumber = stageNumber;
    }//스테이지 넘어갈때마다 실행
    public void SetTime(float time)
    {
        _saveData.playTime += time;
    }
    private void SaveData()
    {
        EasyToJson.ToJson(_saveData,dataPath,true);
    }
}
