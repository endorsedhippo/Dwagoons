using UnityEngine;
using System.Collections;
using InControl;

public class DragonManager : MonoBehaviour {
    public float heightControl;
    public int playerIndex;
    public bool isGrounded = false;
    public Animator animator;
    public Vector3 velocity;

    private DragonControllerFly flyController;
    private DragonControllerIdleFly idleFlyController;
    private DragonControllerGround groundController;
    private HealthScript health;
    private InputDevice device;
    private Rigidbody rb;

	public bool trigger;

    // Use this for initialization
    void Start ()
    {
        flyController = GetComponent<DragonControllerFly>();
        groundController = GetComponent<DragonControllerGround>();
        idleFlyController = GetComponent<DragonControllerIdleFly>();
        health = GetComponent<HealthScript>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        flyController.enabled = false;
        idleFlyController.enabled = true;
        groundController.enabled = false;

        //if (InputManager.Devices.Count <= playerIndex)
        //{
        //    return;
        //}
        device = InputManager.Devices[playerIndex];

    }
	
	// Update is called once per frame
	void Update ()
    {
        //idleFlyController.velocity0 = flyController.velocity;
        //flyController.velocity = idleFlyController.velocity0;
        if (groundController == null)
        {
            groundController = GetComponent<DragonControllerGround>();
        }
        
        if(playerIndex == 1)
        {
            return;
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

        if(idleFlyController.moveSpeed >= 7)
        {
            if (idleFlyController.enabled == true)
            {
                idleFlyController.enabled = false;
                animator.SetBool("SetFlying", true);
                flyController.enabled = true;
                flyController.moveSpeed = 8.0f;
            }
        }
        if(flyController.moveSpeed <= 7.9f)
        {
            if(flyController.enabled == true)
            {
                flyController.enabled = false;
                animator.SetBool("SetFlying", false);
                idleFlyController.enabled = true;
                idleFlyController.moveSpeed = 5;
            }
        }

        //How to Take Damage on a certain dragon
        if(playerIndex == 0)
        {
            health.TakeDamage(1);
        }
        else if(playerIndex == 1)
        {
            health.TakeDamage(3);
        }

        if (rb.drag >= 10)
        {
            rb.drag = 10;
        }
        else if (rb.drag <= 2)
        {
            rb.drag = 2;
        }

        if(velocity.x > 1.7f)
        {
            velocity.x = 1.7f;
        }
        else if(velocity.x < -1.7f)
        {
            velocity.x = -1.7f;
        }
        if (velocity.z > 1.7f)
        {
            velocity.z = 1.7f;
        }
        else if(velocity.z < -1.7f)
        {
            velocity.z = -1.7f;
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

        RaycastHit terrainVert;
        Debug.DrawRay(transform.position, -Vector3.up * 100, Color.red);
        Vector3 desiredUp = Vector3.up;
        if (Physics.Raycast(transform.position, -Vector3.up, out terrainVert, 7.0f))
        {
            Debug.DrawRay(terrainVert.point, terrainVert.normal * 100, Color.blue);
            //transform.rotation = Quaternion.Slerp(transform.rotation, terrainVert.normal, 0.1f);
            desiredUp = terrainVert.normal;

            Debug.DrawRay(terrainVert.point, terrainVert.normal * 100, Color.green);
        }

        Vector3 right = Vector3.Cross(transform.up, desiredUp);
        if (right.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.AngleAxis(2, right) * transform.rotation;
        }

        //Height Control
        Vector3 velocity0 = rb.velocity;
        if (device.LeftTrigger.IsPressed)
        {
            velocity0.y -= heightControl;
            rb.drag += 0.01f;
			trigger = true;
        }
        else if (device.RightTrigger.IsPressed)
        {
            velocity0.y += heightControl;
            rb.drag -= 0.03f;
        }
        rb.velocity = velocity0;
    }

    void FixedUpdate()
    {
        //change animation based on position of left stick
        if (device.LeftStickY > 0.99f || flyController.moveSpeed >= 15)
        {
            animator.SetBool("SetFlying", true);
            animator.SetBool("BankLeft", false);
            animator.SetBool("BankRight", false);
            if (device.LeftStickX < -0.1f && flyController.moveSpeed >= 15)
            {
                animator.SetBool("BankLeft", true);
                animator.SetBool("BankRight", false);
            }
            else if (device.LeftStickX > 0.1f && flyController.moveSpeed >= 15)
            {
                animator.SetBool("BankRight", true);
                animator.SetBool("BankLeft", false);
            }
            else return;
        }
        else
        {
            animator.SetBool("SetFlying", false);
            animator.SetBool("BankLeft", false);
            animator.SetBool("BankRight", false);
        }
    }

    //private void StaminaUpdate()
    //{
    //    float staminaTick = (1.0f * Time.deltaTime) / 2;

    //    stamina.UseStamina(staminaTick);
    //}
}
