using UnityEngine;

public class move_object: MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;
    public float moveSpeed = 2f;
    private Vector3 nextPosition;
    // Start is called before the first frame update
    void Start()
    {
        nextPosition = PointB.position;
    }
    // Update is called once per frame
    void Update(){
        transform.position = Vector3.MoveTowards (transform.position, nextPosition, moveSpeed  * Time.deltaTime);

        if (transform.position == nextPosition)
        { 
            nextPosition = (nextPosition == PointA.position)? PointB.position : PointA.position;
            
    }
}
}