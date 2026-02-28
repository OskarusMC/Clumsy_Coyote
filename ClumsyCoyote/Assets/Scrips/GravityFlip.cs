using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class GravityFlip : MonoBehaviour
{

    [SerializeField] int RampOfset;
    [SerializeField] bool trigger2;

    [SerializeField] GameObject OpositRampa;
    GravityFlip OpositRampaScript;
    Kojot kojot;

    void Start()
    {
        kojot = Kojot.Instance.GetComponent<Kojot>();
        if (trigger2)
        {
            OpositRampaScript = OpositRampa.GetComponent<GravityFlip>();
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        kojot.CorMange(false);
        if (collision.gameObject.layer == 3 && !trigger2)
        {
            if (OpositRampa != null)
            {
                DisableRampa();
            }
            
            Transform gracz = collision.transform;

            float GravityDarection = transform.eulerAngles.z + RampOfset;
            switch (Mathf.Round(GravityDarection % 360))
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
            gracz.eulerAngles = new Vector3(0,0,Mathf.Round(GravityDarection));
            kojot.CorMange(true);
        }
        else if (trigger2)
        {
            ActivateRampa();
        }
    }

    async void DisableRampa()
    {
        OpositRampa.SetActive(false);
        await Awaitable.WaitForSecondsAsync(2);
        OpositRampa.SetActive(true);
    }
    async void ActivateRampa()
    {
        OpositRampaScript.trigger2 = false;
        await Awaitable.WaitForSecondsAsync(2);
        OpositRampaScript.trigger2 = true;
    }
}
