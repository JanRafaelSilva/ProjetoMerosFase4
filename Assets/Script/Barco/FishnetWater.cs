using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms;
using static UnityEngine.GraphicsBuffer;

public class FishnetWater : MonoBehaviour
{
    public MoveRede move;
    Rigidbody2D rb;
    public float moveMin, moveMax;
    bool collision = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        move = GetComponent<MoveRede>();
    }
    private void FixedUpdate()
    {
        if (collision)
        {
            rb.linearVelocity = new Vector2(0, -3f);
        }
        if (transform.position.y <= move.Player.transform.position.y)
        {
            rb.gravityScale = 0f;
            rb.linearVelocity = new Vector2(0, 0);
            this.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 4)
        {
            this.collision = true;
        }
    }
}
