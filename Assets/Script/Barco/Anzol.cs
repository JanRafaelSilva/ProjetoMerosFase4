using UnityEngine;

public class Anzol : MonoBehaviour
{
    public GameObject Meros;
    public GameObject Barco;
    Vector3 direction;
    public float speed = 10f;
    Rigidbody2D rb;
    public bool pescou = false;
    void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }
    void Start()
    {
        Pesca(Meros);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.transform.SetParent(transform);
            pescou = true;
        }
        if (col.gameObject.CompareTag("Barco"))
        {
            Destroy(gameObject,1f);
        }
    }
    void Update()
    {
        if(pescou == true)
        {
            Pesca(Barco);
            pescou = false;
        }
    }
    public void Pesca(GameObject move)
    {
        Vector2 Gobject = new Vector2(move.transform.position.x, move.transform.position.y);
        direction = Gobject - (Vector2)transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y);
    }
}
