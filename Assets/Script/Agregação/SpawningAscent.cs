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
    public bool spawning;

    public Transform destinationY;

    //Nav
    public NavMeshAgent nav;

    public float rot;
    float velRotacao;

    public float smoothTime;

    public float speed;
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }
   public void Allow(bool allow)
    {
        spawning = allow;
        reproduction = allow;
        Physics.OverlapSphere(transform.position, radius, mask);
    }
    private void OnDrawGizmos()
    {
        if(spawning){
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
    public void Control()
    {
        if (reproduction && spawning)
        {
           transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
                nav.enabled = false;
                    float atualZ =  transform.eulerAngles.z;
           rot = Mathf.SmoothDampAngle(atualZ, 60f * transform.localScale.x, ref velRotacao, smoothTime);
                transform.rotation = Quaternion.Euler(0, 0,rot); 
        }
        if(transform.position.y >= destinationY.position.y)
        {
            spawning = false;
            float atualZ = transform.eulerAngles.z;
            rot = Mathf.SmoothDampAngle(atualZ, 0 * transform.localScale.x, ref velRotacao, smoothTime);
            transform.rotation = Quaternion.Euler(0, 0, rot);
        }
    }

}

