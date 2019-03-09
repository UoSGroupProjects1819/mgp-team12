using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.tag == ("UpgradedTrap"))
        {
            if (collision.tag == ("Enemy"))
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
