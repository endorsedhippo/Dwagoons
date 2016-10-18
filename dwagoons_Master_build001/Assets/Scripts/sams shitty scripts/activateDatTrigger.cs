using UnityEngine;
using System.Collections;
using InControl;

public class activateDatTrigger  : MonoBehaviour 
{


	private Collider sphCol;
	private InputDevice device;
	public int playerIndex;
	private HealthScript health;
	private float timer;
	public float timeBetweenAttacks;
	public Animator animator;


	// Use this for initialization
	void Start () 
	{
		sphCol = GetComponent<SphereCollider>();
		device = InputManager.Devices [playerIndex];
		health = GameObject.FindGameObjectWithTag ("player2").GetComponent<HealthScript> ();
		sphCol.enabled = false;

	}


	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
		if (device.Action2.IsPressed) 
		{
			animator.SetBool ("IsAttacking", true);

			Timer ();

		}
		else 
		{
			animator.SetBool ("IsAttacking", false);
		}

	}

	void Timer()
	{
		
		{
			if (timer > timeBetweenAttacks)
			{
				sphCol.enabled = true;

				StartCoroutine (Combat ());
				timer = 0;
			}
		}
	}


	IEnumerator Combat()
	{
		yield return new WaitForSeconds (1);
		sphCol.enabled = false;


	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "player2") 
		{
			
			{
				health.currentHealth -= 10;

			}

		}
	}
		
}
