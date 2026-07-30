using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset = new Vector3 (0,0,-10);
    public Vector3 velocity;
    public float smoothTime = 0.2f;
    public float position_y ;
    public bool followPlayer  = false;
    public float max_x,min_x;
    float y;

    void Start()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(Mathf.Clamp(player.position.x,max_x, min_x), 0f + position_y, player.position.z) + offset, ref velocity, smoothTime);
    }

    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(Mathf.Clamp(player.position.x,min_x, max_x), 0f + y, player.position.z) + offset, ref velocity, smoothTime);
        if (followPlayer)
        {
            y = player.position.y;
        }else{
            y = position_y;
        }
    }
    public void QuickTimeEvent(bool followPlayer)
    {
        this.followPlayer = followPlayer;
    }
}
