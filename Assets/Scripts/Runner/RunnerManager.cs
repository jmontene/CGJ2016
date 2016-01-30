using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

public class RunnerManager : UnitySingleton<RunnerManager> {

    public int lives;
    public int maxPoints;
    public bool procedural;
    public int objectMultiplier;
    public int objectAmount;
    public List<GameObject> obstaclePrefabs;
    public GameObject goalPrefab;
    public float crowdStepTime;

    private float step;
    private Transform player;
    private Transform crowd;
    private Obstacle stage;
    private int crashPenalty;
    private int points;
    private Text pointsText;
    private Image wasted;

    public override void Awake() {
        base.Awake();
        player = GameObject.Find("Player").transform;
        crowd = GameObject.Find("Crowd").transform;
        stage = GameObject.Find("Stage").GetComponent<Obstacle>();
        step = Vector3.Distance(player.position, crowd.position)/lives;
        crashPenalty = maxPoints / lives;
        points = maxPoints;
        pointsText = GameObject.Find("PointsText").GetComponent<Text>();
        wasted = GameObject.Find("Wasted").GetComponent<Image>();
        wasted.enabled = false;
        updatePoints();
        if (procedural) generateObstacles();
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GetHit() {
        MoveCrowdOneStep();
        lives -= 1;
        points -= crashPenalty;
        updatePoints();
        if(lives == 0) {
            Die();
        }
    }

    void updatePoints() {
        pointsText.text = "Points: " + points;
    }

    void MoveCrowdOneStep() {
        StartCoroutine(MoveCrowdSmooth());
    }

    IEnumerator MoveCrowdSmooth() {
        Vector3 start = crowd.position;
        Vector3 end = new Vector3(crowd.position.x - step, crowd.position.y, crowd.position.z);
        float t = 0.0f;
        float curTime = 0.0f;
        while(t < 1.0f) {
            crowd.position = Vector3.Lerp(start, end, t);
            curTime += Time.deltaTime;
            t = curTime / crowdStepTime;
            yield return null;
        }
        yield return null;
    }

    void Die() {
        EndStage();
        GameManager.Instance.Die("bombaInstrucciones");
    }

    public void Win() {
        EndStage();
        StartCoroutine(GameManager.Instance.EndStage("bombaInstrucciones"));
    }

    void EndStage() {
        stage.stop();
        GameManager.Instance.AddPoints(points);
    }

    void generateObstacles() {
        for(int i = 0; i < lives * objectAmount; ++i) {
            GameObject obj = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)],
                                         new Vector3(player.position.x - (objectMultiplier*(i+1)),0.5f,Random.Range(-4.0f,4.0f)),Quaternion.identity) as GameObject;
            obj.tag = "Obstacle";
            obj.transform.parent = stage.transform;
        }
        GameObject goal = Instantiate(goalPrefab, 
                          new Vector3(player.position.x - (objectMultiplier * ((lives * objectAmount) + 1)),0.5f,0f),Quaternion.identity) as GameObject;
        goal.tag = "Goal";
        goal.transform.parent = stage.transform;
    }
}
