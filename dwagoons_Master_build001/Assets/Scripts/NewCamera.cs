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

    //Public Values for Sam to Change
    //To keep accurate... keep these values within 5.0f of the move speed of their respected fly script.
    //These variables are in order from top to bottom in the script.

    public float positionYChange = 7; //A factor of 2 is the best way to go.. either half or double the Target Position Y value.
    public float positionZChange = 2; //A factor of 2 is the best way to go.. either half or double the Target Position Z value.

    public int eulerAnglesSet = 40; //This sets the limit the camera can rotate above or below the dragons position... 
                                    //shouldnt have to compensate for negative rotation as its this values degrees from the original rotation


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
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + positionYChange, transform.localPosition.z * positionZChange);
                transform.rotation = transform.rotation;
                closeCamera = false;
            }
        }
        else
        {
            targetPosition = positions[1];
            if (device.RightStickButton.WasPressed)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - positionYChange, transform.localPosition.z / positionZChange);
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

        if (device.RightStickY.Value > 0 && transform.eulerAngles.x < eulerAnglesSet)
        {
            this.transform.RotateAround(target.transform.position, transform.right, cameraRotateSpeed * Time.deltaTime);
        }
        else if (device.RightStickY.Value < 0 && transform.eulerAngles.x < eulerAnglesSet)
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
