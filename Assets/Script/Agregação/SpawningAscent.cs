using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;
using System;

public class SpawningAscent : MonoBehaviour
{
    public bool reproduction;

    //raycast
    public float radius;
    public LayerMask mask;
    public bool spawning = true;

    public Transform destinationY;

    //Nav
    public NavMeshAgent nav;

    //mov
    public float rot;
    float velRotacao;
    public float smoothTime;
    public float speed;
    //Zigzag
    public float _frequency = 1.0f;
    public float _amplitude = 5.0f;

    private Vector3 pos;
    private Vector3 axis;

    public float direction;
    public float _time;
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        pos = transform.position;
        axis = transform.right;
    }
    private void OnDrawGizmos()
    {
        if(spawning){
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
    void ZigzagMovement()
    {
        pos += Vector3.up * Time.deltaTime * speed;
        direction = Mathf.Sin(Time.time * _frequency);
        transform.position = pos + axis * direction * _amplitude;
    }
    public void Control()
    {
        if (spawning)
        {
            //sinal aos machos
            Physics.OverlapSphere(transform.position, radius, mask);
            spawning = false;
        }
        if (transform.position.y <= destinationY.position.y)
        {
            //movimento
          // transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
                nav.enabled = false;
            //float atualZ =  transform.eulerAngles.z;
           // rot = Mathf.SmoothDampAngle(atualZ, 60f * transform.localScale.x, ref velRotacao, smoothTime);
           // transform.rotation = Quaternion.Euler(0, 0,rot); 
            ZigzagMovement();
            Flip();
        }
        else
        {
            //parada
            spawning = false;
            float atualZ = transform.eulerAngles.z;
            rot = Mathf.SmoothDampAngle(atualZ, 0 * transform.localScale.x, ref velRotacao, smoothTime);
            transform.rotation = Quaternion.Euler(0, 0, rot);
        }
    }
    void Flip()
    {
        if (direction <= -0.9f)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(1,1,1), _time);
        }
        else if (direction >= 0.9f)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(-1, 1, 1), _time);
        }
    }
}

