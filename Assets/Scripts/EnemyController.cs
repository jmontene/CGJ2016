using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    //Private variables
    private Rigidbody rb;
    private int _timer;         //Will be used inside the code to calculate time jumps
    private int horDir;
    private int verDir;

    //Public variables
    public float maxSpeed;
    public int timer;          //So that the user can set it outside the code
    

    // Use this for initialization
    void Awake() {
        rb = GetComponent<Rigidbody>();
        _timer = 0;     
        horDir = 0;
        verDir = 0;
    }
    
    void FixedUpdate() {
        
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

            else {
                verDir = 0;
                horDir = 0;
                _timer = timer;
            }

        }

        
        if (_timer != 0) {
            _timer--;
            rb.velocity = new Vector3(horDir*maxSpeed, 0.0f,verDir*maxSpeed );
        }

    }
}
