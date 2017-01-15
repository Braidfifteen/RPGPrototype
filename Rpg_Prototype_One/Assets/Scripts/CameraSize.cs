using UnityEngine;

public class CameraSize : MonoBehaviour
{
    private Camera cam;

    public void Awake()
    {
        cam = GetComponent<Camera>();
        cam.orthographicSize = (Screen.height / 100f / 2.0f);
    }
}
