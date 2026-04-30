using System;
using UnityEngine;

public class BoatFishnet : MonoBehaviour
{
    public Transform Player;
    public GameObject Rede;
    public float timer;
    public float redeTime = 3f;

    //raycast
    private int bitMero,bitPedra;
    private int 
    maskMero = 7, 
    maskPedra = 6;
    private bool vision;

    public void RayQuest()
    {
        // 1 == true - número da layer recebe 1.
        bitMero = 1 << maskMero;
        bitPedra = 1 << maskPedra;
        // vision = true - mero na visão, = false - pedra na visão.
        vision = Physics2D.Raycast (transform.position, Player.transform.position,Vector3.Distance(transform.position, Player.transform.position), bitMero) 
        || !Physics2D.Raycast (transform.position, Player.transform.position,Vector3.Distance(transform.position, Player.transform.position), bitPedra); 
    }
    void FixedUpdate()
    {
        RayQuest();
    }
    void Update()
    {
        if (vision == true)
        { 
            //tempo para identificar o mero
            timer += Time.deltaTime;
            if(timer > redeTime)
            {
                //lançar rede
                Instantiate(Rede, new Vector2(transform.position.x + 5f, transform.position.y + 2f), Quaternion.identity);
                timer = 0f;
            }
        }
        else
        {
            timer = 0f;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0.75f, 0.0f, 0.0f, 0.75f);
        Gizmos.DrawLine(transform.position, Player.transform.position);
    }
    }
