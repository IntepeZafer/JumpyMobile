using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    public float targetAspect = 9f / 16f; // Desired aspect ratio
    public float orthographicSize = 5f; // Desired orthographic size

    private void Start()
    {
        Camera cam = Camera.main;
        float screenAspect = (float)Screen.width / Screen.height;
        float scale = targetAspect / screenAspect;
        cam.orthographicSize = orthographicSize * scale;
    }
}
