using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int Health;
    public CanvasGroup GameOver;
    public TextMeshProUGUI HealthText;

    private void Update()
    {
        HealthText.text = "Health = " + Health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Health = Health - 1;
            if (Health <= 0)
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                GameOver.alpha = 1;
                GameOver.blocksRaycasts = true;
                GameOver.interactable = true;
                Time.timeScale = 0;
            }
        }
    }
}
