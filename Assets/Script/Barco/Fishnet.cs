using UnityEngine;

public class Fishnet : MonoBehaviour
{
   public EventFishing net_event;

   void OnTriggerEnter2D(Collider2D collision)
   {

        if(collision.CompareTag("Player"))
        {
                net_event.Fishing(this.gameObject);
        }
   }
   public void net(EventFishing net_event)
   {
        this.net_event = net_event;
   }
}
