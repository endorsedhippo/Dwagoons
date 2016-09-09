using UnityEngine;
using System.Collections;
using InControl;

public class DragonManager : MonoBehaviour {
    public float heightControl;
    public int playerIndex;
    public bool isGrounded = false;
    public Animator animator;

    private DragonControllerFly flyController;
    private DragonControllerIdleFly idleFlyController;
    private DragonControllerGround groundController;
    private InputDevice device;
    private Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        flyController = GetComponent<DragonControllerFly>();
        groundController = GetComponent<DragonControllerGround>();
        idleFlyController = GetComponent<DragonControllerIdleFly>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        flyController.enabled = false;
        idleFlyController.enabled = true;
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
        idleFlyController.velocity0 = flyController.velocity;
        //flyController.velocity = idleFlyController.velocity0;
        scriptDelay -= 0.05f;
        if (groundController == null)
        {
            groundController = GetComponent<DragonControllerGround>();
        }
    
        if (isGrounded == true)
        {
            animator.SetBool("IsGrounded", true);
            idleFlyController.enabled = false;
            groundController.enabled = true;
        }
        else
        {
            animator.SetBool("IsGrounded", false);
            //StaminaUpdate();
            groundController.enabled = false;    
        }

        if(idleFlyController.moveSpeed >= 20)
        {
            if (idleFlyController.enabled == true)
            {
                idleFlyController.enabled = false;
                animator.SetBool("SetFlying", true);
                flyController.enabled = true;
                flyController.moveSpeed = 30.0f;
                
            }
        }
        if(flyController.moveSpeed <= 20)
        {
            if(flyController.enabled == true)
            {
                flyController.enabled = false;
                animator.SetBool("SetFlying", false);
                idleFlyController.enabled = true;
                idleFlyController.moveSpeed = 5;
            }
        }
       


        if (rb.drag >= 10)
        {
            rb.drag = 10;
        }
        else if (rb.drag <= 2)
        {
            rb.drag = 2;
        }

        if(scriptDelay <= 0)
        {
            scriptDelay = 0;
        }

        RaycastHit[] Hits =
            Physics.SphereCastAll(transform.position, 0.1f + 0.1f, Vector2.down, 1.2f);

        foreach (RaycastHit hit in Hits)
        {
            if (hit.normal.y > 0.05f && hit.rigidbody != rb)
            {
                isGrounded = true;
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
