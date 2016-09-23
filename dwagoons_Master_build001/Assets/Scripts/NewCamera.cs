using UnityEngine;
using System.Collections;
using InControl;

public class NewCamera : MonoBehaviour {

    public Transform target;
    public Camera[] cameras;
    public int playerIndex;
    public float cameraRotateSpeed;

    private InputDevice device;
    
    // Use this for initialization
    void Start ()
    {
        if (InputManager.Devices.Count <= playerIndex)
        {
            return;
        }
        device = InputManager.Devices[playerIndex];
        cameras[0].enabled = true;
        cameras[1].enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(target);
        //transform.position = Vector3.Lerp(transform.position, startPos.position, Time.deltaTime * 5.0f);

        if (cameras[0].enabled == true)
        {
            if (device.RightStickX.Value > 0)
            {
                cameras[0].transform.RotateAround(target.transform.position, Vector3.up, cameraRotateSpeed * Time.deltaTime);
            }
            else if (device.RightStickX.Value < 0)
            {
                cameras[0].transform.RotateAround(target.transform.position, Vector3.up, -cameraRotateSpeed * Time.deltaTime);
            }
            
            if (device.RightStickButton.WasPressed)
            {
                SelectCamera(1);
            }
            else
                return;
        }
        else if(cameras[1].enabled == true)
        {
            if (device.RightStickX.Value > 0)
            {
                cameras[1].transform.RotateAround(target.transform.position, Vector3.up, cameraRotateSpeed * Time.deltaTime);
            }
            else if (device.RightStickX.Value < 0)
            {
                cameras[1].transform.RotateAround(target.transform.position, Vector3.up, -cameraRotateSpeed * Time.deltaTime);
            }
            if (device.RightStickButton.WasPressed)
            {
                SelectCamera(0);
            }
            else
                return;
        }



    }

    private void SelectCamera(int index)
    {
        for(int i = 0; i < cameras.Length; i++)
        {
            if(i == index)
            {
                cameras[i].enabled = true;
            }
            else
            {
                cameras[i].enabled = false;
            }
        }
    }
}
