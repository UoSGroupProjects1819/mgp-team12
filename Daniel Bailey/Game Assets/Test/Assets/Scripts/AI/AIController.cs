using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class AIController : MonoBehaviour
{
    public Patrol AIPatrolScript;
    public AIDestinationSetter AIDestinationSetterScript;
    public AILerp AILerp;

    public float Timer = -1;
    public bool SightCheck;
    public bool InRange;

    public bool CanFire = false;
    public GameObject Player;
    public GameObject Bullet;
    public GameObject BulletSpawn;
    public Vector3 BulletVector;
    public GameObject TempBullet;
    public Rigidbody2D TempBody;

//#-----------------------Chasing or patrolling---------------------#
    private void Start()
    {
        AIDestinationSetterScript.enabled = false;
        Player = GameObject.FindGameObjectWithTag("Player");
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
            SightCheck = false;
            Timer = 13;
            AILerp.speed = 5;
            CanFire = true;
            InRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player has left line of sight");
            InRange = false;
            SightCheck = true;
            CanFire = false;
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
            AILerp.speed = 3;
            //Disable Patrol script
            AIPatrolScript.enabled = true;
            Timer = -1;
        }

        if (CanFire == true && InRange == true)
        {
            Firing();
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
    public void Firing()
    {
        CanFire = false;
        //Spawn Bullet
        TempBullet = Instantiate(Bullet, BulletSpawn.transform.position, Quaternion.identity);
        // Launch Bullet
        BulletVector.x = this.transform.position.x - Player.transform.position.x;
        BulletVector.y = this.transform.position.y - Player.transform.position.y;
        TempBody = TempBullet.gameObject.GetComponent<Rigidbody2D>();
        TempBody.AddForce(-BulletVector *7, ForceMode2D.Impulse);
        //Active Cooldown
        StartCoroutine(FireDelay());
    }

    //CoolDown
    private IEnumerator FireDelay()
    {
        yield return new WaitForSecondsRealtime(3);
        CanFire = true;
    }
}
