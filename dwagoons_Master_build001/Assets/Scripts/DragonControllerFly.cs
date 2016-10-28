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

    //Public Values for Sam to Change
    //To keep accurate... keep these values within 5.0f of the move speed of their respected fly script.
    //These variables are in order from top to bottom in the script.

    public float moveSpeedValue = 15; //The value at which turning becomes available. This value is used in the Manager script to control animations. 
    public float leftStickXValue = 0.1f; //The value of the left stick X at which the dragon will 'strafe'.
    public float turnCircle = 0.7f; //The turning circle of the dragon.

    public float leftStickYValue = 0.1f; //The value of the left stick Y at which the dragon will move forwards and backwards... this will effect the move speed variable slightly.


    public float moveSpeedCap = 40; //The max limit of the dragons speed;



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
        if(moveSpeed >= moveSpeedValue)
        {
            if (device.LeftStickX.Value < -leftStickXValue)
            {//Left
            
                manager.velocity -= transform.right * Time.deltaTime;
                transform.Rotate(0, -turnCircle, 0);
            }
            else if (device.LeftStickX.Value > leftStickXValue)
            {//Right
           
                manager.velocity += transform.right * Time.deltaTime;
                transform.Rotate(0, turnCircle, 0);
            }
        }
        if (device.LeftStickY.Value == 1)
        {
            manager.velocity += transform.forward * Time.deltaTime * moveSpeed;
        }
        if (device.LeftStickY.Value < -leftStickYValue)
        {//Backwards
            moveSpeed -= 1.0f;
        }
        else if (device.LeftStickY.Value > leftStickYValue)
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


        if(moveSpeed >= moveSpeedCap)
        {
            moveSpeed = moveSpeedCap;
        }

    }


}