using System;
using UnityEngine;

public class BarcoRede : MonoBehaviour
{
    public GameObject Player;
    public GameObject Rede;
    public MoveRede rede;
    public float distance = 20;
    float timer;
    public bool found = false;
    public float redeTime = 3f;
    private void Awake()
    {
        rede = GetComponent<MoveRede>();
    }
    public void RayQuest()
    {
        found = Physics2D.Raycast (transform.position, new Vector2(Player.transform.position.x, Player.transform.position.y), distance, LayerMask.NameToLayer("Player")); 
    }
    void FixedUpdate()
    {
        RayQuest();
    }
    void Update()
    {
        if (found)
        {
            timer += Time.deltaTime;
            if(timer > redeTime)
            {
                Instantiate(Rede, new Vector2(transform.position.x + 5f, transform.position.y + 2f), Quaternion.identity);
                //rede.
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
