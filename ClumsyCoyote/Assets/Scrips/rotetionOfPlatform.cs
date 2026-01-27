using UnityEngine;

public class rotetionOfPlatform : MonoBehaviour
{
    public Transform platforma;
    public Transform rotacja1;
    public Transform rotacja0;
    public float MoveSpeed = 2f;
    public bool ObtutWPrawo;
    private bool Move1 = false;
    public rotetionOfPlatform SecondRotation;
    public void StopRotation()
    {
        Move1 = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Move1 = true;
        SecondRotation.StopRotation();
    }
    void FixedUpdate()
    {
        if (Move1 == true)
        {
            if (Quaternion.Angle(platforma.rotation, rotacja1.rotation) > 0.1f)
            {
                platforma.rotation = Quaternion.RotateTowards (platforma.rotation, rotacja1.rotation, MoveSpeed * Time.deltaTime);
            } else {
                Move1 = false;
            }
        }
    }
}
