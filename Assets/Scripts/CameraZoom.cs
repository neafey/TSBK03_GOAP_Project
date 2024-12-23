using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Camera targetCamera;
    public float zoomSpeed = 5f;
    public float minZoom = 5f;
    public float maxZoom = 20f;

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            targetCamera.orthographicSize -= scroll * zoomSpeed;
            targetCamera.orthographicSize = Mathf.Clamp(targetCamera.orthographicSize, minZoom, maxZoom);
        }
    }
}
