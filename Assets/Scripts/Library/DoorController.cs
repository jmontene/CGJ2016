using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	void OnCollissionEnter(Collision coll)
	{
		GameManager.Instance.EndStage ("Runner");
	}
}
