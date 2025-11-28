using UnityEngine;
using UnityEngine.InputSystem;


public class Kojot : MonoBehaviour
{
    public float v;
    public InputAction PlayerInput;
    [SerializeField] Rigidbody2D rig;
    [SerializeField] Vector2 MovmentInput;

    void OnEnable()
    {
        PlayerInput.Enable();//wymagana rzecz by input dzia³a³
    }
    void OnDisable()
    {
        PlayerInput.Disable();//wymagana rzecz by input dzia³a³
    }
    void Update()
    {
        MovmentInput = PlayerInput.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        rig.linearVelocity = new Vector2(MovmentInput.x * v,rig.linearVelocityY);
    }
}
