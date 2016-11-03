using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

    public int playerIndex;
    public float speed = 100;
    public float timeUntilDestroy = 3;
    public float damage = 20;

    float lifeTimer = 0;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        lifeTimer += Time.deltaTime;

        if (lifeTimer >= timeUntilDestroy)
            Destroy(gameObject);
	}

    void OnTriggerEnter(Collider other)
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (collision.transform.GetComponent<DragonManager>().playerIndex != playerIndex)
            {
                collision.transform.GetComponent<DragonStats>().currentHealth -= damage;
                Destroy(gameObject);
            }
        }
    }
}
