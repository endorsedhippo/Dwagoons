using UnityEngine;
using System.Collections;

public class sandStormDelay : MonoBehaviour 
{
	public GameObject sandStorm;
	public GameObject sandStorm2;
	public GameObject sandStorm3;
	public GameObject player1;
	public GameObject player2;
	public int delay;
	public int duriation; 
	public int secondDelay;


	void Start()
	{
		StartCoroutine ("SandStorm");
	}


	IEnumerator SandStorm ()
	{
		yield return new WaitForSeconds (delay);
		sandStorm.SetActive (true);
		yield return new WaitForSeconds (secondDelay);
		sandStorm2.SetActive (true);
		yield return new WaitForSeconds (secondDelay);
		sandStorm3.SetActive (true);
		yield return new WaitForSeconds (duriation);
		sandStorm3.SetActive (false);
		yield return new WaitForSeconds (secondDelay);
		sandStorm2.SetActive (false);
		yield return new WaitForSeconds (secondDelay);
		sandStorm.SetActive (false);
		yield return new WaitForSeconds (secondDelay);
	}

}
