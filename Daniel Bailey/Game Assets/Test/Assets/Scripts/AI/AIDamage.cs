using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDamage : MonoBehaviour
{
    public float Health;
    public GameObject explosionEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "StartingTrap")
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
        explosionEffect.GetComponent<ParticleSystem>().Play(true);
    }
}
    

