using UnityEngine;
using System.Collections;

public class steamActivation : MonoBehaviour 
{

	//public int playerIndex;
	public float damage;

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player") 
		{
			//if (other.GetComponent<DragonManager> ().playerIndex != playerIndex) 
			{
				other.GetComponent<DragonStats> ().currentHealth -= damage;
			}
		}
	}



}
