using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject PainelNarrativa;
    public void Jogar()
    {
        SceneManager.LoadScene("Fase1");
        Time.timeScale = 1;
    }
    public void AbrirNarrativa()
    {
        PainelNarrativa.SetActive(true);
    }
    public void FecharNarrativa()
    {
        PainelNarrativa.SetActive(false);
    }
    public void Controles()
    {
        
    }
    public void Créditos()
    {
        
    }
    public void Acessibilidade()
    {

    }

    public void SairDoJogo()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
        Application.OpenURL(webplayerQuitURL);
#else
        Application.Quit();
#endif
    }
}
