using UnityEngine;
using System.Collections;
using InControl;

public class DragonControllerGround : MonoBehaviour {
    public float moveSpeed;
    public int playerIndex;

    public InputDevice device;
	// Use this for initialization
	void Start () {
        if (InputManager.Devices.Count <= playerIndex)
        {
            return;
        }
        device = InputManager.Devices[playerIndex];
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
