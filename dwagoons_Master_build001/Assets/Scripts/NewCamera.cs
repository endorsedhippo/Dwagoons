using UnityEngine;
using System.Collections;
using InControl;

public class NewCamera : MonoBehaviour {

    public Transform target;
    public Vector3[] positions;
    public int playerIndex;
    public float cameraRotateSpeed;

    private InputDevice device;
    private bool closeCamera;
    public bool cameraIncrease;
    public bool cameraDecrease;
    
    // Use this for initialization
    void Start ()
    {
        if (InputManager.Devices.Count <= playerIndex)
        {
            return;
        }
        device = InputManager.Devices[playerIndex];


        //Camera Management Initialising
        //transform.position = positions[0];

        closeCamera = true;
        cameraIncrease = true;
        cameraDecrease = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(target);

        CameraSwitch();

        if(closeCamera == true)
        {
            if (device.RightStickButton.WasPressed)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 7, transform.position.z * 2);
                transform.rotation = transform.rotation;
                closeCamera = false;
            }
        }
        else
        {
            if (device.RightStickButton.WasPressed)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 7, transform.position.z / 2);
                transform.rotation = transform.rotation;
                closeCamera = true;
            }
        }
       
        
        if (device.RightStickX.Value > 0)
        {
            this.transform.RotateAround(target.transform.position, Vector3.up, cameraRotateSpeed * Time.deltaTime);
        }
     else if(device.RightStickX.Value < 0)
        {
            this.transform.RotateAround(target.transform.position, Vector3.up, -cameraRotateSpeed * Time.deltaTime);
        }
    }

    //basic Camera management
    private void CameraSwitch()
    {
        if(closeCamera == true)
        {
            cameraIncrease = true;
            cameraDecrease = false;
        }
        else
        {
            cameraDecrease = true;
            cameraIncrease = false;
        }
    }
}
