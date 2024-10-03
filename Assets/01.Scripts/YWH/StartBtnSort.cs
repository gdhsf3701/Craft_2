using System.Collections;
using System.Collections.Generic;
using System.IO;
using EasySave.Json;
using UnityEngine;

public class StartBtnSort : MonoBehaviour
{
    [SerializeField]
    bool _isFirst=true;
    [SerializeField] GameObject _firstUI, _defaultUI;
    private void Start()
    {
        for(int i = 1; i < 6;i++)
        {
            if (EasyToJson.IsExistJson("SaveData" + i))
            {
                _isFirst = false;
                break;
            }
        }
        _firstUI.SetActive(_isFirst);
        _defaultUI.SetActive(!_isFirst);
    }
}
