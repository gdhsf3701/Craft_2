using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpenSetting : MonoBehaviour
{

    [SerializeField] RectTransform window;
    bool isopen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            clicktoopen();
        }
       
    }

    public void clicktoopen()
    {
        if (!isopen)
        {
            window.DOAnchorPos(new Vector3(-421, 4), 1).SetEase(Ease.OutQuart);
            isopen = true;
        }

        else
        {
            window.DOAnchorPos(new Vector3(-1389, 4), 1).SetEase(Ease.OutQuart);
            isopen = false;
        }
    }
}
