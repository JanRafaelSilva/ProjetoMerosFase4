using UnityEngine;

public class Rede : MonoBehaviour
{
    Rigidbody2D rigid;
    GameObject Player;
    float gravity = 10f;
    float angle = 45;
    public float forceY = 20f;
    public float speedX = 10f; 
    public float velocityI;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); 
    }
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        float rangeX = Vector3.Distance(this.transform.position, Player.transform.position);
        float rot = Mathf.Atan2(-transform.position.y, -transform.position.x) * Mathf.Rad2Deg;
        Debug.Log(rot);
    }
    void FixedUpdate()
    {
        rigid.AddForce(-Vector3.up * gravity, ForceMode2D.Force);
       // rigid.linearVelocity = new Vector2(speedX * Time.fixedDeltaTime, rigid.linearVelocity.y);
        // 1 VEZ
        //rigid.AddForce(Vector3.right * speedX, ForceMode2D.Force);

        //float rangeX = Vector3.Distance(this.transform.position, Player.transform.position);
        //rb = Mathf.Sqrt((rangeX * gravity)); 
        //rigid.linearVelocityX = speedX * Time.fixedDeltaTime;
        //float rangeMax = Mathf.Pow(rigid)
    }
}
