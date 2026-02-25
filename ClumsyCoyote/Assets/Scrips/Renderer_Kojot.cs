using UnityEngine;

public class Renderer_Kojot : MonoBehaviour
{
    [SerializeField] Rigidbody2D graczRig;
    [SerializeField] Transform gracz;

    float KRG;//KopjaRotacjiGracza
    Vector3 KRR;//KopjaRotacjiRendera
    void Start()
    {
        KRG = gracz.eulerAngles.z;
    }

    void FixedUpdate()
    {
        Spin();
    }

    void Update()
    {
        if (KRG != gracz.eulerAngles.z)
        {
            transform.eulerAngles = KRR;
            Spin();
        }
        KRG = gracz.eulerAngles.z;
        KRR = transform.eulerAngles;
    }

    void Spin()
    {
        switch (gracz.eulerAngles.z)
        {
            case 0:
                transform.Rotate(0f, 0f, -graczRig.linearVelocityX / 3);
                break;
            case 90:
                transform.Rotate(0f, 0f, -graczRig.linearVelocityY / 3);
                break;
            case 180:
                transform.Rotate(0f, 0f, graczRig.linearVelocityX / 3);
                break;
            case -90:
            case 270:
                transform.Rotate(0f, 0f, graczRig.linearVelocityY / 3);
                break;
        }
    }

}
