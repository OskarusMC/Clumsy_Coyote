using UnityEngine;

public class rotetionOfPlatform : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform platforma;
    public Transform rotacja;
    public float moveSpeed = 2f;
    private bool Move = false;
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        Move = true;
    }
    void Update()
    {
        if (Move == true)
        {
            platforma.rotation = Quaternion.RotateTowards (platforma.rotation, rotacja.rotation, moveSpeed  * Time.deltaTime);
        }
    }
}
