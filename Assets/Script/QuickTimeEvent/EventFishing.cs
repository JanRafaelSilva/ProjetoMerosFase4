using UnityEngine;

public class EventFishing : MonoBehaviour
{

    public ZoomCamera zoom;
    public CameraFollow follow;

    //foi pego
    public bool eventFished;
    public float timeEscape;
    public void Fishing()
    {
        //ativar
        zoom.enabled = true;
        eventFished = true;
        follow.QuickTimeEvent(true);
        Time.timeScale = 0;
    }
    private void Update()
    {
        MeroFished();
    }
    void MeroFished()
    {
        /*if (eventFished)
        {
            zoom.Minigame(true);
            timeEscape += Time.deltaTime;
            if(timeEscape >= 5f)
            {
                zoom.Minigame(false);
                timeEscape = 0;
                follow.QuickTimeEvent(false);
            }
        }*/
    }
}
