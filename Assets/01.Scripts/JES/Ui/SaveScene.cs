using System;
using System.Collections;
using System.Collections.Generic;
using EasySave.Json;
using UnityEngine;

public class SaveScene : MonoBehaviour
{
    [SerializeField] private SaveBtn _btnPrefab;

    [SerializeField] private List<Sprite> _bgSprites;

    private string _saveData = "SaveData";
    
    
    private void Start()
    {
        for (int i = 1; i < 6; i++)
        {
            string saveData = _saveData + i;
            if (EasyToJson.IsExistJson(saveData))
            {
                SaveBtn saveBtn = Instantiate(_btnPrefab, transform);
                int randomIndex = UnityEngine.Random.Range(0, _bgSprites.Count);
                saveBtn.Initalize(saveData,_bgSprites[randomIndex]);
                saveBtn.transform.position = new Vector2(saveBtn.transform.position.x+(i-1)*700,saveBtn.transform.position.y);
            }
            else
            {
                break;
            }
        }
    }
}
