using UnityEngine;

public class RampaChek : MonoBehaviour
{
    [SerializeField] LayerMask LayerMask;
    [SerializeField] float rayDistanse;
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, -transform.up * rayDistanse);
        Gizmos.DrawRay(transform.position, transform.right * rayDistanse);
    }

    void Start()
    {
        RaycastHit2D ray1 = Physics2D.Raycast(transform.position, -transform.up, rayDistanse, LayerMask);
        RaycastHit2D ray2 = Physics2D.Raycast(transform.position, transform.right, rayDistanse, LayerMask);
        if (ray1 && ray2)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
