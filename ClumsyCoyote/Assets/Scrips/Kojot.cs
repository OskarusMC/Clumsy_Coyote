
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;



public class Kojot : MonoBehaviour
{
    public LayerMask maska;
    bool InAir;
    Vector3 oldPos;

    [SerializeField] Rigidbody2D rig;
    [SerializeField] PhysicsMaterial2D material;
    [SerializeField] PlayerInput input;
    private InputAction TouchBoost;//klikanie dzia³a jak dotaykanie (przez input debugger)
 
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, -transform.up*3);
    }
    void Awake()
    {
        TouchBoost = input.actions["JumpBoost"];
    }
    void OnEnable()
    {
        TouchBoost.started += Boost;
        TouchBoost.canceled += Jump;
    }
    void OnDisable()
    {
        TouchBoost.started -= Boost;
        TouchBoost.canceled -= Jump;

    }
    void Start()
    {
        rig.linearVelocity += 0.05f * new Vector2(transform.right.x, transform.right.y);
    }
    void Update()
    {
        if (Physics2D.Raycast(transform.position, -transform.up, 3f, maska))
        {
            TouchBoost.Enable();
            InAir = false;
        }
        else
        {
            TouchBoost.Disable();
            InAir = true;
        }
    }

    void FixedUpdate()
    {
        if (rig.linearVelocityX <= 50 && rig.linearVelocityY <= 50 && InAir == false)
        {
            if (InAir == false)//<- Problem! musi byæ je¿eli porusza siê w prawo to (wzglêdniaj¹c rotacje) (narazie da³em placeholder)
            {
                rig.linearVelocity += 0.05f * new Vector2(transform.right.x, transform.right.y);
            }
            else
            {
                rig.linearVelocity -= 0.05f * new Vector2(transform.right.x, transform.right.y);
            }
        }
    }

    async void Boost(InputAction.CallbackContext context)
    {
        while (TouchBoost.IsPressed())
        {
            if (rig.linearVelocityX <= 50 && rig.linearVelocityY <= 50)
            {
                Debug.Log("'how'");
                rig.linearVelocity *= 1.003f;
            }
            await Awaitable.FixedUpdateAsync();
        }
    }
    void Jump(InputAction.CallbackContext context)
    {
        switch (transform.eulerAngles.z)
        {
            case 0:
                rig.linearVelocityY = 2 / 5f * math.abs(rig.linearVelocityX)  + 20;
                Debug.Log('U');
                break;  
            case 90:
                rig.linearVelocityX = -2 / 5f * math.abs(rig.linearVelocityY) - 20;
                Debug.Log('L');
                break;            
            case 180:
                rig.linearVelocityY = -2 / 5f * math.abs(rig.linearVelocityX) - 20;
                Debug.Log('D');
                break;                
            case 270:
                rig.linearVelocityX = 2 / 5f * math.abs(rig.linearVelocityY) + 20;
                Debug.Log('R');
                break;
        }


    }


}

//if (Ball == false)
//{

//    if (math.abs(rig.linearVelocityX) > 10)
//    {
//        Debug.Log("Started");
//        Ball = true;
//        transform.localScale = new Vector3(0.5f,0.5f,1f);
//        material.friction = 0f;
//        TouchBoost.Enable();
//        TouchWalk.Disable();
//        Speed();
//}
//}
//if (math.abs(rig.linearVelocityX) < 10)
//{
//    Debug.Log("Done");
//    material.friction = 0.4f;
//    transform.localScale = new Vector3(1f, 1f, 1f);
//    Ball = false;
//    TouchWalk.Enable();
//    TouchBoost.Disable();
//}

//    pos = TouchPosicon.ReadValue<Vector2>().x;
//    if ((pos > Screen.width / 2 && poskopia < Screen.width / 2) || (pos < Screen.width / 2 && poskopia > Screen.width / 2))
//    {
//        rig.linearVelocityX = 0f;
//v = 50f;
//    }
//    poskopia = pos;

//async void Walk(InputAction.CallbackContext context)
//{
//    while (TouchWalk.IsPressed())
//    {
//        if (Screen.width / 2 < pos)
//        {
//            rig.linearVelocityX = v * Time.deltaTime;
//            v += a;
//        }
//        else
//        {
//            rig.linearVelocityX = -v * Time.deltaTime;
//            v += a;
//        }
//        await Awaitable.FixedUpdateAsync();
//    }
//    await Awaitable.NextFrameAsync();
//    if (Ball == false)
//    {
//        Stop();
//    }

//}

