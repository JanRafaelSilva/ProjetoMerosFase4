//using System.Numerics;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
public class MovePlayer : MonoBehaviour
{
    Vector2 direction;
    private Rigidbody2D rb;
    public float speed = 0.05f;
    public float rotacaoMax = 20f;
    float velRotacao;
    public float smoothTime = 0.5f;
    public float OffsetRadius;
    public float moveMax = 3f;
    public float moveMin = -3f;
    void Awake()
    {
         rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        HandleFlip();
    } 
    public void SetMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
         
        Movimento();
    }
    public void Movimento()
    {

        rb.AddForce(direction * speed);
        rb.linearVelocity = new Vector2(Mathf.Clamp(rb.linearVelocity.x, moveMin, moveMax),Mathf.Clamp(rb.linearVelocity.y, moveMin, moveMax));
        
        
        float anguloAlvo = direction.y * rotacaoMax;

        if (transform.localScale.x < 0) anguloAlvo = -anguloAlvo;

        float zAtual = transform.eulerAngles.z;
        if (zAtual > 180) zAtual -= 360;

        float zNovo = Mathf.SmoothDampAngle(zAtual, anguloAlvo, ref velRotacao, smoothTime);
        transform.rotation = Quaternion.Euler(0, 0, zNovo);
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
}