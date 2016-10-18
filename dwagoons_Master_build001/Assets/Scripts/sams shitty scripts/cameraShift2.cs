using UnityEngine;
using System.Collections;
using InControl;
public class cameraShift2 : MonoBehaviour 
{

	public Camera[] cameras;
	private int currentCameraIndex;
	private InputDevice device;
	public int playerIndex;
	private float timer;


	// Use this for initialization
	void Start () 
	{
		currentCameraIndex = 0;
		device = InputManager.Devices [playerIndex];

		for (int i = 1; i < cameras.Length; i++) 
		{
			cameras [i].gameObject.SetActive (false);
		}

		if (cameras.Length > 0) 
		{
			cameras [0].gameObject.SetActive (true);
			Debug.Log ("Camera" + cameras [0].GetComponent<Camera>().name + "is active");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;

		if (device.Action1.IsPressed) 
		{
			if (timer > 0.25f) 
			{
				currentCameraIndex++;

				if (currentCameraIndex < cameras.Length) 
				{
					cameras [currentCameraIndex - 1].gameObject.SetActive (false);
					cameras [currentCameraIndex].gameObject.SetActive (true);
				} 

				else 
				{
					cameras [currentCameraIndex - 1].gameObject.SetActive (false);
					currentCameraIndex = 0;
					cameras [currentCameraIndex].gameObject.SetActive (true);
				}

				timer = 0;
			}
		}
	}
}
