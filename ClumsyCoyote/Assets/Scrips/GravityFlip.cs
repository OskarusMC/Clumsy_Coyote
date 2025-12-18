using System.Collections;
using UnityEngine;

public class GravityFlip : MonoBehaviour
{
    
    [SerializeField] int RampOfset;
    public bool ignore = false;

    [SerializeField] GameObject OpositRampa;
    void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.layer == 3 && ignore == false)
        {
            StartCoroutine(DisableRampa());
            Transform gracz = collision.transform;
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
            case -90:
            case 270:
                Physics2D.gravity = new Vector2(-9.81f, 0);
                break;
            }
            gracz.eulerAngles = new Vector3(0,0,GravityDarection);
            }
        else if(ignore){
            StartCoroutine(NextRampa());
        }
    }
    IEnumerator NextRampa()// CORUTINA SIÊ ZATRZYMUJE GDY OBIEKT NIE ISTNIEJE :( :( :( :( :(
    { 
        GravityFlip dalej = OpositRampa.GetComponent<GravityFlip>();
        dalej.ignore = false;
        yield return new WaitForSeconds(1);
        dalej.ignore = true;
    }
        IEnumerator DisableRampa()
    {
        OpositRampa.SetActive(false);
        yield return new WaitForSeconds(1);
        OpositRampa.SetActive(true);
    }
}
