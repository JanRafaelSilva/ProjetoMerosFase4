using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string Fase;
    void OnTriggerEnter2D(Collider2D c)
    {
        SceneManager.LoadScene(Fase);
    }
}
