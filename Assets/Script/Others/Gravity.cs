using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float max;
    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(transform.position.y > max)
        {
            rb.gravityScale = 1f;
        }else
        {
            rb.gravityScale = 0f;
        }
    }
}
