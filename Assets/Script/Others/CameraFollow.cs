using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    Vector3 offset = new Vector3 (0,0,-10);
    public Vector3 velocity;
    public float smoothTime = 0.2f;
    float posiY;
    public bool Y = false;

    void Start()
    {
        
        transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z) + offset;
    }

    void LateUpdate()
    {
        if (Y)
        {
            posiY = player.transform.position.y;
        }
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.transform.position.x, 0f + posiY, player.transform.position.z) + offset, ref velocity, smoothTime);
    }
}
