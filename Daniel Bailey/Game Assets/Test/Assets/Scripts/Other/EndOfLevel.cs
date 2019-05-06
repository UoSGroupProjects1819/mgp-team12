using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndOfLevel : MonoBehaviour
{
    public AudioSource AudioSrc;
    public CanvasGroup EndOfLevelCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            AudioSrc.Play();
            EndOfLevelCanvas.alpha = 1;
            EndOfLevelCanvas.interactable = true;
            EndOfLevelCanvas.blocksRaycasts = true;
            Time.timeScale = 0;
        }
    }
}
