
using UnityEngine;
using UnityEngine.InputSystem;



public class Kojot : MonoBehaviour
{
    public float v;
    public PlayerInput input;
    private InputAction TouchPress;//klikanie dzia³a jak dotaykanie (przez input debugger)
    private InputAction TouchPosicon;
    [SerializeField] Rigidbody2D rig;
    Vector2 pos;
    void Awake()
    {
        input = GetComponent<PlayerInput>();
        TouchPress = input.actions["Press"];
        TouchPosicon = input.actions["Walk"];
    }

    void FixedUpdate()
    {      
        pos = TouchPosicon.ReadValue<Vector2>();
        if (TouchPress.IsPressed())
        {
            if (Screen.width / 2 < pos.x)
            {
                rig.linearVelocity += new Vector2(v * Time.deltaTime, 0f);
            }
            else
            {
                rig.linearVelocity += new Vector2(-v * Time.deltaTime, 0f);
            }
        }
    }


}
