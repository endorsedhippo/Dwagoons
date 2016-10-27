using UnityEngine;
using System.Collections;
using InControl;



[RequireComponent (typeof (Animator))]
public class DragonControllerFly : MonoBehaviour
{
    public float moveSpeed;
    public int playerIndex;


    Rigidbody rb;

    private InputDevice device;
    private DragonManager manager;
    

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        manager = GetComponent<DragonManager>();

        if (InputManager.Devices.Count <= playerIndex)
        {
            return;
        }
        device = InputManager.Devices[playerIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
        //Movement
        if(moveSpeed >= 15)
        {
            if (device.LeftStickX.Value < -0.1f)
            {//Left
            
                manager.velocity -= transform.right * Time.deltaTime;
                transform.Rotate(0, -0.7f, 0);
            }
            else if (device.LeftStickX.Value > 0.1f)
            {//Right
           
                manager.velocity += transform.right * Time.deltaTime;
                transform.Rotate(0, 0.7f, 0);
            }
        }
        if (device.LeftStickY.Value == 1)
        {
            manager.velocity += transform.forward * Time.deltaTime * moveSpeed;
        }
        if (device.LeftStickY.Value < -0.1f)
        {//Backwards
            moveSpeed -= 1.0f;
        }
        else if (device.LeftStickY.Value > 0.1f)
        {//Forwards
            moveSpeed += 0.2f;
            manager.velocity += transform.forward * Time.deltaTime;
            //rb.drag -= 0.03f;
        }

        //If the left stick isn't moving, reduce speed
        if(device.LeftStick.Vector == new Vector2(0, 0))
        {
            moveSpeed -= 0.2f;
        }
        // air resistance
        manager.velocity *= 0.99f;

        // keep on moving
        transform.position = transform.position + manager.velocity * Time.deltaTime * moveSpeed;
        transform.Rotate(0, 0, 0);


        if(moveSpeed >= 40)
        {
            moveSpeed = 40;
        }

    }


}