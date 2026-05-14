using Unity.VisualScripting;
using UnityEngine;

public class FêmeaDesova : MonoBehaviour
{
    public float RandomTimeDesova, max, min;
    public bool Allow;
    [SerializeField] private Desova reproduction;
    public void RandomTime()
    {
        //Intervalo entre Desovas
        RandomTimeDesova = Random.Range(max, min);
    }
    public void RandomDesova()
    {
        //Permissão para desovar
        Allow = Random.value < 0.5f;
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
            reproduction.Allow();
        }
    }
}
