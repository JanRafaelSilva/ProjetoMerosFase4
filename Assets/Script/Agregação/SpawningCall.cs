using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class SpawningCall : MonoBehaviour
{
    public float RandomTimeDesova, max, min;
    public bool Allow;

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
    public void Control()
    {
        if (RandomTimeDesova >= 0)
        {
            RandomTimeDesova -= Time.deltaTime;
        }
        else
        {
            RandomDesova();
        }
    }
}
