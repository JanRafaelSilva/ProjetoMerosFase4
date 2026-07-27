using System;
using System.Collections.Generic;
using UnityEngine;
using static FSM;

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
    public float MateChoiceTime;
    public bool endMateChoice;
    public bool ready = false;
    public float speed_start;


    bool random = true;
    //Estados
    private void Awake()
    {
        sex = GetComponent<Sex>();
    }
    public enum MeroEstados
    {
        Movement,//vagar
        MateChoice,//seleção sexual
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
                    SetEstados(MeroEstados.MateChoice);
                }
                break;
            case MeroEstados.MateChoice:
                
                if(!ready){
                    
                    float strength = speed_start * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, startReproducy.position, strength);
                    float distance = Vector3.Distance(transform.position, startReproducy.position);
                    if (distance < 1f)
                    ready = true;
                }
                else
                {
                    eventMateChoice.Control();
                    if(eventMateChoice.end) SetEstados(MeroEstados.SpawningAscent); 
                }

                break;
            case MeroEstados.SpawningAscent:
                    
                spawningAscent.Control();

                break;

            case MeroEstados.Spawning:

                break;

        }
    }
    private void FixedUpdate()
    {
        if(EstadoAtual == MeroEstados.Movement) movement.Movimento();
    }

    //Functions
    void SetEstados(MeroEstados novoEstado)
    {
        EstadoAtual = novoEstado;
    }
}