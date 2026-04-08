using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class MoveDesova : MonoBehaviour
{
    public float target = 3f;
    public float  step = 1f;
    public Vector2 direction;
    public bool movimento;
    private Vector2 centre;

    private float RotateSpeed = 1f;
    private float Radius = 3f;

    private float angle;

    public void Start()
    {
        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y + target), step);
        direction = new Vector2(-1f, -1f);
        centre = new Vector2(transform.position.x, transform.position.y - Radius);
    }
    public void Update()
    {
            MovimentoCircular();
    }
    public void MovimentoCircular()
    {
        angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
        transform.position = centre + offset;

    }

    }
