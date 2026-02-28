using UnityEngine;

public class Killzone : MonoBehaviour
{
    public Transform Gracz;
    public Transform Respawn;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Gracz.position = Respawn.position;
    }
}
