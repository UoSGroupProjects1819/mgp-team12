﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    //Get Canvas groups
    public CanvasGroup MainMenuGroup;
    public CanvasGroup HowToPlayGroup;

    //Loading next scene on Play Button press
    public void LoadLevel(string SceneToLoad)
    {
        SceneManager.LoadScene(1);
    }

    public void HowToPlay()
    {
        //Chnaging the canvas layers so that the main menu becomes hidden and buttons become uninteractable
        MainMenuGroup.alpha = 0;
        MainMenuGroup.interactable = false;
        MainMenuGroup.blocksRaycasts = false;

        //Changing the canvas layer for the rules to become visable and buttons become interactable.
        HowToPlayGroup.alpha = 1.0f;
        HowToPlayGroup.interactable = true;
        HowToPlayGroup.blocksRaycasts = true;
    }

    public void BackToMenu()
    {
        //Reversal of the HowToPlay Function
        MainMenuGroup.alpha = 1.0f;
        MainMenuGroup.interactable = true;
        MainMenuGroup.blocksRaycasts = true;

        HowToPlayGroup.alpha = 0f;
        HowToPlayGroup.interactable = false;
        HowToPlayGroup.blocksRaycasts = false;

    }


    public void QuitGame()
    {
        Application.Quit();
    }
}