using UnityEngine;

public class SaveData
{
    public float playTime;
 
    public string currentScene;
    public int stageNumber;


    public SaveData()
    {
        playTime = 0;
        currentScene = SceneName.Stage0;
        stageNumber = 0;
    }
}