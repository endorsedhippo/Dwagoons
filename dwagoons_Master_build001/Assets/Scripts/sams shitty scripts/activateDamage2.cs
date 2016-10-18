using UnityEngine;
using System.Collections;
using InControl;

public class activateDamage2: MonoBehaviour 
{


	public Collider capCol;
	private InputDevice device;
	public int playerIndex;
	private HealthScript health;
	private float timer;
	public float timeBetweenAttacks;
	public Animator animator;


	// Use this for initialization
	void Start () 
	{
		capCol = GetComponent<CapsuleCollider>();
		device = InputManager.Devices [playerIndex];
		health = GameObject.FindGameObjectWithTag ("player2").GetComponent<HealthScript> ();
		capCol.enabled = false;

	}


	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
		if (device.Action3.IsPressed) 
		{
			//animator.SetBool ("IsAttacking", true);

			Timer ();

		}
		else 
		{
			//animator.SetBool ("IsAttacking", false);
		}

	}

	void Timer()
	{

		{
			if (timer > timeBetweenAttacks)
			{
				capCol.enabled = true;

				StartCoroutine (Combat ());
				timer = 0;
			}
		}
	}


	IEnumerator Combat()
	{
		yield return new WaitForSeconds (1);
		capCol.enabled = false;


	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "player2") 
		{

			{
				health.currentHealth -= 20;

			}

		}
	}

}
