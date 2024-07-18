using System.Collections;
using System.Collections.Generic;
using System.IO;
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
            string path = SaveManager.Instance.GetFilePath("SaveData"+i);
            if (File.Exists(path))
            {
                _isFirst = false;
                break;
            }
        }
        _firstUI.SetActive(_isFirst);
        _defaultUI.SetActive(!_isFirst);
    }
}
