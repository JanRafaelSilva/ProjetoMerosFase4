using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public class MoveMero : MonoBehaviour
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
    public Vector3 velocity;
    public float stop;


    public float timeRandom, timeMin, timeMax;
    public float moveMin_X,moveMax_X,moveMinY, moveMaxY;
    //Ponto para o qual o personagem irá se mover
    //Variável NavMeshAgent Para configurar A movimentação do personagem
    private NavMeshAgent agent;

    void Awake()
    {
         rb = GetComponent<Rigidbody2D>();
        //Pega o Componente NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        DirectionRandom();
        //Variaveis setadas como False para Não utilizar os eixos Y Baseado em 3 dimensões
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speed;
        agent.acceleration = 2f;
    }
    private void Update()
    {
        //HandleFlip();
        timeRandom -= Time.deltaTime;
        if(timeRandom <= 0f)
        {
            DirectionRandom();
            
        }
    } 
    private void FixedUpdate()
    {
        //Faz o personagem se locomover pelo cenario até o point
        Movimento();

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
        agent.angularSpeed = direction.y * rotacaoMax;

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
    public void OnCollisionEnter2D(Collision2D col)
    {
        DirectionRandom();
    }
}
/*
  direction.x = transform.position.x >= meio.transform.localPosition.x ? moveMinX : moveMaxX;
  direction.x = transform.position.x <= meio.transform.localPosition.x ? moveMaxX : moveMinX;
  direction.y = transform.position.y >= meio.transform.localPosition.y ? moveMinY : moveMaxY;
  direction.y = transform.position.y <= meio.transform.localPosition.y ? moveMaxY : moveMinY;        */