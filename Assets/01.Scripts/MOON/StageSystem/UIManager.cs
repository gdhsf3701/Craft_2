using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    private StageTimeLimit time;
    [SerializeField] private TMP_Text timeText;
    
    private void Start()
    {
        if (timeText != null)
        {
            time= FindObjectOfType<StageTimeLimit>();
            timeText.text = $"�����ð�:{time.Time}";
            if (time != null)
            {
                time.OnNowTimeChanged += HandleNowTimeChanged;
            }
        }
    }
    private void HandleNowTimeChanged(int newTime)
    {
        timeText.text = $"�����ð�:{time.Time - newTime}";
    }
    
    private void OnDestroy()
    {
        if (time != null)
        {
            time.OnNowTimeChanged -= HandleNowTimeChanged;
        }   
    }
    
}
