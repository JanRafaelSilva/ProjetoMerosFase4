using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;
public class Desova : MonoBehaviour
{
    public float Espera, TDesova, Tmax,Tmin;
    public float radius;
    public bool timePronto, AreaLimpa, PermiDesova;
    public LayerMask mask;
    public float alpha = 0.5f;
    public Collider[] hitColliders;
    private void Start()
    {
        timePronto = true;
    }
    private void Update()
    {
        Espera += Time.deltaTime;
        if (timePronto)
        {
            TimeRandom();
            timePronto = false;
        }
        if (Espera >= TDesova)
        {
            PermiDesova = (Random.value > 0.9f);
            if (PermiDesova)
            {
                AreaLimpa = Physics2D.OverlapCircle(transform.position, radius,mask);
            }
            Espera = 0f;
        }
        
    }
    void TimeRandom()
    {
        TDesova = Random.Range(Tmin, Tmax);
        timePronto = true;
    }
    private void OnDrawGizmos()
    {
        if (PermiDesova) {
            if (AreaLimpa == false)
            {
                Gizmos.color = new Color(0f, 1f, 0f, alpha);
                Gizmos.DrawSphere(transform.position, radius);
                Gizmos.color = Color.white;
                Gizmos.DrawWireSphere(transform.position, radius);
            } if(AreaLimpa == true)
             {
                Gizmos.color = new Color(1f, 0f, 0f, alpha);
                Gizmos.DrawSphere(transform.position, radius);
                Gizmos.color = Color.white;
                Gizmos.DrawWireSphere(transform.position, radius);
            }
        }
    }
    }
