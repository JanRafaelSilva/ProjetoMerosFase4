using UnityEngine;

public class Anzol : MonoBehaviour
{
    public Transform Barco;
    public Transform Mero;
    Vector3 direction;
    private float speed = 8f;
    public Rigidbody2D rb;
    public bool 
    pescou = false,
    puxando = false;
    public float timerD;
    public void PlayerScene(Transform Mero, Transform Barco)
    {
        // Posições do Mero e do Barco
        this.Mero = Mero;
        this.Barco = Barco;
    }
    public void Start()
    {
        // Alvo Mero
        Pesca(Mero);
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        // Mero é acertado, Mero vai ser puxado.
        if (col.gameObject.CompareTag("Player"))
        {
            col.transform.SetParent(transform);
            pescou = true;
        }
        // Pesca concluída.
        if (col.gameObject.CompareTag("Barco") && puxando)
        {
            Destroy(gameObject,1f);
        }
        // Atingiu uma pedra.
        if(col.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }
    }
    public void Pesca(Transform move)
    { 
        //direção do movimento
        Vector2 Gobject = new Vector2(move.position.x, move.position.y);
        direction = (Gobject - (Vector2)transform.position).normalized;
        rb.linearVelocity = new Vector2(direction.x * speed, direction.y * speed);
    }
    void Update()
    {
        //tempo de vida
        timerD += Time.deltaTime;
        //direção - Barco
        if(pescou == true)
        {
            Pesca(Barco);
            pescou = false;
            puxando = true;
        }
        // Fim
        if (timerD >= 10f) 
        {
            Destroy(gameObject);
        }

    }
}
