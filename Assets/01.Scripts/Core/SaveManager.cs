using UnityEngine;
using EasySave.Json;
using UnityEngine.SceneManagement;

public class SoundData
{
    public float sfxVol, bgmVol;

    public SoundData()
    {
        sfxVol = 1;
        bgmVol = 1;
    }
}
public class SceneName
{
    public const string Start = "StartScene";
    public const string Select = "SelectScene";
    public const string Delete = "DeleteScene";
    public const string Stage0 = "Stage0Scene";
    public const string Stage1 = "Stage1Scene";
    public const string Stage2 = "Stage2Scene";
    public const string Stage3 = "Stage3Scene";
    public const string Stage4 = "Stage4Scene";
    public const string Stage5 = "Stage5Scene";
    public const string Boss = "BossFinal";
    public const string End = "EndScene";
}
public class SaveManager : MonoBehaviour
{
    private SaveData _saveData;
    private SoundData _soundData;
    public static SaveManager Instance;
    private Transform _playerTrm;
    
    public string dataPath = "SaveData1";
    private string _soundPath = "Sound";
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
        _soundData = EasyToJson.FromJson<SoundData>(_soundPath);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SaveData();
        }
    }

    public void SetDataPath(string path,SaveData saveData)
    {
        dataPath = path;
        _saveData = saveData;
    }

    public float ReturnSFXVolume()
    {
        return _soundData.sfxVol;
    }
    public float ReturnBGMVol()
    {
        return _soundData.bgmVol;
    }
    public void SetStageNumber(int stageNumber,string stageName)
    {
        _saveData.stageNumber = stageNumber;
        _saveData.currentScene = stageName;
        SaveData();
    }//스테이지 넘어갈때마다 실행
    public void SetTime(float time)
    {
        _saveData.playTime += time;
        SaveData();
    }
    private void SaveData()
    {
        EasyToJson.ToJson(_saveData,dataPath,true);
    }

    public void SaveSfxSound(float sfx)
    {
        _soundData.sfxVol = sfx;
        EasyToJson.ToJson(_soundData,_soundPath,true);
    }
    public void SaveBgmSound(float bgm)
    {
        _soundData.bgmVol = bgm;
        EasyToJson.ToJson(_soundData,_soundPath,true);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(_saveData.currentScene);
    }
}
