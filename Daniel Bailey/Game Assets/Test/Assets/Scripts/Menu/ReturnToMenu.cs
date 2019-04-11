using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnToMenu : MonoBehaviour {

    public CanvasGroup PauseScreen;
    public CanvasGroup ControlsScreen;

    public void ToMenu()
    {
        //Loads the menu
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void Controls()
    {
        ControlsScreen.alpha = 1;
        ControlsScreen.blocksRaycasts = true;
        ControlsScreen.interactable = true;

        PauseScreen.alpha = 0;
        PauseScreen.blocksRaycasts = false;
        PauseScreen.interactable = false;
    }

    public void BackToPause()
    {
        ControlsScreen.alpha = 0;
        ControlsScreen.blocksRaycasts = false;
        ControlsScreen.interactable = false;

        PauseScreen.alpha = 1;
        PauseScreen.blocksRaycasts = true;
        PauseScreen.interactable = true;
    }
}
