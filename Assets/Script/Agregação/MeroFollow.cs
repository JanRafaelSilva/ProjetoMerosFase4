using UnityEngine;
using UnityEngine.InputSystem;

public class MeroFollow : MonoBehaviour
{
    public InputActionAsset input;
    public InputAction action;
    [SerializeField] private GameObject id;
    public float dinx,diny, speed;
    public float _frequency = 1.0f;
    private Vector3 axis;
    public float _amplitude;
    public float time;
    public float y;
    private SpriteRenderer sprite;
    public int layer_bigger, layer_smaller;
    public float time_start;

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
                axis = transform.up;
                time += Time.deltaTime;
                float x = id.transform.localScale.x >= 1 ? dinx * -1 : dinx;
                y = Mathf.Cos(_frequency * time) * _amplitude;
                transform.localScale = new Vector3(id.transform.localScale.x, 1f, 1f);
                Vector3 id_pos = new Vector3(Mathf.MoveTowards(transform.position.x, id.transform.position.x + x, speed), id.transform.position.y + y, id.transform.position.z);
                if(y >= (_amplitude - 0.1f)) sprite.sortingOrder = layer_bigger;
                if(y <= ((_amplitude * -1) + 0.1f)) sprite.sortingOrder = layer_smaller;
            }else if(time_start <= 0f)
            {
                Debug.Log("tempo acabou");
                GameEvents.Instance.AscentReproduceEnter(null);
                //GameEvents.Instance.AscentReproduceExit(null);
            }
            if(action.WasCompletedThisFrame())
            {
                Debug.Log("voce soltou o botão");
                GameEvents.Instance.AscentReproduceEnter(null);
                //GameEvents.Instance.AscentReproduceExit(null);
            }

    }
    private void FollowExit(GameObject id)
    {
       // GameEvents.Instance.OnAscentReproduceEnter -= FollowEnter;
        Debug.Log("ta bommm");
        id.GetComponent<SpawningCall>().enabled = true;
    }
}
