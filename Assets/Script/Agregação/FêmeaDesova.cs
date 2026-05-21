using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class FêmeaDesova : MonoBehaviour
{
    public float RandomTimeDesova, max, min;
    public bool Allow;
    public MoveMero AgentMove;
    public FêmeaDesova control;
    [SerializeField] private MoveDesova reproduction;

    public void RandomTime()
    {
        //Intervalo entre Desovas
        RandomTimeDesova = Random.Range(max, min);
    }
    public void RandomDesova()
    {
        //Permissão para desovar
        Allow = Random.value < 0.5f;
        if (Allow == false)
        {
            RandomTime();
        }
    }
    private void Start()
    {
        RandomTime();
    }
    void Update()
    {
        if(RandomTimeDesova >= 0)
        {
            RandomTimeDesova -= Time.deltaTime;
        } 
        else
        {
            RandomDesova();
        }
        if (Allow)
        {
            reproduction.Allow(Allow);
            AgentMove.enabled = false;
            control.enabled = false;

        }
    }
}
