using UnityEngine;
using System.Collections;

public class DestroyByHit : MonoBehaviour
{
    private float score=0;
    void OnTriggerEnter(Collider other)
    {
 
        switch (other.tag)
        {
            case "boundary":{
                    return;
                }
            case "Enemy":{
                    Destroy(other.gameObject);
                    Destroy(gameObject);
                    score += 250;
                    break;
                }
            case "Player":
                {
                    Destroy(other.gameObject);
                    Destroy(gameObject);
                    break;
                }
            case "Ball":
                {
                    Destroy(other.gameObject);
                    Destroy(gameObject);
                    break;
                }
        }
    }
}