using UnityEngine;
using System.Collections;

public class GameManager : UnitySingleton<GameManager> {

    private int points;

	// Use this for initialization
	public override void Awake() {
        base.Awake();
        points = 0;
        DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddPoints(int p) {
        points += p;
    }

    public int GetPoints() {
        return points;
    }
}
