using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    private Rigidbody rb;

    public float speed;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.velocity = new Vector3(speed, 0.0f, 0.0f);
	}

    public void stop() {
        speed = 0;
    }
}
