﻿using UnityEngine;
using System.Collections;

public class DestroyByHit : MonoBehaviour
{
    private float score=0;
    public int lives = 3;
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
                    Destroy(gameObject);
                    break;
                }
            case "Ball":
                {
                    Destroy(other.gameObject);
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