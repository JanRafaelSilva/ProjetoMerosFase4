using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
   
    //Ponto para o qual o personagem irá se mover
    private GameObject Point;
    //Variável NavMeshAgent Para configurar A movimentação do personagem
    private NavMeshAgent agent;
    void Start()
    {
        //Pega o Componente NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
        //Variaveis setadas como False para Não utilizar os eixos Y Baseado em 3 dimensões
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        // Encontra o ponto Na cena
        Point = GameObject.Find("Meros");

    }


    void Update()
    {
        //Faz o personagem se locomover pelo cenario até o point
        agent.SetDestination(Point.transform.position);
    }

}
