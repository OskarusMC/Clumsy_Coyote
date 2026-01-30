using UnityEngine;

public class rotetionOfPlatform : MonoBehaviour
{
    public Transform platforma;
    public Transform rotacja1;
    public Transform rotacja0;
    public float MoveSpeed = 2f;
    private bool Move1 = false;
    private bool Move0 = false;
    private float timer;
    public float delayBeforeReturn = 2f;
    public rotetionOfPlatform SecondRotation;
    public void StopRotation()
    {
        Move1 = false;
        Move0 = false;
        timer = 0f;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Move1 = true;
            timer = 0f;
            SecondRotation.StopRotation();
        }
    }
    void FixedUpdate()
    {
        if (Move1 == true)
        {
            if (Quaternion.Angle(platforma.rotation, rotacja1.rotation) > 0.001f)
            {
                platforma.rotation = Quaternion.RotateTowards (platforma.rotation, rotacja1.rotation, MoveSpeed * Time.deltaTime);
            } else {
                Move1 = false;
                timer = delayBeforeReturn;
            }
        }
        if (Move1 == false && timer > 0f)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
                Move0 = true;
        }
        
        if (Move0 == true)
        {
            platforma.rotation = Quaternion.RotateTowards (platforma.rotation, rotacja0.rotation, MoveSpeed * Time.deltaTime);
            if (Quaternion.Angle(platforma.rotation, rotacja0.rotation) < 0.001f)
            {
                Move0 = false;
            }
        }
    }
}
