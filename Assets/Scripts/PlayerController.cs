using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;

	public float speed;
	public bool canMoveHorizontal;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float hMov = canMoveHorizontal ? Input.GetAxis ("Horizontal") : 0.0f;
		float vMov = Input.GetAxis ("Vertical");

		rb.velocity = new Vector3 (hMov * speed, 0.0f, vMov * speed);
	}
}
