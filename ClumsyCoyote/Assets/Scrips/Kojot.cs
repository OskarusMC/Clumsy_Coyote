
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;



public class Kojot : MonoBehaviour
{
    public ContactFilter2D filter;
    RaycastHit2D[] results = new RaycastHit2D[1];

    [SerializeField] PhysicsMaterial2D material;
    [SerializeField] PlayerInput input;
    private InputAction TouchBoost;//klikanie dzia³a jak dotaykanie (przez input debugger)
    [SerializeField] Rigidbody2D rig;

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position - new Vector3(0f, 3f, 0f));
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
        int hit = Physics2D.Linecast(transform.position, transform.position - new Vector3(0f, 3f, 0f), filter, results);
        if (hit > 0)
        {
            TouchBoost.Enable();
        }
        else
        {
            TouchBoost.Disable();
        }
        Debug.Log(results[0].collider.gameObject.name);
    }

    void FixedUpdate()
    {
        if (rig.linearVelocityX <= 50)
        {
            if (rig.linearVelocityX >= 0)
            {
                rig.linearVelocityX += 0.02f;
            }
            else {
                rig.linearVelocityX -= 0.02f;
            }

            transform.eulerAngles -= new Vector3(0f,0f, 18/25f * rig.linearVelocityX);

        }
    }

    async void Boost(InputAction.CallbackContext context)
    {
        while (TouchBoost.IsPressed())
        {
            if (rig.linearVelocityX <= 50)
            {
                 rig.linearVelocityX *= 1.001f;
                Debug.Log(rig.linearVelocityX);                 
            }
            await Awaitable.FixedUpdateAsync();
        }
    }
    void Jump(InputAction.CallbackContext context)
    {
        rig.linearVelocityY = 2/5f * math.abs(rig.linearVelocityX) + 20;
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

