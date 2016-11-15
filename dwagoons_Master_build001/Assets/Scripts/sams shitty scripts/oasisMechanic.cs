using UnityEngine;
using System.Collections;

public class oasisMechanic : MonoBehaviour 
{
	public Transform oasis;
	public Vector3 oasisTargetOffset;
	public float raiseTime = 2;
	Vector3 oasisStart;
	Vector3 oasisTarget;
	private Vector3 oasisSecondTarget;
	public Transform position1;
	public GameObject Firstplayer;
	public GameObject Secondplayer;
	private float timer;
	private BoxCollider col;

	void Start()
	{
		oasisStart = oasis.position;
		oasisTarget = oasisStart + oasisTargetOffset;
		oasisSecondTarget = oasisStart;
		col = GetComponent<BoxCollider> ();
	}

	void Update()
	{
		timer += Time.deltaTime;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject == Firstplayer)
		{
			StartCoroutine(RaiseOasis(raiseTime));
		}
		if(other.gameObject == Secondplayer)
		{
			StartCoroutine(RaiseOasis(raiseTime));
		}
	}
	IEnumerator RaiseOasis(float time)
	{
		
		float elapsedTime = 0;
		while(elapsedTime < time)
		{
			oasis.position = Vector3.Lerp(oasisStart, oasisTarget, elapsedTime / time);
			elapsedTime += Time.deltaTime;
			yield return null;
			//timer = 0;
				oasis.position = oasisTarget;
			col.enabled = false;
		}

		
		
		StartCoroutine (OasisBack (raiseTime));
	}
		
	IEnumerator OasisBack(float time)
	{
		oasis.position = oasisTarget;
		yield return new WaitForSeconds (15);
		float elapsedTime = 0;
		while (elapsedTime < time) 
		{
			oasis.position = Vector3.Lerp (oasisTarget, oasisSecondTarget, elapsedTime / time);
			elapsedTime += Time.deltaTime;
			yield return null;
			timer = 0;
		}
		oasis.position = oasisStart;
		yield return new WaitForSeconds (3);
		col.enabled = true;
	}
		
}
