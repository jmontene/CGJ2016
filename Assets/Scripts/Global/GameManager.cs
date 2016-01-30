using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : UnitySingleton<GameManager> {

    private int points;
    private Image wasted;

	// Use this for initialization
	public override void Awake() {
        base.Awake();
        points = 0;
        wasted = GetComponentInChildren<Canvas>().gameObject.GetComponentInChildren<Image>();
        wasted.enabled = false;
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

    public void Die(string nextScene) {
        wasted.enabled = true;
        StartCoroutine(EndStage(nextScene));
    }

    public IEnumerator EndStage(string nextScene) {
        yield return new WaitForSeconds(2.0f);
        wasted.enabled = false;
        SceneManager.LoadScene(nextScene);
    }
}
