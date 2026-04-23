using System.IO;
using UnityEngine;

public class BoatAnzol : MonoBehaviour
{
    public float timer, timerMax;
    public Anzol anzol;
    BoatAnzol my;
    public GameObject Anzol;
    public Transform Mero;
    public void Awake()
    {
        anzol = Anzol.GetComponent<Anzol>();
        my = GetComponent<BoatAnzol>();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timerMax)
        {
            ins();
        }
        if(Mero.position.x <= transform.position.x)
        {
            ins();
            my.enabled = false;
        }
    }
    void ins()
    {
        Instantiate(Anzol, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        anzol.PlayerScene(Mero, transform);
        timer = 0;
    }
}
