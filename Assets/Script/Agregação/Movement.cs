using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[ RequireComponent (typeof( NavMeshAgent ))]
public class Movement : MonoBehaviour
{
    public Vector2 direction;
    private Rigidbody2D rb;
    public float speed = 0.05f;
    public float rotacaoMax = 20f;
    float velRotacao;
    public float smoothTime = 0.5f;
    public float OffsetRadius;
    public float moveMax = 3f;
    public float moveMin = -3f;
    public float stop;
    public float acceleration;
    public bool EndMap;

    public float timeRandom, timeMin, timeMax;
    public float EndMapTime;
    public float moveMin_X,moveMax_X,moveMinY, moveMaxY;
    private NavMeshAgent agent;

    void Awake()
    {
         rb = GetComponent<Rigidbody2D>();
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.acceleration = acceleration;
        agent.speed = speed;
    }
    public void Control()
    {
        HandleFlip();
        timeRandom -= Time.deltaTime;
        if (timeRandom <= 0f)
        {
            DirectionRandom();
        }
        if (agent.velocity.magnitude < 0.15f && EndMap)
        {
            direction *= -1;
            transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
            EndMap = false;
        }
        else
        {
            EndMapTime += Time.deltaTime;
            if (EndMapTime >= 4f)
            {
                EndMap = true;
                EndMapTime = 0f;
            }
        }
    }
    public void DirectionRandom()
    {
        timeRandom = Random.Range(timeMin, timeMax);
        direction.x = Random.Range(moveMin_X, moveMax_X);
        direction.y = Random.Range(moveMinY, moveMaxY);
    }
    public void Movimento()
    {
        agent.SetDestination(new Vector3(transform.position.x + direction.x, transform.position.y + direction.y, 0f));
        
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
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direction.x < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
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