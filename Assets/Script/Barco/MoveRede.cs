using UnityEngine;

public class MoveRede : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject Player;
    float gravity = 10f;
    public float rot;
    public float angleI = 90f;
    public float timer;
    float velocity = 10;
    public float velocityX;
    public float velocityY;
    public float time;
    Vector2 direction;
    public Transform PlayerTrans;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        PlayerTrans = Player.transform;
        direction = new Vector2(Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y);
        rot = ((Mathf.Atan2(-direction.x, direction.y)) + Mathf.PI / 2f  ) * -1;
        time = Mathf.Sqrt((2*(direction.x * Mathf.Tan(rot)))/gravity);
        velocity = (direction.x) / (Mathf.Cos(rot) * time);
        velocityY = velocity * Mathf.Sin(rot);
        velocityX = velocity * Mathf.Cos(rot);
        rb.linearVelocity = new Vector2(velocityX, velocityY);
    }
}

