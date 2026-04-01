using UnityEngine;

public class Rede : MonoBehaviour
{
    Rigidbody2D rigid;
    GameObject Player;
    float gravity = 10f;
    public float rot;
    public float angleI = 90f;
    float range;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); 
    }
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");  
        Vector2 direction = new Vector2(Player.transform.position.x - transform.position.x,Player.transform.position.y - transform.position.y);
        rot = (Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg) + angleI;     
    }
    void FixedUpdate()
    {
    }
}
//rigid.AddForce(-Vector3.up * gravity, ForceMode2D.Force);
       // rigid.linearVelocity = new Vector2(speedX * Time.fixedDeltaTime, rigid.linearVelocity.y);
        // 1 VEZ
        //rigid.AddForce(Vector3.right * speedX, ForceMode2D.Force);

        //float rangeX = Vector3.Distance(this.transform.position, Player.transform.position);
        //rb = Mathf.Sqrt((rangeX * gravity)); 
        //rigid.linearVelocityX = speedX * Time.fixedDeltaTime;
        //float rangeMax = Mathf.Pow(rigid)