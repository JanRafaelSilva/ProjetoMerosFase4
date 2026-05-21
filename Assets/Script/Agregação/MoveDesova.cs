using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;
using System;

public class MoveDesova : MonoBehaviour
{
    public bool reproduction;

    //raycast
    public float radius;
    public LayerMask mask;
    public bool spawning;

    public Transform destinationY;

    //Nav
    public NavMeshAgent nav;

    public float rot;
    float velRotacao;

    public float smoothTime;
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }

   public void Allow(bool allow)
    {
        spawning = allow;
        reproduction = allow;
    }
    void Start()
    {
        Physics.OverlapSphere(transform.position, radius, mask);
    }
    private void OnDrawGizmos()
    {
        if(spawning){
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
    void Update()
    {
        if (reproduction && spawning)
        {

           
          // Vector3 direcao = new Vector3(0, 0, atualZ);
            transform.Translate(Vector3.up * Time.deltaTime, Space.World);
            nav.enabled = false;
            //nav.SetDestination(new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z));
           //rot = transform.localScale.x >= 0.5f ? 90f : -90;
           float atualZ =  transform.eulerAngles.z;
           rot = Mathf.SmoothDampAngle(atualZ, 70f * transform.localScale.x, ref velRotacao, smoothTime);
           transform.rotation = Quaternion.Euler(0, 0,rot); 
        }
        if(transform.position.y >= destinationY.position.y)
        {
            spawning = false;
        }
    }

}
/* public float target = 3f;
    public float  step = 1f;
    public Vector2 direction;
    public bool movimento;
    private Vector2 centre;

    private float RotateSpeed = 1f;
    private float Radius = 3f;

    private float angle;

    public void Start()
    {
        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y + target), step);
        direction = new Vector2(-1f, -1f);
        centre = new Vector2(transform.position.x, transform.position.y - Radius);
    }
    public void Update()
    {
            MovimentoCircular();
    }
    public void MovimentoCircular()
    {
        angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
        transform.position = centre + offset;

    }*/
