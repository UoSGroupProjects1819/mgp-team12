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
    public int NumOfCurrent;
    public int NumOfStarting = 10;
    public int CurrentIndex = 0;
    public bool Changing = false;

    public List<GameObject> TrapInventory;

    public GameObject PlaceUp;
    public GameObject PlaceDown;
    public GameObject PlaceLeft;
    public GameObject PlaceRight;

    public bool CanPlace;

    public AudioClip TrapPickup;
    public AudioClip Casting;
    public AudioSource AudioSrc;
    public TextMeshProUGUI CurrentTrapHUD;

    // Start is called before the first frame update
    void Start()
    {
        CurrentTrap = StartingTrap;
        NumOfCurrent = NumOfStarting;
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

        if (TrapInventory.Count > 1)
        {
            if (Changing == false)
            {
                if (Input.GetAxisRaw("NextTrap") == 1)
                {
                    StartCoroutine(NextTrap());
                }

                else if (Input.GetAxisRaw("NextTrap") == -1)
                {
                    StartCoroutine(LastTrap());
                }
            }

            CurrentTrapHUD.text = CurrentTrap.name;
        }
    }

    public IEnumerator NextTrap()
    {
        Changing = true;
        //Save new number of trap being changed
        OldTrap();
        //Move to Next Trap
        if (CurrentIndex == TrapInventory.Count - 1)
        {
            CurrentIndex = 0;
        }
        else
        {
            CurrentIndex += 1;
        }
        CurrentTrap = TrapInventory[CurrentIndex];
        //Set Number of Traps to number of new traps
        NewTrap();
        yield return new WaitForSecondsRealtime(2);
        Changing = false;
    }

    public IEnumerator LastTrap()
    {
        Changing = true;
        //Save new number of trap being changed
        OldTrap();
        //Move to Previous Trap
        if (CurrentIndex == 0)
        {
            CurrentIndex = TrapInventory.Count - 1;
        }
        else
        {
            CurrentIndex -= 1;
        }
        CurrentTrap = TrapInventory[CurrentIndex];
        //Set Number of Traps to number of new traps
        NewTrap();
        yield return new WaitForSecondsRealtime(2);
        Changing = false;
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
            if (NumOfCurrent > 0)
            {
                NumOfCurrent -= 1;
                PlayCastSound();
                CanPlace = false;
                Instantiate(CurrentTrap, PlaceLeft.transform.position, Quaternion.identity);
                StartCoroutine(TrapCooldown());
            }

        }

        if (Input.GetAxisRaw("PlaceLeft") == -1)
        {
            if (NumOfCurrent > 0)
            {
                NumOfCurrent -= 1;
                PlayCastSound();
                CanPlace = false;
                Instantiate(CurrentTrap, PlaceRight.transform.position, Quaternion.identity);
                StartCoroutine(TrapCooldown());
            }
        }

        if (Input.GetAxisRaw("PlaceUp") == 1)
        {
            if (NumOfCurrent > 0)
            {
                NumOfCurrent -= 1;
                PlayCastSound();
                CanPlace = false;
                Instantiate(CurrentTrap, PlaceUp.transform.position, Quaternion.identity);
                StartCoroutine(TrapCooldown());
            }
        }

        if (Input.GetAxisRaw("PlaceUp") == -1)
        {
            if (NumOfCurrent > 0)
            {
                NumOfCurrent -= 1;
                PlayCastSound();
                CanPlace = false;
                Instantiate(CurrentTrap, PlaceDown.transform.position, Quaternion.identity);
                StartCoroutine(TrapCooldown());
            }
        }
    }

    public void PlayCastSound()
    {
        AudioSrc.clip = Casting;
        AudioSrc.Play();
    }

    public void OldTrap()
    {
        //Find Current Trap
        //Set Number of that trap to be Number of current trap
        if (CurrentTrap.gameObject.tag == "StartingTrap")
        {
            NumOfStarting = NumOfCurrent;
        }
        else if(CurrentTrap.gameObject.tag == "FlameTrap")
        {
            NumOfFlame = NumOfCurrent;
        }
        else if(CurrentTrap.gameObject.tag == "SleepTrap")
        {
            NumOfSleep = NumOfCurrent;
        }
        else if(CurrentTrap.gameObject.tag == "SpikeTrap")
        {
            NumOfSpike = NumOfCurrent;
        }
    }

    public void NewTrap()
    {
        //Find New Current Trap
        //Set Number of Current Trap to be Number of new trap
        if (CurrentTrap.gameObject.tag == "StartingTrap")
        {
            NumOfCurrent = NumOfStarting;
        }
        else if (CurrentTrap.gameObject.tag == "FlameTrap")
        {
            NumOfCurrent = NumOfFlame;
        }
        else if (CurrentTrap.gameObject.tag == "SleepTrap")
        {
            NumOfCurrent = NumOfSleep;
        }
        else if (CurrentTrap.gameObject.tag == "SpikeTrap")
        {
            NumOfCurrent = NumOfSpike;
        }
    }
}
