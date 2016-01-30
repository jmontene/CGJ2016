using UnityEngine;
using System.Collections;

public class MakePasserby : MonoBehaviour {

    private Rigidbody rb;
    private float nextSpawn;
    private int nextProf;

    public float spawnRate;
    public float spawnDelay;
    public float studentSpawnRate;
    public GameObject student;
    public GameObject professor;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        nextSpawn = 0.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Random.value < spawnRate && Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnDelay;
            if (Random.value > studentSpawnRate) {
                GameObject clone = Instantiate(student, rb.position, rb.rotation) as GameObject;
                clone.transform.parent = rb.transform;
            }
            else {
                if (nextProf == 0)
                {
                    GameObject clone = Instantiate(professor, rb.position, rb.rotation) as GameObject;
                    clone.transform.parent = rb.transform;
                    nextProf = 600;
                }
                
            }
        }
        if (nextProf != 0) {
            nextProf--;
        }
    }
}
