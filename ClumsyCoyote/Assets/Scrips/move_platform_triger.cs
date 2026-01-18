using UnityEngine;

public class move_platform_triger : MonoBehaviour
{
    public Transform Point;
    public Transform Square;
    public float moveSpeed = 2f;
    private Vector3 nextPosition;
    private bool Move = false;
    void Start()
    {
        nextPosition = Point.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Move = true;
    }
    void FixedUpdate()
    {
        if (Move)
        {
            Square.position = Vector3.MoveTowards (Square.position, nextPosition, moveSpeed  * Time.deltaTime);
        }
    }
}
