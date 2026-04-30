using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class Meros : MonoBehaviour
{
    public Vector2 direction;
    public Vector3 velocity;
    public float timeRandom,timeMin,timeMax;
    public bool finishTime;
    public float moveMinX, moveMaxX, moveMinY, moveMaxY;
    public float posRangeMinX, posRangeMaxX, posRangeMinY, posRangeMaxY;
    private IEnumerator coroutine;
    public bool collider = false;
    private Rigidbody2D rb;
    public float speed = 0.05f;
    public float rotacaoMax = 20f;
    float velRotacao;
    public float smoothTime = 0.5f;
    public float OffsetRadius;
    public float moveMax = 3f;
    public float moveMin = -3f;
    public float stop;
    

    public float target = 3f;
    public float step = 1f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
       
            if (timeRandom <= 0)
            {
                finishTime = true;
            }
            if (finishTime)
            {
                DirectionRandom();
                collider = false;
                finishTime = false;
            }
            else if (collider == false)
            {
                timeRandom -= Time.deltaTime;

            }
        

            HandleFlip();
    }
    private void FixedUpdate()
    {

        Movimento();
    }
    public void Movimento()
    {
        if(transform.position.x > posRangeMaxX)
        {
            direction.x = moveMinX;
        }
        else if(transform.position.x < posRangeMinX)
        {
            direction.x = moveMaxX;
        }
        if(transform.position.y > posRangeMaxY)
        {
            direction.x = moveMinY;
        }
        else if (transform.position.y < posRangeMinY)
        {
            direction.y = moveMinY;
        }

        rb.AddForce(direction * speed);
        rb.linearVelocity = new Vector2(Mathf.Clamp(rb.linearVelocity.x, moveMin, moveMax), Mathf.Clamp(rb.linearVelocity.y, moveMin, moveMax));
        if (collider == false) { 
            float anguloAlvo = direction.y * rotacaoMax;

        if (transform.localScale.x < 0) anguloAlvo = -anguloAlvo;

        float zAtual = transform.eulerAngles.z;
        if (zAtual > 180) zAtual -= 360;

        float zNovo = Mathf.SmoothDampAngle(zAtual, anguloAlvo, ref velRotacao, smoothTime);
        transform.rotation = Quaternion.Euler(0, 0, zNovo);
        }
    }
    public void DirectionRandom()
    {
        timeRandom = Random.Range(timeMin, timeMax);
        direction.x = Random.Range(moveMinX, moveMaxX);
        direction.y = Random.Range(moveMinY, moveMaxY);
    }
    void HandleFlip()
    {
        float escalaAntiga = transform.localScale.x;
        
            if (direction.x > 0.1f)
            {
                transform.localScale = new Vector3(2, 1, 1);
            }
            else if (direction.x < -0.1f)
            {
                transform.localScale = new Vector3(-2, 1, 1);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            collider = true;
            direction = Vector2.zero;
            coroutine = WaitAndPrint(2.0f, collision.gameObject);
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator WaitAndPrint(float waitTime, GameObject col)
    {
        yield return new WaitForSeconds(waitTime);
        direction.x = transform.position.x >= col.transform.position.x ? moveMaxX : moveMinX;
        direction.x = transform.position.x <= col.transform.position.x ? moveMinX : moveMaxX;
        direction.y = transform.position.y >= col.transform.position.y ? moveMaxY : moveMinY;
        direction.y = transform.position.y <= col.transform.position.y ? moveMinY : moveMaxY;
        yield return new WaitForSeconds(waitTime * waitTime);
        finishTime = true;
    }
}
