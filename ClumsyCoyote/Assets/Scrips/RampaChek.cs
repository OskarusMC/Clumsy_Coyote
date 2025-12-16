using UnityEngine;

public class RampaChek : MonoBehaviour
{
    [SerializeField] LayerMask LayerMask;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, -transform.up * 7);
        Gizmos.DrawRay(transform.position, transform.right * 7);
    }

    void Start()
    {
        RaycastHit2D ray1 = Physics2D.Raycast(transform.position, -transform.up, 7f, LayerMask);
        RaycastHit2D ray2 = Physics2D.Raycast(transform.position, transform.right, 7f, LayerMask);
        Debug.Log(ray1.collider.gameObject.name);
        Debug.Log(ray2.collider.gameObject.name);
        if (ray1 && ray2)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
