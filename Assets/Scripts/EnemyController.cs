using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    //Private variables
    private Rigidbody rb;
    private int _timer;         //Will be used inside the code to calculate time jumps
    private int horDir;         //-1, 0 OR 1, depending on direction to move
    private int verDir;         //See above
    private float nextFire;     //Remaining time to the next fire
    private Vector3 startPos;   //Used to create a bounding box so that the character moves on a restricted area

    //Public variables
    public float maxSpeed;
    public int timer;           //So that the user can set it outside the code
    public float fireRate;      //Minimum time used between bullets
    public float shootRate;     //Rate at which it fires
    public GameObject shot;


    // Use this for initialization
    void Awake() {
        rb = GetComponent<Rigidbody>();
        _timer = 0;     
        horDir = 0;
        verDir = 0;
        nextFire = Time.time + 1.5f;
    }
    
    void FixedUpdate() {


        //Random movement code
        if (_timer == 0 ) { //Decides if he should move

            if (Random.value < 0.2) {
                _timer = timer; //Sets a timer to move in the selected direction for that duration

                float rand = Random.value;

                if (rand < 0.5) { //Decides to move horizontally
                    horDir = 0;
                }
                else if (rand >= 0.33 && rand <= 0.66) {
                    horDir = 1;
                }
                else if (rand > 0.66) {
                    horDir = -1;
                }

                rand = Random.value;

                if (rand < 0.33) { //Decides to move vertically 
                    verDir = 0;
                }
                else if (rand >= 0.33 && rand <= 0.66) {
                    verDir = 1;
                }
                else if (rand > 0.66) {
                    verDir = -1;
                }
            }

            else {  //Doesn't move at all
                verDir = 0;
                horDir = 0;
                _timer = timer;
            }

        }

        //Makes move attempts
        if (_timer != 0) {
            _timer--;
            rb.velocity = new Vector3(horDir*maxSpeed, 0.0f,verDir*maxSpeed );
        }


        //Random shooting code
        if (Random.value < shootRate && Time.time > nextFire && !GameManager.Instance.profAware()) 
        {
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(shot, rb.position + new Vector3(1.0f, 0.0f, 0.3f), rb.rotation) as GameObject;
            clone.transform.parent = rb.transform;
        }

    }



}
