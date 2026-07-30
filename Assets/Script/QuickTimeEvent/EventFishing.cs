using UnityEngine;
using UnityEngine.InputSystem;

public class EventFishing : MonoBehaviour
{

    public ZoomCamera zoom;
    public CameraFollow follow;

    //foi pego
    public bool eventFished;
    public float time,timeEscape;
    public InputActionAsset input_system;
    public InputAction input;

    public float force = 0.5f;
    public float pull = 0.1f;
    public float limitForce = 900f;
    public float limitPull = -900f;
    public float timeScale;
    [SerializeField] private GameObject EventInterface; 
    [SerializeField] private  RectTransform imagem;
    GameObject net;
    private void OnEnable()
    {
        input_system.FindActionMap("UI").Enable();
    }
    private void OnDisable()
    {
        input_system.FindActionMap("UI").Disable(); 
    }
     private void Awake()
    {
        input = InputSystem.actions.FindAction("QuickTimeEvent");
    }
    public void Fishing(GameObject net)
    {
        //ativar
        this.net = net;
        zoom.enabled = true;
        eventFished = true;
        follow.QuickTimeEvent(true);
        Time.timeScale = timeScale;
        }
    private void Update()
    {
        MeroFished();
    }
    void MeroFished()
    {
        if (eventFished)
        {
            input_system.FindActionMap("Player").Disable(); 
                input_system.FindActionMap("UI").Enable(); 
            zoom.Minigame(true);
            time += Time.unscaledDeltaTime;
            EventInterface.SetActive(true);
            if(time <= timeEscape)
            {
                if(input.WasCompletedThisFrame())
                {
                    imagem.localPosition = new Vector3(imagem.localPosition.x + force, imagem.localPosition.y, imagem.localPosition.z);
                    if(imagem.localPosition.x >= limitForce)
                    {
                        EndEvent();
                    }
                }
                if(imagem.localPosition.x >= limitPull)
                {
                    imagem.localPosition = new Vector3(imagem.localPosition.x - pull, imagem.localPosition.y, imagem.localPosition.z);
                }
                else if(imagem.localPosition.x <= limitPull)
                {
                    imagem.localPosition = new Vector3(limitPull, imagem.localPosition.y, imagem.localPosition.z);
                }

            }
            if(time > timeEscape)
            {
                EndEvent();
            }
        }
    }
    void EndEvent()
    {
        input_system.FindActionMap("UI").Disable(); 
                input_system.FindActionMap("Player").Enable();
                imagem.localPosition = imagem.localPosition = new Vector3(limitPull, imagem.localPosition.y, imagem.localPosition.z);
                Destroy(net); 
        EventInterface.SetActive(false);
                zoom.Minigame(false);
                follow.QuickTimeEvent(false);
                Time.timeScale = 1f;
                time = 0f;
                eventFished = false;
    }
}
