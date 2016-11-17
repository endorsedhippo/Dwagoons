using UnityEngine;
using System.Collections;
using InControl;

public class DragonControllerIdleFly : MonoBehaviour {

    public int playerIndex;
    public float moveSpeed; //The starting speed of the script... this value is changed in the manager script and reset to THIS value when necessary. 
    public float strafeSpeed; //The strafe speed of the dragon.

    private InputDevice device;
    private DragonManager manager;

    //Public Values for Sam to Change
    //To keep accurate... keep these values within 5.0f of the move speed of their respected fly script.
    //These variables are in order from top to bottom in the script.
    public float leftStickXValue = 0.1f; //The value of the left stick X at which the dragon will 'strafe'.
    public float leftStickYValue = 0.1f; //The value of the left stick Y at which the dragon will move forwards and backwards... this will effect the move speed variable slightly.

    public float rightStickXValue = 0.1f; //The value of the right stick X at which the dragon will rotate on the spot.
    public float rotateOnSpot = 80.0f; //The speed at which the dragon will rotate on the spot.
    



    // Use this for initialization
    void Start ()
    {
        manager = GetComponent<DragonManager>();
        if (InputManager.Devices.Count <= playerIndex)
        {
            return;
        }
        device = InputManager.Devices[playerIndex];
        

        
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Movement
        if (device.LeftBumper.IsPressed)
        {//Left
            transform.position -= transform.right * Time.deltaTime * strafeSpeed;
        }
        else if (device.RightBumper > leftStickXValue)
        {//Right
            transform.position += transform.right * Time.deltaTime * strafeSpeed;
            //transform.Rotate(0, 60 * Time.deltaTime, 0, Space.World);
        }
        else if (device.LeftStickY.Value > leftStickYValue)
        {//Forwards

            manager.velocity += transform.forward * Time.deltaTime * moveSpeed;
            moveSpeed += 0.1f;
        }
        else if(device.LeftStickY.Value < -leftStickYValue)
        {
            transform.position -= transform.forward * Time.deltaTime * moveSpeed;
        }


        //Rotate
        if(device.LeftStickX.Value < -rightStickXValue)
        {
            transform.Rotate(0, -rotateOnSpot * Time.deltaTime, 0, Space.World);
        }
        else if(device.LeftStickX.Value > rightStickXValue)
        {
            transform.Rotate(0, rotateOnSpot * Time.deltaTime, 0, Space.World);
        }


        // air resistance
        manager.velocity *= 0.99f;

        transform.position = transform.position + manager.velocity * Time.deltaTime * moveSpeed;
    }
}
