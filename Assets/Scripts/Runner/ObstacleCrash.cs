using UnityEngine;
using System.Collections;

public class ObstacleCrash : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Obstacle") {
            RunnerManager.Instance.GetHit();
            Destroy(other.gameObject);
        }else if(other.tag == "Goal") {
            RunnerManager.Instance.Win();
        }
    }
}
