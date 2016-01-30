using UnityEngine;
using System.Collections;

public class ExclamationManagement : MonoBehaviour {

    private Rigidbody rb;
    private int timer;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(rb, 0.0f);
	}
}
