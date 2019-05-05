using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using System;

public class AIDamage : MonoBehaviour
{
    public float Health;
    public GameObject explosionEffect;
    public Patrol AIPatrolScript;
    public AIDestinationSetter AIDestinationSetterScript;
    public AILerp AILerpScript;
    public AIController Controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "StartingTrap")
        {
            if (Health == 1)
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                ScoreScript.Score += 10;
                Health = Health - 1;
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "FlameTrap")
        {
            if (Health <= 2)
            {
                ScoreScript.Score += 10;
                this.gameObject.SetActive(false);
            }
            else
            {
                Health = Health - 2;
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "FinalTrap")
        {
            if (Health <= 4)
            {
                ScoreScript.Score += 10;
                this.gameObject.SetActive(false);
            }
            else
            {
                Health = Health - 4;
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "SleepTrap")
        {
            Controller.enabled = false;
            AIDestinationSetterScript.enabled = false;
            AILerpScript.enabled = false;
            AIPatrolScript.enabled = false;
            Sleeping();
            Controller.enabled = true;
            AILerpScript.enabled = true;
            AIPatrolScript.enabled = true;
            Destroy(collision.gameObject);
        }
    }

    public IEnumerator Sleeping()
    {
        yield return new WaitForSeconds(5);
    }
}
    

