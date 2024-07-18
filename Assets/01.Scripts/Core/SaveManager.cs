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
    public SaveData saveData;
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
        saveData = new SaveData();

        SceneManager.sceneLoaded += HandleSceneChaneEvent;
    }
 
    private void HandleSceneChaneEvent(Scene arg0, LoadSceneMode arg1)
    {
        if (_playerTrm == null)
        {
            _playerTrm = PlayerManager.Instance.PlayerTrm;
        }
        //씬 바뀌었을때 해줘야할 행동들
        if (saveData.currentScene!=null&&arg0.name == saveData.currentScene)
        {
            _playerTrm.position= SaveManager.Instance.saveData.spawnPos;
            //saveData.savePoint
        }
        else if(arg0.name!=SceneName.Start&&arg0.name!=SceneName.End)
        {
            _playerTrm.position = new Vector3(0, 0, 0);
        }
    }

    public void SaveDataToJson()
    {
        EasyToJson.ToJson(saveData,dataPath,true);
    } 
    public SaveData JsonToData(string jsonFileName)
    {
        string path = GetFilePath(jsonFileName);
        if (!File.Exists(path))
        {
            Debug.Log("파일이 존재하지 않습니다.");
            Debug.Log("파일을 생성합니다.");
            SaveData defaultObj = new SaveData();
            EasyToJson.ToJson(defaultObj, jsonFileName, true);
            return defaultObj;
        }
        string json = File.ReadAllText(path);
        SaveData obj = JsonUtility.FromJson<SaveData>(json);
        return obj;
    }
    public string GetFilePath(string fileName)
    {
        return Path.Combine(LocalPath, $"{fileName}.json");
    }


    public void SavingData()
    {
        saveData.playTime = GameManager.Instance.PlayTime;
        saveData.playDate = DateTime.Now.ToString("yyyy - MM - dd - HH");
        saveData.playerHp = PlayerManager.Instance.Player.HealthCompo.CurrentHealth;
        saveData.spawnPos = PlayerManager.Instance.PlayerTrm.position;
        saveData.currentScene = SceneManager.GetActiveScene().name;
        //세이브 포인트, 스테이지 숫자 구현해야함

        SaveDataToJson();
    }
}
