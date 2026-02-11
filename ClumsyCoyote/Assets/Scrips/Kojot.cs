
using NUnit.Framework;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;



public class Kojot : MonoBehaviour
{
    public static Kojot Instance;

    public LayerMask maska;
    bool InAir = true;

    public Rigidbody2D rig;
    public List<PhysicsMaterial2D> material;
    [SerializeField] PlayerInput input;
    private InputAction TouchBoost;//klikanie dzia�a jak dotaykanie
    private InputAction TouchBounce;


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, -transform.up*2.1f);
        Gizmos.DrawRay(transform.position, transform.right * 10);
        Gizmos.DrawRay(transform.position, -transform.right * 10);
    }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        TouchBoost = input.actions["JumpBoost"];
        TouchBounce = input.actions["TouchBounce"];
    }
    void OnEnable()
    {
        TouchBounce.performed += Bounce;
        TouchBoost.started += Boost;
        TouchBoost.canceled += Jump;
    }
    void OnDisable()
    {
        TouchBounce.performed -= Bounce;
        TouchBoost.started -= Boost;
        TouchBoost.canceled -= Jump;

    }
    void Start()
    {
        rig.linearVelocity += 0.05f * new Vector2(transform.right.x, transform.right.y);
    }
    void Update()
    {
        if (Physics2D.Raycast(transform.position, -transform.up, 2.1f, maska))
        {
            TouchBoost.Enable();
            if (InAir)
            {
                rig.sharedMaterial = material[0];
            }
            InAir = false;
        }
        else
        {
            TouchBoost.Disable();
            InAir = true;
        }


    }

    public IEnumerator ToGround()
    {
        Debug.Log("0");
        yield return new WaitForSeconds(0.5f);
        Debug.Log("1");
        while (InAir)
        {
            Debug.Log("2");
            yield return null;
        }
        Debug.Log("3");
        yield return ToAir();
    }
    public IEnumerator ToAir()
    {
        Debug.Log("4");
        while (!InAir)
        {
            Debug.Log("5");
            yield return null;
        }
        Debug.Log("6");
        Physics2D.gravity = new Vector2(0f, -9.81f);
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        rig.sharedMaterial = material[1];
    }
    void FixedUpdate()
    {
        if (rig.linearVelocityX <= 30 && rig.linearVelocityY <= 30 && rig.linearVelocityX != 0 && rig.linearVelocityY != 0)
        {
             rig.linearVelocity += 0.05f * new Vector2(math.abs(transform.right.x), math.abs(transform.right.y)) * (new Vector2(rig.linearVelocityX,rig.linearVelocityY) /  new Vector2(math.abs(rig.linearVelocityX), math.abs(rig.linearVelocityY)));
        }
    }

    async void Boost(InputAction.CallbackContext context)
    {
        while (TouchBoost.IsPressed())
        {
            if (rig.linearVelocityX <= 30 && rig.linearVelocityY <= 30)
            {
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
                break;  
            case 90:
                rig.linearVelocityX = -2 / 5f * math.abs(rig.linearVelocityY) - 20;
                break;            
            case 180:
                rig.linearVelocityY = -2 / 5f * math.abs(rig.linearVelocityX) - 20;
                break;                
            case 270:
                rig.linearVelocityX = 2 / 5f * math.abs(rig.linearVelocityY) + 20;
                break;
        }


    }

    void Bounce(InputAction.CallbackContext context)
    {
        if (Physics2D.Raycast(transform.position, transform.right, 10f, maska) || Physics2D.Raycast(transform.position, -transform.right, 10f, maska))
        {
            rig.sharedMaterial = material[2];
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

