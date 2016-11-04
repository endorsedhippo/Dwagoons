using UnityEngine;
using System.Collections;
using InControl;

public class DragonControllerGround : MonoBehaviour {
    public float moveSpeed;
    public int playerIndex;
    public float rotateSpeed;

    public InputDevice device;


    private DragonManager manager;
    private DragonControllerIdleFly idleFly;
	// Use this for initialization
	void Start () {

        manager = GetComponent<DragonManager>();
        idleFly = GetComponent<DragonControllerIdleFly>();

        if (InputManager.Devices.Count <= playerIndex)
        {
            return;
        }
        device = InputManager.Devices[playerIndex];
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        
	    if(device.LeftStickY.Value > 0.1f)
        {
           transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }

        if(device.LeftStickX.Value > 0.1f)
        {
            transform.position += transform.right * Time.deltaTime * (moveSpeed / 2);
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.World);
        }

        else if(device.LeftStickX.Value < -0.1f)
        {
            transform.position -= transform.right * Time.deltaTime * (moveSpeed / 2);
            transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0, Space.World);
        }


        if(device.RightTrigger.IsPressed)
        {
            transform.localPosition += new Vector3(0, manager.heightControl * Time.deltaTime, 0);
            manager.isGrounded = false;
            idleFly.enabled = true;
            this.enabled = false;
        }
	}


}
