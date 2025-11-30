
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;



public class Kojot : MonoBehaviour
{
    public float v;
    public float a;
    float pos;
    float poskopia;
    public bool Ball = false;

    [SerializeField] PhysicsMaterial2D material;
    [SerializeField] PlayerInput input;
    private InputAction TouchWalk;//klikanie dzia³a jak dotaykanie (przez input debugger)
    private InputAction TouchBoost;
    private InputAction TouchPosicon;
    [SerializeField] Rigidbody2D rig;

    void Awake()
    {
        input = GetComponent<PlayerInput>();
        TouchWalk = input.actions["Press"];
        TouchBoost = input.actions["JumpBoost"];
        TouchPosicon = input.actions["Walk"];
    }
    void OnEnable()
    {
        TouchBoost.started += Boost;
        TouchBoost.Disable();
        TouchWalk.started += Walk;
    }
    void OnDisable()
    {
        TouchBoost.started -= Boost;
        TouchWalk.started -= Walk;
    }

    void FixedUpdate()
    {
        if (Ball == false)
        {
            pos = TouchPosicon.ReadValue<Vector2>().x;
            if ((pos > Screen.width / 2 && poskopia < Screen.width / 2) || (pos < Screen.width / 2 && poskopia > Screen.width / 2))
            {
                Stop();
            }
            poskopia = pos;

            if (math.abs(rig.linearVelocityX) > 10)
            {
                Debug.Log("Started");
                Ball = true;
                transform.localScale = new Vector3(0.5f,0.5f,1f);
                material.friction = 0f;
                TouchBoost.Enable();
                TouchWalk.Disable();
        }
        }
        if (math.abs(rig.linearVelocityX) < 10)
        {
            Debug.Log("Done");
            material.friction = 0.4f;
            transform.localScale = new Vector3(1f, 1f, 1f);
            Ball = false;
            TouchWalk.Enable();
            TouchBoost.Disable();
        }
    }
    void Stop()
    {
        rig.linearVelocityX = 0f;
        v = 50f;
    }
    async void Boost(InputAction.CallbackContext context)
    {
        while (TouchBoost.IsPressed())
        {
            Debug.Log(rig.linearVelocityX);
            rig.linearVelocityX *= 1.02f;
            await Awaitable.WaitForSecondsAsync(0.1f);
        }

    }
    async void Walk(InputAction.CallbackContext context)
    {
        while (TouchWalk.IsPressed())
        {
            if (Screen.width / 2 < pos)
            {
                rig.linearVelocityX = v * Time.deltaTime;
                v += a;
            }
            else
            {
                rig.linearVelocityX = -v * Time.deltaTime;
                v += a;
            }
            await Awaitable.FixedUpdateAsync();
        }
        await Awaitable.NextFrameAsync();
        if (Ball == false)
        {
            Stop();
        }

    }

}


