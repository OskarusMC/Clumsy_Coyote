using UnityEngine;
using System.Collections;

public class ZnikającaPlatforma : MonoBehaviour
{
    public Sprite NormalSprite;
    public Sprite DisabledSprite;
    public float Timer;
    public float WaitTime;
    private bool isActive;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        sr = GetComponent<SpriteRenderer>();
        sr.sprite = NormalSprite;
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
        sr.sprite = DisabledSprite;

        yield return new WaitForSeconds(WaitTime);

        rb.simulated = true;
        sr.sprite = NormalSprite;

        isActive = false;
    }
}
