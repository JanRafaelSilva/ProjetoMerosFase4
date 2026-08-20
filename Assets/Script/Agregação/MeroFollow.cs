using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeroFollow : MonoBehaviour
{
    public InputActionAsset input;
    public InputAction action;
    [SerializeField] private GameObject id;
    public float dinx,diny, speed;
    public float _frequency = 1.0f;
    public float _amplitude;
    public float time;
    private SpriteRenderer sprite;
    public int layer_bigger, layer_smaller;
    public float time_start;
    public bool follow;

    private void OnEnable()
    {
        input.FindActionMap("Player").Enable();
    }
    private void OnDisable()
    {
        input.FindActionMap("Player").Disable();
    }
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
      action  = InputSystem.actions.FindAction("Keep");
      GameEvents.Instance.OnAscentReproduceEnter += FollowEnter;
      GameEvents.Instance.OnAscentReproduceExit += FollowExit;
    }
    private void FollowEnter(GameObject id)
    {
        id.GetComponent<SpawningCall>().enabled = false;
            time_start-= Time.deltaTime;
            if(action.IsPressed())
            {
                time += Time.deltaTime;
                float x = id.transform.localScale.x >= 1 ? dinx * -1 : dinx;
                float y = Mathf.Cos(_frequency * time) * _amplitude;
                transform.localScale = new Vector3(id.transform.localScale.x, 1f, 1f);
                Vector3 id_pos = new Vector3(Mathf.MoveTowards(transform.position.x, id.transform.position.x + x, speed), id.transform.position.y + y, id.transform.position.z);
                transform.position = id_pos;
                if(y >= (_amplitude - 0.1f)) sprite.sortingOrder = layer_bigger;
                if(y <= ((_amplitude * -1) + 0.1f)) sprite.sortingOrder = layer_smaller;
            }else if(time_start <= 0f)
            {
                //IsAscentEnterEmpty();
               // id.GetComponent<FSM>().stop = true;
                GameEvents.Instance.AscentReproduceExit();
                //Debug.Log("funcionou");
            }
            if(action.WasCompletedThisFrame())
            {
                //IsAscentEnterEmpty();
                //id.GetComponent<FSM>().stop = true;
                GameEvents.Instance.AscentReproduceExit();
                //Debug.Log("funcionou");
            }

    }
    private void FollowExit()
    {
       GameEvents.Instance.OnAscentReproduceEnter -= FollowEnter;
       Debug.Log("Entrou aqui:");
        //id.GetComponent<SpawningCall>().enabled = true;
    }
}
