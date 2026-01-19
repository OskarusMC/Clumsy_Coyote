using UnityEngine;

public class rotetionOfPlatform : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform platforma;
    public Transform rotacja1;
    public Transform rotacja0;
    public float moveSpeed = 2f;
    private float timer = 3f;
    public int size = 0;
    // public Collider2D Triger2;
    private bool Move1 = false;
    // private bool Move2 = false;
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        Move1 = true;
        // Move2 = false;
    }
    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     Move2 = true;
    //     Move1 = false;
    // }
    void FixedUpdate()
    {
        if (Move1 == true)
        {
            if (platforma.rotation != rotacja1.rotation)
            {
                platforma.rotation = Quaternion.RotateTowards (platforma.rotation, rotacja1.rotation, moveSpeed  * Time.deltaTime);
            } else {
                Move1 = false;
                if ((timer-=Time.deltaTime) < 0)
                {
                    timer = 3f;
                    size++;
                    platforma.rotation = Quaternion.RotateTowards (platforma.rotation, rotacja0.rotation, moveSpeed  * Time.deltaTime);
                }
            }
        }
        // if (Move2 == true)
        // {
        //     if (platforma.rotation != rotacja2.rotation)
        //     {
        //         platforma.rotation = Quaternion.RotateTowards (platforma.rotation, rotacja2.rotation, moveSpeed  * Time.deltaTime);
        //     } else {
        //         Move2 = false;
        //     }
        // } 
    }
}
