using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOpen : MonoBehaviour
{
    // Start is called before the first frame update
    public bool wallOpen { get; set; }
    void Awake()
    {
        wallOpen=false;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (wallOpen)
        {
            gameObject.SetActive(false);
        }
    }
}
