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

    bool random = true;
    //Estados
    private void Awake()
    {
        sex = GetComponent<Sex>();
    }
    public enum MeroEstados
    {
        Movement,//vagar
        SpawningAscent,//subida/decida
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
                    if (spawningCall.Allow == true) SetEstados(MeroEstados.SpawningAscent);
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
//1: a fêmea entra no momento reprodutivo - spawningCall
//2: ela libera um sinal aos outros machos e se movimenta ao topo - SpawningAscent
//3: em um Quick time Event ele terminara a reprodução - Spawning