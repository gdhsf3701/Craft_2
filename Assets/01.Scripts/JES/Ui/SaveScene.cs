using System;
using System.Collections;
using System.Collections.Generic;
using EasySave.Json;
using UnityEngine;

public class SaveScene : MonoSingleton<SaveScene>
{
    [SerializeField] private SaveBtn _btnPrefab;

    [SerializeField] private List<Sprite> _bgSprites;
    
    [SerializeField] private GameObject _deletePanel;

    private string _saveData = "SaveData";
    
    private SaveBtn deleteBtn;
    
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

    public void PanelOn(SaveBtn saveBtn)
    {
        deleteBtn = saveBtn;
        _deletePanel.SetActive(true);
    }
    public void PanelOff()
    {
        _deletePanel.SetActive(false);
        deleteBtn = null;
    }
    public void DeletePanelClick()
    {
        deleteBtn.DeleteBtnClick();
    }
}
