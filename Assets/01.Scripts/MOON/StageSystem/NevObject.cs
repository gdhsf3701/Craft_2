using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NevObject : MonoBehaviour
{
    public Transform target;
    public float lerpSpeed = 20f;
    public float edgeOffset = 0.05f;

    [SerializeField] GameObject pointer;
    private Camera mainCamera;
    private RectTransform pointerRectTransform;

    void Start()
    {
        mainCamera = Camera.main;
        pointerRectTransform = pointer.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (target == null || pointer == null)
        {
            Destroy(pointer);
            enabled = false;
            return;
        }

        Vector3 screenPos = mainCamera.WorldToScreenPoint(target.position);

        if (screenPos.z > 0 && screenPos.x > 0 && screenPos.x < Screen.width && screenPos.y > 0 && screenPos.y < Screen.height)
        {
            pointer.SetActive(false);
            return;
        }

        pointer.SetActive(true);

        Vector3 clampedScreenPos = screenPos;
        if (clampedScreenPos.x < edgeOffset * Screen.width)
            clampedScreenPos.x = edgeOffset * Screen.width;
        else if (clampedScreenPos.x > (1 - edgeOffset) * Screen.width)
            clampedScreenPos.x = (1 - edgeOffset) * Screen.width;

        if (clampedScreenPos.y < edgeOffset * Screen.height)
            clampedScreenPos.y = edgeOffset * Screen.height;
        else if (clampedScreenPos.y > (1 - edgeOffset) * Screen.height)
            clampedScreenPos.y = (1 - edgeOffset) * Screen.height;

        pointerRectTransform.position = Vector3.Lerp(pointerRectTransform.position, clampedScreenPos, Time.deltaTime * lerpSpeed);

        Vector3 direction = target.position - mainCamera.ScreenToWorldPoint(pointerRectTransform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        pointerRectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
