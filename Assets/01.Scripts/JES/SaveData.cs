using UnityEngine;

public class SaveData
{
    public float playTime;
 
    public string currentScene;
    public int stageNumber;

    public int sfxVol, bgmVol;

    public SaveData()
    {
        playTime = 0;
        currentScene = "";
        stageNumber = 0;
        sfxVol = 1;
        bgmVol = 1;
    }
}