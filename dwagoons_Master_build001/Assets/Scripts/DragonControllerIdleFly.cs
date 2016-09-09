using UnityEngine;
using System.Collections;
using InControl;

public class DragonControllerIdleFly : MonoBehaviour {

    public int playerIndex;
    public Vector3 velocity0;
    public float moveSpeed;

    private InputDevice device;
   
	// Use this for initialization
	void Start ()
    {
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
            //transform.position -= transform.right * Time.deltaTime * moveSpeed;
            transform.Rotate(0, -60 * Time.deltaTime, 0, Space.World);
        }
        else if (device.LeftStickX.Value > 0.1f)
        {//Right
            //transform.position += transform.right * Time.deltaTime * moveSpeed;
            transform.Rotate(0, 60 * Time.deltaTime, 0, Space.World);
        }
        else if (device.LeftStickY.Value > 0.1f)
        {//Forwards

            velocity0 += transform.forward * Time.deltaTime * moveSpeed;
            moveSpeed += 0.1f;
        }

        // air resistance
        velocity0 *= 0.99f;

        transform.position = transform.position + velocity0 * Time.deltaTime * moveSpeed;
    }
}
