using UnityEngine;
using System.Collections;
using InControl;

public class NewCamera : MonoBehaviour {

    public Transform target;
    public Vector3[] positions;
    public int playerIndex;
    public float cameraRotateSpeed;
    public Vector3 targetPosition;

    private InputDevice device;
    private bool closeCamera;
    private bool cameraIncrease;
    private bool cameraDecrease;
    private bool lerp;

    // Use this for initialization
    void Start ()
    {
        if (InputManager.Devices.Count <= playerIndex)
        {
            return;
        }
        device = InputManager.Devices[playerIndex];

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
            targetPosition = positions[0];
            if (device.RightStickButton.WasPressed)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 7, transform.localPosition.z * 2);
                transform.rotation = transform.rotation;
                closeCamera = false;
            }
        }
        else
        {
            targetPosition = positions[1];
            if (device.RightStickButton.WasPressed)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 7, transform.localPosition.z / 2);
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

        if (device.RightStickY.Value > 0 && transform.eulerAngles.x < 40)
        {
            this.transform.RotateAround(target.transform.position, transform.right, cameraRotateSpeed * Time.deltaTime);
        }
        else if (device.RightStickY.Value < 0 && transform.eulerAngles.x < 40)
        {
            this.transform.RotateAround(target.transform.position, transform.right, -cameraRotateSpeed * Time.deltaTime);
        }

        //Camera Lerping Control
        if (device.RightStickX.WasReleased)
        {
            lerp = true;
        }
        else if(device.RightStickX.LastValue > 0 || device.RightStickX.LastValue < 0)
        {
            lerp = false;
        }

        if (lerp == true)
        {
            CameraLerp();
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
    
    //Lerping camera back to start position
    private void CameraLerp()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * 1.0f);
    }
}
