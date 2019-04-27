using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardTowerEnemy : MonoBehaviour
{
    public bool Searching;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TurnDelay", 0.0f, 5f);
    }

    public void TurnDelay()
    {
        this.transform.Rotate(0, 0, 90);
    }
}
