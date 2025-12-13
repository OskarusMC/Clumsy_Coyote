using System.Collections;
using UnityEngine;

public class GravityFlip : MonoBehaviour
{
    [SerializeField] int RampOfset;

    [SerializeField] GameObject OpositRampa;
    void OnTriggerEnter2D(Collider2D collision)
    {

        Transform gracz = collision.transform;
        StartCoroutine(DisableRampa());
        float GravityDarection = transform.eulerAngles.z + RampOfset;
        switch (GravityDarection % 360)
        {
            case 0:
                Physics2D.gravity = new Vector2(0,-9.81f);
                break;
            case 90:
                Physics2D.gravity = new Vector2(9.81f,0);
                break;
            case 180:
                Physics2D.gravity = new Vector2(0, 9.81f);
                break;
            case 270:
                Physics2D.gravity = new Vector2(-9.81f, 0);
                break;
        }
        gracz.eulerAngles = new Vector3(0,0,GravityDarection);
    }
    IEnumerator DisableRampa()
    {
        OpositRampa.SetActive(false);
        yield return new WaitForSeconds(2);
        OpositRampa.SetActive(true);
    }
}
