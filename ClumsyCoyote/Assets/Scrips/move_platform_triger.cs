using UnityEngine;

public class move_platform_triger : MonoBehaviour
{
    public Transform Point;
    public Transform Square;
    public float moveSpeed = 2f;
    private Vector3 nextPosition;
    private bool Move = false;
    // Start is called before the first frame update
    void Start()
    {
        nextPosition = Point.position;
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        Move = true;
    }
    void Update()
    {
        if (Move)
        {
            Square.position = Vector3.MoveTowards (Square.position, nextPosition, moveSpeed  * Time.deltaTime);
        }
    }
}
