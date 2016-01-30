using UnityEngine;
using System.Collections;

public class NerdController : MonoBehaviour {


	private Rigidbody rb;
	private Vector3 targetPosition; 

	public float horizontalLimit;
	public float verticalLimit;
	public bool clockwise;
	public float vMaxSpeed;
	public float hMaxSpeed;
	public bool isFlip;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}

	void Start()
	{
		Move ();
	}


	void Move()
	{
		float hMovement = 0;
		float hSpeed = 0;
		float vMovement = 0;
		float vSpeed = 0;
		int rotationAngle = (int)(transform.rotation.eulerAngles.y / 90);
		if (rotationAngle % 2 == 0) { //HorizontalMovement)
			hMovement = horizontalLimit;
			hSpeed = hMaxSpeed;
			if (rotationAngle > 1) { //LeftMovement
				hMovement *= -1;
				hSpeed *= -1;
			}
		} else {
			vMovement = verticalLimit;
			vSpeed = vMaxSpeed;
			if (rotationAngle < 2) { //DownMovement
				vMovement *= -1;
				vSpeed *= -1;
			}
		}
		targetPosition = new Vector3 (transform.position.x + hMovement, transform.position.y, transform.position.z + vMovement);
		rb.velocity = new Vector3 (hSpeed, 0.0f, vSpeed);
	}

	void FixedUpdate()
	{
		if (Vector3.Distance(transform.position, targetPosition) < 0.1) {
			rb.velocity = Vector3.zero;
			if (isFlip)
				Flip ();
			else
				Rotate ();
			Move ();
		}
	}

	void Rotate()
	{
		if (clockwise) {
			transform.Rotate (0.0f, 90.0f, 0.0f);
		}
		else
			transform.Rotate (0.0f, -90.0f, 0.0f);
	}

	void Flip()
	{
		transform.Rotate (0.0f, 180.0f, 0.0f);
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag ("Player"))
			See ();
		else {
			rb.velocity = Vector3.zero;
			if (isFlip)
				Flip ();
			else
				Rotate ();
			Move ();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
			See ();
	}

	void See()
	{
		Destroy (gameObject);
	}
}
