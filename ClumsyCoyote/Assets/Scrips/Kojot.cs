
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;



public class Kojot : MonoBehaviour
{
    public LayerMask maska;

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

    void Update()
    {
        if (Physics2D.Raycast(transform.position, -transform.up, 3f, maska))
        {
            TouchBoost.Enable();
        }
        else
        {
            TouchBoost.Disable();
        }
    }

    void FixedUpdate()
    {
        if (rig.linearVelocityX <= 50 || rig.linearVelocityX <= 50)
        {
            if (rig.linearVelocityX >= 0)
            {

                rig.AddRelativeForce(Vector3.right * 30f);
            }
            else
            {
                rig.AddRelativeForce(Vector3.left * 30f);
            }
        }
    }

    async void Boost(InputAction.CallbackContext context)
    {
        while (TouchBoost.IsPressed())
        {
            if (rig.linearVelocityX <= 50 || rig.linearVelocityX <= 50)
            {
                rig.linearVelocity *= 1.001f;
            }
            await Awaitable.FixedUpdateAsync();
        }
    }
    void Jump(InputAction.CallbackContext context)
    {
        rig.AddRelativeForce(Vector3.up * 20000f);

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

