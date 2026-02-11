using UnityEngine;
using UnityEngine.UIElements;

public class GravityPull : MonoBehaviour
{
    [SerializeField] Rigidbody2D PlayerRig;
    public float moc;

    void OnTriggerStay2D(Collider2D collision)
    {
        float Distanse = Vector2.Distance(transform.position, Kojot.Instance.transform.position);
        Vector2 Pull = (transform.position - Kojot.Instance.transform.position).normalized / Distanse * moc;
        PlayerRig = collision.GetComponent<Rigidbody2D>();
        PlayerRig.AddForce(Pull,ForceMode2D.Force);
    }
}
