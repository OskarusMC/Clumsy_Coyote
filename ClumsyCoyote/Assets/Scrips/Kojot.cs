
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
        TouchBoost.canceled += Jump;
        TouchBoost.Disable();
        TouchWalk.started += Walk;
    }
    void OnDisable()
    {
        TouchBoost.canceled -= Jump;
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
                Speed();
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
    async void Speed()
    {
        while (Ball && rig.linearVelocityX <= 50)
        {
            rig.linearVelocityX += 0.02f;
            Debug.Log(rig.linearVelocityX);
            await Awaitable.FixedUpdateAsync();
        }
    }
    async void Boost(InputAction.CallbackContext context)
    {
        while (TouchBoost.IsPressed())
        {
            if (rig.linearVelocityX <= 50)
            {
                 rig.linearVelocityX *= 1.001f;
                 
            }
            await Awaitable.WaitForSecondsAsync(0.01f);
        }
    }
    void Jump(InputAction.CallbackContext context)
    {
        rig.linearVelocityY = math.pow(math.abs(rig.linearVelocityX),1/3f) * 10;
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


