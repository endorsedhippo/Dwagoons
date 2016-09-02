using UnityEngine;
using System.Collections;
using InControl;

public class DragonManager : MonoBehaviour {
    public float heightControl;
    public int playerIndex;
    private DragonControllerFly flyController;
    private DragonControllerGround groundController;
    private InputDevice device;
    private Rigidbody rb;
    // Use this for initialization
    void Start ()
    {
        flyController = GetComponent<DragonControllerFly>();
        groundController = GetComponent<DragonControllerGround>();
        rb = GetComponent<Rigidbody>();

        flyController.enabled = true;
        groundController.enabled = false;

        if (InputManager.Devices.Count <= playerIndex)
        {
            return;
        }
        device = InputManager.Devices[playerIndex];
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(groundController == null)
        {
            groundController = GetComponent<DragonControllerGround>();
        }
            
        if (flyController.isGrounded == true)
        {
            flyController.enabled = false;
            groundController.enabled = true;
        }
        else
        {
            flyController.enabled = true;
            groundController.enabled = false;
        }

        if (rb.drag >= 10)
        {
            rb.drag = 10;
        }
        else if (rb.drag <= 2)
        {
            rb.drag = 2;
        }
        flyController.isGrounded = false;

        RaycastHit[] Hits =
            Physics.SphereCastAll(transform.position, 0.1f + 0.1f, Vector2.down, 1.2f);

        foreach (RaycastHit hit in Hits)
        {
            if (hit.normal.y > 0.05f && hit.rigidbody != rb)
            {
                flyController.isGrounded = true;
            }
        }
        //Height Control
        Vector3 velocity0 = rb.velocity;
        if (device.LeftTrigger.IsPressed)
        {
            velocity0.y -= heightControl;
            rb.drag += 0.01f;
        }
        else if (device.RightTrigger.IsPressed)
        {
            velocity0.y += heightControl;
            rb.drag -= 0.03f;
        }
        rb.velocity = velocity0;
    }
}
