using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public Transform target;
    public Camera[] cameras;

    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
    }

    void LateUpdate()
    {
        transform.LookAt(target);
    }
}
