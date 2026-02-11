using UnityEngine;

public class CameraS : MonoBehaviour
{

    // Ca�y ten skrypt b�dzie do zmiany narazie to placecholder

    void LateUpdate()
    {
        transform.position = Kojot.Instance.transform.position + new Vector3(0f,0.5f,-10f);
    }
}
