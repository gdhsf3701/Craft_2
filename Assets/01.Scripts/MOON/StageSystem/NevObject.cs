using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NevObject : MonoBehaviour
{
    public Transform target;
     float lerpSpeed = 20f;
     float edgeOffset = 0.05f;//5%

    [SerializeField] GameObject pointer;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (target == null)
        {
            pointer.SetActive(false);
            return;
        }

        Vector3 screenPos = mainCamera.WorldToScreenPoint(target.position);

        if (screenPos.z > 0 && screenPos.x > 0 && screenPos.x < Screen.width && screenPos.y > 0 && screenPos.y < Screen.height)
        {
            pointer.SetActive(false);
        }
        else
        {
            Vector3 clampedPosition = target.position;

            Vector3 viewportPos = mainCamera.WorldToViewportPoint(target.position);

            if (viewportPos.x < 0)
                viewportPos.x = edgeOffset;

            else if (viewportPos.x > 1)
                viewportPos.x = 1 - edgeOffset;

            if (viewportPos.y < 0)
                viewportPos.y = edgeOffset;

            else if (viewportPos.y > 1)
                viewportPos.y = 1 - edgeOffset;

            clampedPosition = mainCamera.ViewportToWorldPoint(viewportPos);

            pointer.SetActive(true);
            pointer.transform.position = Vector3.Lerp(pointer.transform.position, clampedPosition, Time.deltaTime * lerpSpeed);

            Vector3 direction = target.position - pointer.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            pointer.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        }
    }
}
