using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {

    public GameObject other;

    private DragonManager manager;
	// Use this for initialization
	void Start () {
        manager = GetComponent<DragonManager>();
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            Debug.Log("Hit");
            Vector3 Dir = other.transform.position - transform.position;
            Vector3 currVel = manager.velocity;
            Debug.Log(Dir);
            currVel = Vector3.Dot(currVel, Dir) * Dir;

            Vector3 force = 0.001f * (currVel - Vector3.Dot(currVel, Dir) * Dir);

            manager.rb.AddForce(force);
        }
    }
}
