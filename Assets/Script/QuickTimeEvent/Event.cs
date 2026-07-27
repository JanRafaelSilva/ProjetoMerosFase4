using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Event : MonoBehaviour
{
    public float time;
    public float discontTime;
    public bool end = false;
    [SerializeField] GameObject Space;
    [SerializeField] Image Clock;
    public InputActionAsset input;
    public InputAction action;


    private void OnEnable()
    {
        input.FindActionMap("UI").Enable();
    }
    private void OnDisable()
    {
        input.FindActionMap("UI").Disable();
    }
    private void Start()
    {
      action  = InputSystem.actions.FindAction("QuickTimeEvent");
    }
    public void Control()
    {
        
        discontTime += Time.deltaTime;
        float amount = time - discontTime;
        if(time >= 0f || !end)
        {
            Space.SetActive(true);
            Clock.fillAmount = amount / time;
        }else
        {
            Space.SetActive(false);
        }
        if(action.WasPressedThisFrame())
        {
            end = true;
            Space.SetActive(false);
        }
    }
}
