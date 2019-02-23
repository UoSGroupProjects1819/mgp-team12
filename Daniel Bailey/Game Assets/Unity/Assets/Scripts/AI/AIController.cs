using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class AIController : MonoBehaviour
{
    public Patrol AIPatrolScript;
    public AIDestinationSetter AIDestinationSetterScript;

    public float Timer;
    public bool SightCheck;
    public bool InRange;

//#-----------------------Chasing or patrolling---------------------#
    private void Start()
    {
        //AIDestinationSetterScript = this.GetComponent<AIDestinationSetter>();
        //AIPatrolScript = this.GetComponent<Patrol>();
        AIDestinationSetterScript.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            StopAllCoroutines();
            Debug.Log("Player found");
            //Enable Destination setter
            AIDestinationSetterScript.enabled = true;
            //Disable Patrol script
            AIPatrolScript.enabled = false;
            InRange = true;
            SightCheck = false;
            Timer = 13;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player has left line of sight");
            InRange = false;
            SightCheck = true;
        }
    }

    private void Update()
    {
        if (SightCheck == true)
        {
            Debug.Log("Timer Started");
            SightCheck = false;
            StartCoroutine(SightCheckTimer());
        }

        if (Timer == 0)
        {
            //Enable Destination setter
            AIDestinationSetterScript.enabled = false;
            //Disable Patrol script
            AIPatrolScript.enabled = true;
        }
    }

    private IEnumerator SightCheckTimer()
    {
        if (Timer >= 1)
        {
            yield return new WaitForSeconds(1);
            Timer = Timer - 1;
            SightCheck = true;
        }

    }



    //#------------------Firing at player----------------------#


    //CoolDown
        //Wait for seconds
        //Cooldown True
}
