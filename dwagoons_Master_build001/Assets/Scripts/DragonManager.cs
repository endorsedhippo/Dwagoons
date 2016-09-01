using UnityEngine;
using System.Collections;

public class DragonManager : MonoBehaviour {


    private DragonControllerFly flyController;
    private DragonControllerGround groundController;
	// Use this for initialization
	void Start ()
    {
        flyController = GetComponent<DragonControllerFly>();
        groundController = GetComponent<DragonControllerGround>();

        flyController.enabled = true;
        groundController.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(flyController.isGrounded == true)
        {
            flyController.enabled = false;
            groundController.enabled = true;
        }
	}
}
