using UnityEngine;
using System.Collections;
using InControl;

public class takeDamage : MonoBehaviour {



    public GameObject enemy;
    private InputDevice device;
	private HealthScript health; 
	private float timer;

	// Use this for initialization
	void Start () {
		
		health = GetComponent <HealthScript> ();
	}

    void OnTriggerStay (Collider other)
    {
       if (other.gameObject.tag == "player1")
        {
			if (timer > 2.0f)
			{
				health.currentHealth -= 10;
				Debug.Log ("do damage");

				timer = 0;
			}
        }
    }
	void Update ()
    {
		timer += Time.deltaTime;
	
	}
}
