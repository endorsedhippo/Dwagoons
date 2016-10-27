using UnityEngine;
using System.Collections;
using InControl;

public class DragonControllerIdleFly : MonoBehaviour {

    public int playerIndex;
    public float moveSpeed;
    public float strafeSpeed;

    private InputDevice device;
    private DragonManager manager;

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
        if (device.LeftStickX.Value < -0.1f)
        {//Left
            transform.position -= transform.right * Time.deltaTime * strafeSpeed;
        }
        else if (device.LeftStickX.Value > 0.1f)
        {//Right
            transform.position += transform.right * Time.deltaTime * strafeSpeed;
            //transform.Rotate(0, 60 * Time.deltaTime, 0, Space.World);
        }
        else if (device.LeftStickY.Value > 0.1f)
        {//Forwards

            manager.velocity += transform.forward * Time.deltaTime * moveSpeed;
            moveSpeed += 0.1f;
        }
        else if(device.LeftStickY.Value < -0.1f)
        {
            transform.position -= transform.forward * Time.deltaTime * moveSpeed;
        }


        //Rotate
        if(device.RightStickX.Value < -0.1f)
        {
            transform.Rotate(0, -80 * Time.deltaTime, 0, Space.World);
        }
        else if(device.RightStickX.Value > 0.1f)
        {
            transform.Rotate(0, 80 * Time.deltaTime, 0, Space.World);
        }


        // air resistance
        manager.velocity *= 0.99f;

        transform.position = transform.position + manager.velocity * Time.deltaTime * moveSpeed;
    }
}
