using UnityEngine;

public class CameraS : MonoBehaviour
{

    // Ca³y ten skrypt bêdzie do zmiany narazie to placecholder

    [SerializeField] Transform gracz;
    void LateUpdate()
    {
        transform.position = gracz.position + new Vector3(0f,0.5f,-10f);
        transform.rotation = gracz.rotation;
    }
}
