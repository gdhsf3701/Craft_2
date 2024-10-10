using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOn : MonoBehaviour
{

    [SerializeField] Cinemachine.CinemachineConfiner2D cinemachineConfiner;
    private void Awake()
    {
    }
    private void Update()
    {
        cinemachineConfiner.InvalidateCache();
    }
}
