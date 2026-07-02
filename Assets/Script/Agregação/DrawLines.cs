using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class DrawLines : MonoBehaviour
{
    private LineRenderer line;
    private Vector3 previousPosition;
    public Transform Player;
    Vector3 player;
    [SerializeField]
    private float minDistance = 0.1f;
    [SerializeField, Range(0.1f, 2f)]
    private float width;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 1;
        previousPosition =- transform.position;
        line.startWidth = line.endWidth = width;
    }
    public void Control()
    {
        player = Player.position;
        player.z = 0f;
        if(Vector3.Distance(player, previousPosition) > minDistance)
        {
            if(previousPosition == transform.position)
            {
                line.SetPosition(0, player);
            }
            else
            {
                line.positionCount++;
                line.SetPosition(line.positionCount - 1, player);
            }
            previousPosition = player;
        }
    }
}
