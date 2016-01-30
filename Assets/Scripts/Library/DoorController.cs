using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	void OnCollisionEnter(Collision coll)
	{
        Debug.Log("Collided");
		StartCoroutine(GameManager.Instance.EndStage ("Runner"));
	}
}
