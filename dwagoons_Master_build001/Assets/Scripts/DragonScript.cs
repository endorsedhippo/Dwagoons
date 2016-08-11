using UnityEngine;
using System.Collections;
using InControl;


//THIS SCRIPT IS JUST TO TEST DIFFERENT WAYS TO DO THINGS FOR DRAGON MOVEMENT / ABILITIES etc...
public class DragonScript : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    public float heightControl;
    public bool isGrounded = false;

    public int playerIndex;

    LayerMask layer = 1 << 8;
    Rigidbody rb;
    RaycastHit hit;

    private float limiter = 0;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1.2f, layer))
        {
            Debug.Log("Ground Hit");
            isGrounded = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 100, Color.white);
            Debug.Log("Did not hit");
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        if (InputManager.Devices.Count <= playerIndex)
        {
            return;
        }
        InputDevice device = InputManager.Devices[playerIndex];

        Vector3 velocity = rb.velocity;
        //Height control
        if (device.LeftTrigger.IsPressed)
        {
            velocity.y -= heightControl;
        }
        else if (device.RightTrigger.IsPressed)
        {
            velocity.y += heightControl;
        }
        rb.velocity = velocity;

        //Movement
        if (device.LeftStickX.Value < -0.05)
        {
            transform.position -= transform.right * Time.deltaTime * moveSpeed;
        }
        else if (device.LeftStickX.Value > 0.05)
        {
            transform.position += transform.right * Time.deltaTime * moveSpeed;
        }
        if (device.LeftStickY.Value < -0.05)
        {
            transform.position -= transform.forward * Time.deltaTime * moveSpeed;
        }
        else if (device.LeftStickY.Value > 0.05)
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }



        //Rotation
        if(device.RightStickX.Value < -0.1)
        {
            transform.Rotate(0, -rotateSpeed, 0);
            
        }
        else if(device.RightStickX > 0.1)
        {
            transform.Rotate(0, rotateSpeed, 0);
        }
        
    }  
}
