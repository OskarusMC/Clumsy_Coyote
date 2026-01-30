using UnityEngine;
using System.Collections;

public class ZnikającaPlatforma : MonoBehaviour
{
    public float Timer;
    public float WaitTime;
    private bool isActive;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(isActive == false)
        {
            StartCoroutine(DisablePhysics());
        }
    }
    IEnumerator DisablePhysics()
    {
        isActive = true;
        yield return new WaitForSeconds(Timer);
        rb.simulated = false;
        yield return new WaitForSeconds(WaitTime);
        rb.simulated = true;
        isActive = false;
    }
}
