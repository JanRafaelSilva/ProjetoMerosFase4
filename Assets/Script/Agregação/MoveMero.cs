using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[ RequireComponent (typeof( NavMeshAgent ))]
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
    public float stop;
    public float acceleration;
    public bool EndMap;

    public float timeRandom, timeMin, timeMax;
    public float EndMapTime;
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
        agent.acceleration = acceleration;
        agent.speed = speed;
    }
    private void Update()
    {

        timeRandom -= Time.deltaTime;
        if(timeRandom <= 0f)
        {
            DirectionRandom();
        }
        if(agent.velocity.magnitude < 0.15f && EndMap)
        {
           direction *= -1;
           EndMap = false;
        }
        else
        {
            EndMapTime += Time.deltaTime;
            if(EndMapTime >= 4f)
            {
                EndMap = true;
                EndMapTime = 0f;
            }
        }
    } 
    private void FixedUpdate()
    {
        Movimento();

    }
    public void DirectionRandom()
    {
        timeRandom = Random.Range(timeMin, timeMax);
        direction.x = Random.Range(moveMin_X, moveMax_X);
        direction.y = Random.Range(moveMinY, moveMaxY);
        if (direction.x > 0f) 
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direction.x < 0f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    public void Movimento()
    {
        agent.SetDestination(new Vector3(transform.position.x + direction.x, transform.position.y + direction.y, 0f));
    }
}
// utilizar autoBraking: Should the agent brake automatically to avoid overshooting the destination point?
// pós autoRepath: Should the agent attempt to acquire a new path if the existing path becomes invalid?
// talvez usar avoidancePriority: The avoidance priority level.


//agent.velocity = rb.linearVelocity;
        //rb.AddForce(direction * agent.speed);
        //rb.linearVelocity = new Vector2(Mathf.Clamp(rb.linearVelocity.x, moveMin, moveMax),Mathf.Clamp(rb.linearVelocity.y, moveMin, move
        //	Maximum turning speed in (deg/s) while following a path.
      //  agent.angularSpeed = direction.y * rotacaoMax;
      //	The maximum acceleration of an agent as it follows a path, given in units / sec^2.

      //NavMesh.FindClosestEdge

      //Inicio o projeto em junho