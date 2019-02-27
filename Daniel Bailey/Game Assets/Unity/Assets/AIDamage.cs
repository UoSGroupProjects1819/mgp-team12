using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDamage : MonoBehaviour
{
    public float Health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "StartingTrap")
        {
            if (Health == 1)
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                Health = Health - 1;
            }
            Destroy(collision.gameObject);
        }
    }
}
