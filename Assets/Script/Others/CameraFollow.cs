using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset = new Vector3 (0,0,-10);
    public Vector3 velocity;
    public float smoothTime = 0.2f;
    public float posiY;
    public bool Y = false;

    void Start()
    {
        
        transform.position = new Vector3(player.position.x, 0, player.position.z) + offset;
    }

    void LateUpdate()
    {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.position.x, 0f + posiY, player.position.z) + offset, ref velocity, smoothTime);
        if (Y)
        {
            posiY = player.position.y;
        }
    }
    public void QuickTimeEvent(bool Y)
    {
        this.Y = Y;
    }
}
