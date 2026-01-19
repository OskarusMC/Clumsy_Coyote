using UnityEngine;

public class move_object: MonoBehaviour
{
    public bool OneNextPosition;
    public bool Triger;
    public Transform PointA;
    public Transform PointB;
    public float MoveSpeed = 2f;
    private Vector3 nextPosition;
    private bool move = false;
    void Start()
    {
        nextPosition = PointA.position;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Triger == true)
        {
            move = true;
        }
    }
    void FixedUpdate(){
        if (Triger == false || move == true)
        {
            transform.position = Vector3.MoveTowards (transform.position, nextPosition, MoveSpeed  * Time.deltaTime);
            if (OneNextPosition == false)
            {
                if (transform.position == nextPosition)
                { 
                    nextPosition = (nextPosition == PointA.position)? PointB.position : PointA.position;
                    
                }
            }
        }
    }
}