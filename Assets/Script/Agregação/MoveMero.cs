using UnityEngine;

public class MoveMero : MonoBehaviour
{
    public Vector2 direction;
    private Rigidbody2D rb;
    public float speed = 0.05f;
    public float rotacaoMax = 20f;
    float velRotacao;
    public float smoothTime = 0.5f;
    public float OffsetRadius;
    public float moveMax = 3f;
    public float moveMin = -3f;
    public Vector3 velocity;
    public float stop;
    public bool colliderFundo = false;


    public float timeRandom, timeMin, timeMax;
    public float moveMinX,moveMaxX,moveMinY, moveMaxY;

    public Transform meio;
    public Vector3 a;

    // direction n recebe nada

    // O mero não pode sair de certa area
    // se ele sair da area sua direção deve mudar

    //NavMesh
    void Awake()
    {
         rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        DirectionRandom();
        a = new Vector3(transform.position.x,transform.position.y,transform.position.z);
    }
    private void Update()
    {
        HandleFlip();
        if(colliderFundo){
        timeRandom -= Time.deltaTime;
        }
        if(timeRandom <= 0f)
        {
            DirectionRandom();
            
        }
    } 
    private void FixedUpdate()
    {
        Movimento();
    }
    public void DirectionRandom()
    {
        rb.linearVelocity = Vector2.MoveTowards(rb.linearVelocity, new Vector2(0f, 0f), stop);
        timeRandom = Random.Range(timeMin, timeMax);
        direction.x = Random.Range(moveMinX, moveMaxX);
        direction.y = Random.Range(moveMinY, moveMaxY);
    }
    public void Movimento()
    {

        rb.AddForce(direction * speed);
        rb.linearVelocity = new Vector2(Mathf.Clamp(rb.linearVelocity.x, moveMin, moveMax),Mathf.Clamp(rb.linearVelocity.y, moveMin, moveMax));
        if(direction == Vector2.zero){
            rb.linearVelocity = Vector2.MoveTowards(rb.linearVelocity, new Vector2(0f, 0f), stop);
        }
        float anguloAlvo = direction.y * rotacaoMax;

        if (transform.localScale.x < 0) anguloAlvo = -anguloAlvo;

        float zAtual = transform.eulerAngles.z;
        if (zAtual > 180) zAtual -= 360;

        float zNovo = Mathf.SmoothDampAngle(zAtual, anguloAlvo, ref velRotacao, smoothTime);
        transform.rotation = Quaternion.Euler(0, 0, zNovo);
    }
     void HandleFlip()
    {
        float escalaAntiga = transform.localScale.x;
        if (direction.x > 0.1f) 
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direction.x < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (transform.localScale.x != escalaAntiga)
        {
            Vector3 rot = transform.eulerAngles;
            float z = rot.z;
            if (z > 180) z -= 360;

            transform.rotation = Quaternion.Euler(0, 0, -z);

            velRotacao = 0;
        }

    }
    public void OnCollisionEnter2D(Collision2D col)
    {
         Debug.Log("Entrou");
            colliderFundo = true;
        DirectionRandom();
    
    }
    public void OnCollisionExit2D(Collision2D col)
    {
         Debug.Log("Saiu");
           colliderFundo = false;

        direction.x = transform.position.x >= meio.transform.localPosition.x ? moveMinX : moveMaxX;
        direction.x = transform.position.x <= meio.transform.localPosition.x ? moveMaxX : moveMinX;
        direction.y = transform.position.y >= meio.transform.localPosition.y ? moveMinY : moveMaxY;
        direction.y = transform.position.y <= meio.transform.localPosition.y ? moveMaxY : moveMinY;
        
    }
}
