using UnityEngine;
using System.Collections;
using InControl;



[RequireComponent (typeof (Animator))]
public class DragonControllerFly : MonoBehaviour
{
    public float moveSpeed;
    public bool isGrounded = false;
    public int playerIndex;

    Vector3 velocity;

    Rigidbody rb;
    RaycastHit hit;

    public Animator animator;
    private InputDevice device;
    //private StaminaScript stamina;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //stamina = GetComponent<StaminaScript>();

        animator = GetComponent<Animator>();

        if (InputManager.Devices.Count <= playerIndex)
        {
            return;
        }
        device = InputManager.Devices[playerIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
        //Check for grounded for animation purposes
        if (isGrounded == true)
        {
            animator.SetBool("IsGrounded", true);
            ///animator.setBool("isWalking", isGrounded);
        }
        else
        {
            animator.SetBool("IsGrounded", false);
            //StaminaUpdate();
        }
        //Movement
        if (device.LeftStickX.Value < -0.1f)
        {//Left
            //transform.position -= transform.right * Time.deltaTime * moveSpeed;
            velocity -= transform.right * Time.deltaTime;
            transform.Rotate(0, -0.7f, 0);
        }
        else if (device.LeftStickX.Value > 0.1f)
        {//Right
            //transform.position += transform.right * Time.deltaTime * moveSpeed;
            velocity += transform.right * Time.deltaTime;
            transform.Rotate(0, 0.7f, 0);
        }
        if (device.LeftStickY.Value == 1)
        {
            velocity += transform.forward * Time.deltaTime * moveSpeed;
        }
        if (device.LeftStickY.Value < -0.1f)
        {//Backwards
            //transform.position -= (transform.forward * Time.deltaTime * moveSpeed) / 2;
            velocity -= (transform.forward * Time.deltaTime) / 2;
            rb.drag += 0.01f;
        }
        else if (device.LeftStickY.Value > 0.1f)
        {//Forwards
            //transform.position += transform.forward * Time.deltaTime * moveSpeed;
            velocity += transform.forward * Time.deltaTime;
            rb.drag -= 0.03f;
        }

        // air resistance
        velocity *= 0.99f;

        // keep on moving
        transform.position = transform.position + velocity * Time.deltaTime * moveSpeed;
        transform.Rotate(0, 0, 0);

    }
    /// <summary>
    /// Analog Stick controls movement entirely
    /// </summary>
    void FixedUpdate()
    {
        //change animation based on position of left stick
        if(device.LeftStickY > 0.05f)
        {
            animator.SetBool("SetFlying", true);
            animator.SetBool("BankLeft", false);
            animator.SetBool("BankRight", false);
            if (device.LeftStickX < -0.1f)
            {
                animator.SetBool("BankLeft", true);
                animator.SetBool("BankRight", false);
            }
            else if (device.LeftStickX > 0.1f)
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