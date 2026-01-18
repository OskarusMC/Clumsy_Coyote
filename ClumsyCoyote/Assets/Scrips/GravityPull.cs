using UnityEngine;
using UnityEngine.UIElements;

public class GravityPull : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] Rigidbody2D PlayerRig;
    public float moc;

    void OnTriggerStay2D(Collider2D collision)
    {
        float Distanse = Vector2.Distance(transform.position, Player.position);
        Vector2 Pull = (transform.position - Player.position).normalized / Distanse * moc;
        PlayerRig.AddForce(Pull,ForceMode2D.Force);
        Debug.Log(Pull);
    }
}
