using UnityEngine;
using System.Collections;

public class ProfMove : MonoBehaviour
{
    private Rigidbody rb;
    private float nextLook;
    private int lookTime;

    public float speed;
    public float lookRate;
    public float lookDelay;
    public GameObject exclamation;
    


    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        nextLook = Time.time + lookDelay;
        lookTime = 0;
        GameObject clone = Instantiate(exclamation, rb.position + new Vector3(0.0f, 1.0f, 0.0f), rb.rotation) as GameObject;
        clone.transform.parent = rb.transform;
        Destroy(clone, lookDelay);
    }

    void FixedUpdate() {

        if (Time.time <= nextLook - lookDelay/4) {
            return;
        }
        BattleManager.Instance.setProfAware(true);
        if (BattleManager.Instance.getBombing()) {
            GameManager.Instance.Die("End");
            Destroy(GameObject.FindGameObjectWithTag("Player"), 0.0f);
        }
        rb.velocity = transform.forward * speed;
        
    }


}
