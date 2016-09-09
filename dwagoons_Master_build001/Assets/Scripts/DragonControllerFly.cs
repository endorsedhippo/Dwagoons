using UnityEngine;
using System.Collections;
using InControl;



[RequireComponent (typeof (Animator))]
public class DragonControllerFly : MonoBehaviour
{
    public float moveSpeed;
    public int playerIndex;


    Rigidbody rb;

    private InputDevice device;
    private DragonManager manager;
    //private StaminaScript stamina;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //stamina = GetComponent<StaminaScript>();
        manager = GetComponent<DragonManager>();

        if (InputManager.Devices.Count <= playerIndex)
        {
            return;
        }
        device = InputManager.Devices[playerIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
        //Movement
        if (device.LeftStickX.Value < -0.1f)
        {//Left
            
            manager.velocity -= transform.right * Time.deltaTime;
            transform.Rotate(0, -0.7f, 0);
        }
        else if (device.LeftStickX.Value > 0.1f)
        {//Right
           
            manager.velocity += transform.right * Time.deltaTime;
            transform.Rotate(0, 0.7f, 0);
        }
        if (device.LeftStickY.Value == 1)
        {
            manager.velocity += transform.forward * Time.deltaTime * moveSpeed;
        }
        if (device.LeftStickY.Value < -0.1f)
        {//Backwards
            moveSpeed -= 0.1f;
            //manager.velocity -= (transform.forward * Time.deltaTime) / 2;
            //rb.drag += 0.01f;
        }
        else if (device.LeftStickY.Value > 0.1f)
        {//Forwards
            
            manager.velocity += transform.forward * Time.deltaTime;
            rb.drag -= 0.03f;
        }

        // air resistance
        manager.velocity *= 0.99f;

        // keep on moving
        transform.position = transform.position + manager.velocity * Time.deltaTime * moveSpeed;
        transform.Rotate(0, 0, 0);


        //moveSpeed -= 0.1f;

    }
    //private void StaminaUpdate()
    //{
    //    float staminaTick = (1.0f * Time.deltaTime) / 2;

    //    stamina.UseStamina(staminaTick);
    //}

}