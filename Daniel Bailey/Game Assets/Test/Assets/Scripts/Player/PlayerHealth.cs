using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Health = Health - 1;
            if (Health <= 0)
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                Time.timeScale = 0;
            }
        }
    }
}
