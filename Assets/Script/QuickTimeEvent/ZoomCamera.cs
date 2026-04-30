using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    public Camera camera;
    public float min = 8f;
    public float max = 12.6f;
    public float time = 5f;
    public bool estado;
    private void Awake()
    {
        camera = GetComponent<Camera>();
    }
    private void Update()
    {
        if (estado)
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, min, time);
        }
        else
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, max, time);
            this.enabled = false;
        }
    }
    public void Minigame(bool estado)
    {
        this.estado = estado;
    }
}
