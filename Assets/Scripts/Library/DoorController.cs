using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	void OnCollisionEnter(Collision coll)
	{
		GameManager.Instance.AddPoints (LibraryManager.Instance.Score);
		StartCoroutine(GameManager.Instance.EndStage ("runnerInstrucciones"));
	}
}
