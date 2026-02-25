using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class GravityFlip : MonoBehaviour
{
    
    [SerializeField] int RampOfset;

    [SerializeField] GameObject OpositRampa;
    void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.layer == 3)
        {
            if (OpositRampa != null)
            {
                DisableRampa();
            }
            Debug.Log(transform);
            Transform gracz = collision.transform;
            Kojot kojot = collision.GetComponent<Kojot>();
            float GravityDarection = Mathf.Round(transform.eulerAngles.z + RampOfset);
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
            case -90:
            case 270:
                Physics2D.gravity = new Vector2(-9.81f, 0);
                break;
            }
            gracz.eulerAngles = new Vector3(0,0,GravityDarection);
            kojot.StartCoroutine(kojot.ToGround());
        }
    }

    async void DisableRampa()
    {
        OpositRampa.SetActive(false);
        await Awaitable.WaitForSecondsAsync(2);
        OpositRampa.SetActive(true);
    }
}
