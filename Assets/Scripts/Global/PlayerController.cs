using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;

	public float speed;
	public bool canMoveHorizontal;
    public bool inBattle;
    public float fireRate = 1.0F;
    private float nextFire = 0.0F;

    public GameObject shot;

    
	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}

    void Update() {
        if (inBattle && Input.GetButtonDown("Fire1") && Time.time > nextFire){

            BattleManager.Instance.setBombing(true);

            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(shot, rb.position + new Vector3(-1.0f, 0.0f, 0.3f), rb.rotation) as GameObject;
            clone.transform.parent = rb.transform;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {

        if (inBattle) {
            float hMov = canMoveHorizontal ? Input.GetAxis("Horizontal") : 0.0f;
            float vMov = Input.GetAxis("Vertical");
            rb.velocity = new Vector3(vMov * speed, 0.0f, -hMov * speed);
        } else {
            float hMov = canMoveHorizontal ? Input.GetAxis("Horizontal") : 0.0f;
            float vMov = Input.GetAxis("Vertical");
            rb.velocity = new Vector3(hMov * speed, 0.0f, vMov * speed);
        }

        
        if (inBattle && Time.time > nextFire)
        {
            BattleManager.Instance.setBombing(false);
        }
    }
}
