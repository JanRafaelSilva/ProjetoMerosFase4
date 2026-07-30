using System.IO;
using UnityEngine;

public class BoatHarpoon : MonoBehaviour
{
    private float timer;
    public float timerMax;
    private Harpoon arm;
    BoatHarpoon my;
    public GameObject harpoon;
    public Transform Mero;
    public void Awake()
    {
        arm = harpoon.GetComponent<Harpoon>();
        my = GetComponent<BoatHarpoon>();
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
        arm.PlayerScene(Mero, transform);
        Instantiate(arm, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        timer = 0;
    }
}
