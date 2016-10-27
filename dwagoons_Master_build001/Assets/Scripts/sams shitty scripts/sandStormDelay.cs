using UnityEngine;
using System.Collections;

public class sandStormDelay : MonoBehaviour 
{
	public GameObject sandStorm;
	public GameObject player1;
	public GameObject player2;
	public int delay;
	public int duriation; 


	void Start()
	{
		StartCoroutine ("SandStorm");
	}


	IEnumerator SandStorm ()
	{
		yield return new WaitForSeconds (delay);
		sandStorm.SetActive (true);
		yield return new WaitForSeconds (duriation);
		sandStorm.SetActive (false);
	}

}
