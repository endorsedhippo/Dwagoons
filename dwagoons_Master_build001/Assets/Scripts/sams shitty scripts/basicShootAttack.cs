using UnityEngine;
using System.Collections;
using InControl;

public class basicShootAttack : MonoBehaviour 
{

	public Rigidbody fireBall;
	public GameObject firePoint;
	public float speed;
	private InputDevice device;
	public int playerIndex;
	private float timer;


	// Use this for initialization
	void Start () 
	{
		
		device = InputManager.Devices [playerIndex];
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		if (device.Action4.IsPressed) 
		{
			if (timer > 2) {

				shoot ();
				timer = 0;
			}
		}
	}

	void shoot()
	{
		Rigidbody clone;
		clone = Instantiate (fireBall, firePoint.transform.position, firePoint.transform.rotation) as Rigidbody;
		clone.velocity = transform.forward * speed;
	}
}
