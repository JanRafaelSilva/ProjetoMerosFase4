using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;
using System;
using System.Transactions;
using System.Collections;

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
    public float _amplitude, gainAmplitude;

    public Vector2 pos;
    private Vector3 axis;

    public float direction;
    public float _time;
    public float timeIntervalo;
    public float timeZZ;
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
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
        timeZZ += Time.deltaTime;
        StartCoroutine(AddAmplitude());
        Vector2 mov = pos + Vector2.up * (timeZZ * speed);
        direction = Mathf.Sin(timeZZ * _frequency);
        mov += (Vector2)axis.normalized * direction * _amplitude;
        transform.position = mov;

    }
    public void Control()
    {
        if (spawning)
        {
            //sinal aos machos
            Physics.OverlapSphere(transform.position, radius, mask);
            pos = transform.position;
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
        if (direction <= -0.99f)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(1,1,1), _time);
        }
        else if (direction >= 0.99f)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(-1, 1, 1), _time);
        }
    }
    IEnumerator AddAmplitude()
    {
        yield return new WaitForSeconds(0.5f);
        _amplitude += gainAmplitude;
    }
}

