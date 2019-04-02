using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTrap : MonoBehaviour
{
    public GameObject StartingTrap;
    public GameObject SpikeTrap;
    public GameObject FlameTrap;
    public GameObject CurrentTrap;

    public GameObject PlaceUp;
    public GameObject PlaceDown;
    public GameObject PlaceLeft;
    public GameObject PlaceRight;

    public bool CanPlace;
    // Start is called before the first frame update
    void Start()
    {
        CurrentTrap = StartingTrap;
        CanPlace = true;
    }

    // Update is called once per frame
    void Update()
    {
       if (CanPlace == true)
        {
            if (Input.GetAxisRaw("PlaceLeft") == 1)
            {
                CanPlace = false;
                Instantiate(CurrentTrap, PlaceLeft.transform.position, Quaternion.identity);
                StartCoroutine(TrapCooldown());
            }

            if (Input.GetAxisRaw("PlaceLeft") == -1)
            {
                CanPlace = false;
                Instantiate(CurrentTrap, PlaceRight.transform.position, Quaternion.identity);
                StartCoroutine(TrapCooldown());
            }

            if (Input.GetAxisRaw("PlaceUp") == 1)
            {
                CanPlace = false;
                Instantiate(CurrentTrap, PlaceUp.transform.position, Quaternion.identity);
                StartCoroutine(TrapCooldown());
            }

            if (Input.GetAxisRaw("PlaceUp") == -1)
            {
                CanPlace = false;
                Instantiate(CurrentTrap, PlaceDown.transform.position, Quaternion.identity);
                StartCoroutine(TrapCooldown());
            }
        } 
    }

    public IEnumerator TrapCooldown()
    {
        yield return new WaitForSeconds(3);
        CanPlace = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "FlameTrapPickup")
        {
            CurrentTrap = FlameTrap;
        }
        else if (collision.gameObject.tag == "SpikeTrapPickup")
            {
                CurrentTrap = SpikeTrap;
            }
    }
}
