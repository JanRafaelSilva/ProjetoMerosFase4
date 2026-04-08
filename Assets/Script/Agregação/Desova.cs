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
    public bool timePronto, AreaLimpa, Area, PermiDesova;
    public LayerMask mask;
    public float alpha = 0.5f;
    public Collider[] hitColliders;
    Meros move;
    MoveDesova reproducao;
    Desova desova;
    public float circle;
    Rigidbody2D rb;

    public void Awake()
    {
        move = GetComponent<Meros>();
        reproducao = GetComponent<MoveDesova>();
        desova = GetComponent<Desova>();
        rb = GetComponent<Rigidbody2D>();
    }
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
                Area = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y + circle), radius,mask);
                AreaLimpa = Area == true ? false : true;
            }
            Espera = 0f;
        }
        if (AreaLimpa)
        {
            rb.linearVelocity = Vector2.zero;
            PermiDesova = false;
            move.enabled = false;
            reproducao.enabled = true;
            desova.enabled = false;
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
            if (AreaLimpa)
            {
                Gizmos.color = new Color(0f, 1f, 0f, alpha);
                Gizmos.DrawSphere(new Vector2(transform.position.x, transform.position.y + circle), radius);
                Gizmos.color = Color.white;
                Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y + circle), radius);
            } if(AreaLimpa == false)
             {
                Gizmos.color = new Color(1f, 0f, 0f, alpha);
                Gizmos.DrawSphere(new Vector2(transform.position.x, transform.position.y + circle), radius);
                Gizmos.color = Color.white;
                Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y + circle), radius);
            }
        }
    }
    }
