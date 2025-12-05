using UnityEngine;

public class CameraS : MonoBehaviour
{
    public Transform gracz;
    void Update()
    {
        transform.position = gracz.position + new Vector3(0f,0.5f,-10f);
    }
}
