using UnityEngine;
using System.Collections;

public class DestroyByHit : MonoBehaviour
{
    private float score=0;
    public int lives = 3;
    public GameObject particles;

    void OnTriggerEnter(Collider other)
    {
 
        switch (other.tag)
        {
            case "boundary":{
                    return;
                }
            case "Enemy":{
                    Destroy(gameObject);
                    break;
                }
            case "Player":
                {
                    Destroy(other.gameObject);
                    break;
                }
            case "Ball":
                {
                    Destroy(other.gameObject);
    
                    Destroy(clone, 1.0f);
                    lives--;
                    if (lives == 0 && gameObject.tag == "Enemy")
                    {
                        Destroy(gameObject);
                        score += 250;
                    }

                    break;
                }
        }
    }
}