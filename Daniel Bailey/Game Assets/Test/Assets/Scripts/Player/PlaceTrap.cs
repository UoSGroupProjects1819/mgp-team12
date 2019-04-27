using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaceTrap : MonoBehaviour
{
    public GameObject StartingTrap;
    public GameObject SpikeTrap;
    public int NumOfSpike = 0;
    public GameObject FlameTrap;
    public int NumOfFlame = 0;
    public GameObject SleepTrap;
    public int NumOfSleep = 0;
    public GameObject CurrentTrap;

    public List<GameObject> TrapInventory;

    public GameObject PlaceUp;
    public GameObject PlaceDown;
    public GameObject PlaceLeft;
    public GameObject PlaceRight;

    public bool CanPlace;

    public AudioClip TrapPickup;
    public AudioSource AudioSrc;
    public TextMeshProUGUI CurrentTrapHUD;

    // Start is called before the first frame update
    void Start()
    {
        CurrentTrap = StartingTrap;
        CanPlace = true;
        TrapInventory.Add(StartingTrap);
        CurrentTrapHUD.text = CurrentTrap.name;
    }

    // Update is called once per frame
    void Update()
    {
       if (CanPlace == true)
        {
            PlacingTrap();
        } 
    }

    public IEnumerator TrapCooldown()
    {
        yield return new WaitForSeconds(3);
        CanPlace = true;
    }

    //Pickup trap
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FlameTrapPickup")
        {
            AudioSrc.clip = TrapPickup;
            AudioSrc.Play();
            if (TrapInventory.Contains(FlameTrap))
            {
                NumOfFlame += 3;
            }
            else
            {
                TrapInventory.Add(FlameTrap);
                NumOfFlame += 3;
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "SpikeTrapPickup")
        {
            AudioSrc.clip = TrapPickup;
            AudioSrc.Play();
            if (TrapInventory.Contains(SpikeTrap))
            {
                NumOfSpike += 3;
            }
            else
            {
                TrapInventory.Add(SpikeTrap);
                NumOfSpike += 3;
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "SleepTrapPickup")
        {
            AudioSrc.clip = TrapPickup;
            AudioSrc.Play();
            if (TrapInventory.Contains(SleepTrap))
            {
                NumOfSleep += 3;
            }
            else
            {
                TrapInventory.Add(SleepTrap);
                NumOfSleep += 3;
            }
            Destroy(collision.gameObject);
        }
    }

    public void PlacingTrap()
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
