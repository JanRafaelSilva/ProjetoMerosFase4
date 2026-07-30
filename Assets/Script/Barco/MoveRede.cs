using Unity.VisualScripting;
using UnityEngine;

public class MoveRede : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform Player;
    float gravity = 10f;
    public float timer;
    public float time;
    public float timerD;

    public void transformPlayer(Transform Player)
    {
        this.Player = Player;
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Vector2 direction = new Vector2(Player.position.x + 5 - transform.position.x, Player.position.y - transform.position.y);
        float rot = ((Mathf.Atan2(-direction.x, direction.y)) + Mathf.PI / 2f  ) * -1;
        time = Mathf.Sqrt((2*(direction.x * Mathf.Tan(rot)))/gravity);
        float velocity = (direction.x) / (Mathf.Cos(rot) * time);
        float velocityY = velocity * Mathf.Sin(rot);
        float velocityX = velocity * Mathf.Cos(rot);
        rb.linearVelocity = new Vector2(velocityX, velocityY);
    }
    void Update()
    {
        timerD += Time.deltaTime;
        if (timerD >= 20f)
        {
            Destroy(this.gameObject);
        }

    }
}

