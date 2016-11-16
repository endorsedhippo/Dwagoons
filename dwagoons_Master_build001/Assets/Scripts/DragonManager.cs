using UnityEngine;
using System.Collections;
using InControl;

public class DragonManager : MonoBehaviour
{
    public float heightControl;
    public int playerIndex;
    public bool isGrounded = false;
    public Animator animator;
    public Vector3 velocity;

    public Rigidbody fireBall;
    public Vector3 pointOfAttack;

    private DragonControllerFly flyController;
    private DragonControllerIdleFly idleFlyController;
    private DragonControllerGround groundController;
    private DragonStats stats;
    private InputDevice device;
    private Rigidbody rb;

    //Public Values for Sam to Change
    //To keep accurate... keep these values within 5.0f of the move speed of their respected fly script.
    //These variables are in order from top to bottom in the script.

    public float idleFlySpeedLimit = 7.0f; //the maximum speed the dragon gets to swap from idle Fly -> Fly
    public float flyStartSpeed = 8.0f; //The starting speed when dragon goes into Fly... This is reset everytime Dragon leaves the Fly script.
    public float flySpeedLimit = 7.9f; //The minimum speed the dragon gets to swap from Fly -> Idle Fly
    public float idleFlyStartSpeed = 5.0f; //the starting speed when Dragon goes into IdleFly... this is reset everytime Dragon leaves IdleFlyScript.

    public float XVelocityCap;
    public float XVelocitySet = 1.65f; //Good idea to keep this within 1.0f of the Cap.
    public float ZVelocityCap;
    public float ZVelocitySet = 1.65f; //Good idea to keep this within 1.0f of the Cap.

    public float groundedRayCastDistance = 1.2f; //The distance from the Dragons local transform of (0, 0, 0) to the ground which will turn Grounded on.

    public float leftStickYValue = 0.99f; //The value of the left stick Y at which the dragon changes to the flying animation regardless of speed.
    public float leftStickXValue = 0.1f; //The value of the left stick X at which the dragon will 'bank'.
   

    
    // Use this for initialization
    void Start()
    {
        flyController = GetComponent<DragonControllerFly>();
        groundController = GetComponent<DragonControllerGround>();
        idleFlyController = GetComponent<DragonControllerIdleFly>();
        stats = GetComponent<DragonStats>();
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
    void Update()
    {
        if (groundController == null)
        {
            groundController = GetComponent<DragonControllerGround>();
        }

       /* if (playerIndex == 1)
        {
            return;
        }*/
        if (isGrounded == true)
        {
            animator.SetBool("IsGrounded", true);
            idleFlyController.enabled = false;
            groundController.enabled = true;

            rb.useGravity = true;
        }
        else
        {
            animator.SetBool("IsGrounded", false);
            //StaminaUpdate();
            groundController.enabled = false;
            
            rb.useGravity = false;
        }

        if (idleFlyController.moveSpeed >= idleFlySpeedLimit)
        {
            if (idleFlyController.enabled == true)
            {
                idleFlyController.enabled = false;
                animator.SetBool("SetFlying", true);
                flyController.enabled = true;
                flyController.moveSpeed = flyStartSpeed;
            }
        }
        if (flyController.moveSpeed <= flySpeedLimit)
        {
            if (flyController.enabled == true)
            {
                flyController.enabled = false;
                animator.SetBool("SetFlying", false);
                idleFlyController.enabled = true;
                idleFlyController.moveSpeed = idleFlyStartSpeed;
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

        //Lock the velocity in the X and Z Vector to cap speed
        if (velocity.x > XVelocityCap)
        {
            velocity.x = XVelocitySet;
        }
        else if (velocity.x < -XVelocityCap)
        {
            velocity.x = -XVelocitySet;
        }
        if (velocity.z > ZVelocityCap)
        {
            velocity.z = ZVelocitySet;
        }
        else if (velocity.z < -ZVelocityCap)
        {
            velocity.z = -ZVelocitySet;
        }
        

    }

    void FixedUpdate()
    {
        RaycastHit[] Hits =
           Physics.SphereCastAll(transform.position, 0.3f + 0.3f, Vector2.down, groundedRayCastDistance);

        foreach (RaycastHit hit in Hits)
        {
            if (device.RightTrigger.IsPressed)
            {
                isGrounded = false;
            }
            if (hit.normal.y < 1.0f && hit.rigidbody != rb)
            {

                isGrounded = true;
            }
            else if(hit.normal.y > 1.0f)
            {
                isGrounded = false;
            }
        }
        

        //Height 
        Vector3 velocity0 = rb.velocity;

        if (device.LeftTrigger.IsPressed && isGrounded == false)
        {
            velocity0.y -= heightControl;
            //rb.drag += 0.01f;

        }
        else if (device.RightTrigger.IsPressed && isGrounded == false)
        {
            velocity0.y += heightControl;
            //rb.drag -= 0.03f;
            isGrounded = false;
        }
        rb.velocity = velocity0;


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
        if (right.magnitude > 0.008f)
        {
            float maxAngle = Mathf.Asin(right.magnitude) * 180f / 3.14f;
            transform.rotation = Quaternion.AngleAxis(Mathf.Min(2, maxAngle), right) * transform.rotation;
        }

        //change animation based on position of left stick when flying
        if(isGrounded == false)
        {
            if (device.LeftStickY > leftStickYValue || flyController.moveSpeed >= 15)
            {
                animator.SetBool("SetFlying", true);
                animator.SetBool("BankLeft", false);
                animator.SetBool("BankRight", false);
                if (device.LeftStickX < -leftStickXValue && flyController.moveSpeed >= 15)
                {
                    animator.SetBool("BankLeft", true);
                    animator.SetBool("BankRight", false);
                }
                else if (device.LeftStickX > leftStickXValue && flyController.moveSpeed >= 15)
                {
                    animator.SetBool("BankRight", true);
                    animator.SetBool("BankLeft", false);
                }
                else return;
            }
            else
            {
               // animator.SetBool("IsGrounded", true);
                animator.SetBool("SetFlying", false);
                animator.SetBool("BankLeft", false);
                animator.SetBool("BankRight", false);

                
            }
        }
        //change animation based on position of left stick when grounded
        else
        {
            if (device.LeftStickY.Value > leftStickYValue || device.LeftStickX.Value > leftStickXValue || device.LeftStickX.Value < -leftStickXValue)
            {
                animator.SetBool("IsWalking", true);

            }
            else
            {
                animator.SetBool("IsWalking", false);
            }
        }

    }

    //private void StaminaUpdate()
    //{
    //    float staminaTick = (1.0f * Time.deltaTime) / 2;

    //    stamina.UseStamina(staminaTick);
    //}
}
