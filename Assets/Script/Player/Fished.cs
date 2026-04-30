using UnityEngine;

public class Fished : MonoBehaviour
{
    public EventFishing fishing;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Anzol"))
        {
            //fishing.Fishing();
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            
        }
    }
}
