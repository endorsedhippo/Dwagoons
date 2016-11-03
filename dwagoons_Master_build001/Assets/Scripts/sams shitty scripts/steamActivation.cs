using UnityEngine;
using System.Collections;

public class steamActivation : MonoBehaviour 
{
	public GameObject Player1;
	public GameObject Player2;

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == Player1) 
		{
			Debug.Log ("You hit some steam yo");
		}
		if (other.gameObject == Player2) 
		{
			Debug.Log ("You hit some steam yo");
		}
	}



}
