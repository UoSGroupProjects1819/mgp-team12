using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class HighScoreScript : MonoBehaviour
{
    public float HighScore;
    public float CurrentTime;
    public TextMeshProUGUI HighScoreText;
    public TextMeshProUGUI SurvivedTime;
    public TextMeshProUGUI OldHighScore;

    void Start()
    {
        HighScore = PlayerPrefs.GetFloat("HighScore");
        OldHighScore.text = HighScore.ToString();
    }

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            CurrentTime = 0;
        }
        CurrentTime = Time.timeSinceLevelLoad;

        if (CurrentTime >= HighScore)
        {
            PlayerPrefs.SetFloat("HighScore", CurrentTime);
            HighScoreText.text = "A new high score!";
        }
        SurvivedTime.text =  CurrentTime + " Seconds";
    }

}