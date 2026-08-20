using System;
using System.Collections.Generic;
using UnityEngine;
using static FSM;
using UnityEngine.AI;

public class FSM : MonoBehaviour
{
    //Scripts
    [SerializeField] private Sex sex;
    [SerializeField] private Movement movement;
    [SerializeField] private SpawningAscent spawningAscent;
    [SerializeField] private SpawningCall spawningCall;
    [SerializeField] private Spawning spawing;
    [SerializeField] private Transform startReproducy;
    [SerializeField] private Event eventMateChoice;
    [SerializeField] private MeroFollow meroFollow;
    [SerializeField] private GameEvents manager;
    public NavMeshAgent nav;
    public float MateChoiceTime;
    public bool endMateChoice;
    public bool ready = false;
    public float speed_start;
    public bool call = true;
    public bool stop;
    private float distance;
    public bool Return = true;

    //Estados
    private void Awake()
    {
        sex = GetComponent<Sex>();
        nav = GetComponent<NavMeshAgent>();
    }
    public enum MeroEstados
    {
        Movement,//vagar
        Start_Return,//seleção sexual e retorno
        SpawningAscent,//subida
        Spawning,// desova
    }
    public MeroEstados EstadoAtual = MeroEstados.Movement;
    
    private void Start()
    {
        SetEstados(MeroEstados.Movement);
    }
    private void Update()
    {
        switch (EstadoAtual)
        {
            case MeroEstados.Movement:

                movement.Control();
                if (sex.genero == Sex.Genero.Femea)
                {
                    spawningCall.Control();
                    if (spawningCall.Allow == true) 
                    SetEstados(MeroEstados.Start_Return);
                }
                break;
            case MeroEstados.Start_Return:

                //possivelmente ser apenas o movimento de ir para o meio e voltar para a reprodução
                attraction();
                if (Return)
                {
                    if (distance < 1f)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        spawningCall.startRandom = true;
                        nav.enabled = true;
                        eventMateChoice.end = false;
                        eventMateChoice.discontTime = 0f;
                        SetEstados(MeroEstados.Movement);
                    }
                }else{
                    if(!ready){
                        if (distance < 1f)
                        {
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                            ready = true;
                            nav.enabled = false;
                        }
                        }
                        else
                        {
                            eventMateChoice.Control();
                            if(eventMateChoice.end) {
                            SetEstados(MeroEstados.SpawningAscent);  
                            Return = true;
                            ready = false;
                            spawningCall.Allow = false;
                        }  
                        }
                    }

                break;
            case MeroEstados.SpawningAscent:
                AscentEnter();
                spawningAscent.Control();
                
                break;
            case MeroEstados.Spawning: 
                //GameEvents.Instance.AscentReproduceExit(this.gameObject);
               
                break;

        }
    }
    private void FixedUpdate()
    {
        if(EstadoAtual == MeroEstados.Movement) movement.Movimento();
    }

    //Functions
    public void SetEstados(MeroEstados novoEstado)
    {
        EstadoAtual = novoEstado;
    }
    public void AscentEnter()
    {
        GameEvents.Instance.AscentReproduceEnter(this.gameObject);

    }
    void attraction()
    {
        float strength = speed_start * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, startReproducy.position, strength);
        distance = Vector3.Distance(transform.position, startReproducy.position);
    }
}