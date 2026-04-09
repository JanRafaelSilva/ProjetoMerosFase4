using UnityEngine;

public class BoatAnzol : MonoBehaviour
{
    public float timer, timerMax;
    public GameObject Anzol;
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timerMax)
        {
            Instantiate(Anzol, new Vector2(transform.position.x, transform.position.y - 5), Quaternion.identity);
            timer = 0;
        }
    }
}
