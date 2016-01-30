using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameEnd : MonoBehaviour {

    private Text scoreText; 

	// Use this for initialization
	void Awake() {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        scoreText.text = "Final Score: " + GameManager.Instance.GetPoints();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
