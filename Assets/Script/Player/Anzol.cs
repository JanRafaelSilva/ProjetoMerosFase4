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
        Vector2 merosP = new Vector2(Meros.transform.position.x, Meros.transform.position.y);
        direction = merosP - (Vector2) transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.transform.SetParent(transform);
            RigidbodyType2D mudar = col.gameObject.GetComponent<RigidbodyType2D>();
            mudar = RigidbodyType2D.Kinematic;
            pescou = true;
        }
        if (col.gameObject.CompareTag("Barco"))
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if(pescou == true)
        {
            Vector2 barcoP = new Vector2(Barco.transform.position.x, Barco.transform.position.y);
            direction = barcoP - (Vector2) transform.position;
            rb.linearVelocity = new Vector2(direction.x, direction.y);
        }
    }
}
