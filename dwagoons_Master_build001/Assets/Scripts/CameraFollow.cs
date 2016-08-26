using UnityEngine;
using System.Collections;
using InControl;

public class CameraFollow : MonoBehaviour {

    public Transform basePoint;
    public int playerIndex;
    public float cameraSpeed;
    public float boundaries;

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
	void Update () {

       

    }
    void FixedUpdate()
    {
        Vector3 pos = transform.localPosition;
        //Rotation
        if (device.RightStickX.Value > 0.1f)
        {
            pos += Vector3.right * Time.deltaTime * cameraSpeed;
        }
        else if (device.RightStickX.Value < -0.1f)
        {
            pos -= Vector3.right * Time.deltaTime * cameraSpeed;;
        }
        if (device.RightStickY.Value > 0)
        {
            pos += Vector3.forward * Time.deltaTime * cameraSpeed;
        }
        else if (device.RightStickY.Value < 0)
        {
            pos -= Vector3.forward * Time.deltaTime * cameraSpeed;
        }

        //Boundaries
        if (pos.x >= boundaries)
        {
            pos.x = boundaries;
        }
        else if (pos.x <= -boundaries)
        {
            pos.x = - boundaries;
        }
        if (pos.z >= boundaries * 2)
        {
            pos.z = boundaries * 2;
        }
        else if (pos.z <=  0)
        {
            pos.z = 0;
        }
        transform.localPosition = pos;
    }
}

