using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AICatch : MonoBehaviour
{
    public CanvasGroup GameOver;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            GameOver.alpha = 1;
            GameOver.blocksRaycasts = true;
            GameOver.interactable = true;
            Time.timeScale = 0;
        }
    }
}
