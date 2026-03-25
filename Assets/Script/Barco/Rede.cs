using UnityEngine;

public class Rede : MonoBehaviour
{
    Rigidbody2D rigid;
    GameObject Player;
    float gravity = 10f;
    float angle = 45;
    public float forceY = 5f;
    public float speedX = 10f; 
    public float velocityI;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); 
    }
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void FixedUpdate()
    {
        rigid.AddForce(-Vector3.up * gravity, ForceMode2D.Force);
        
        // 1 VEZ
        //rigid.AddForce(Vector3.up * forceY);
       // rigid.linearVelocityX = speedX * Time.fixedDeltaTime;

        //float rangeX = Vector3.Distance(this.transform.position, Player.transform.position);
        //rb = Mathf.Sqrt((rangeX * gravity)); 
        //rigid.linearVelocityX = speedX * Time.fixedDeltaTime;
        //float rangeMax = Mathf.Pow(rigid)
    }
}
