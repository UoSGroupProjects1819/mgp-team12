using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //Movement Variables
    public Rigidbody2D RigidBody;
    public float Movespeed;

    public CanvasGroup PauseMenu;
    public CanvasGroup ControlsScreen;

    private void Start()
    {
        Time.timeScale = 1;
    }

    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            RigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * Movespeed;
        }
        else
        {
            RigidBody.velocity = Vector2.zero;
        }
    }

    private void Update()
    {
        //uses the p button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                PauseMenu.alpha = 1;
                PauseMenu.interactable = true;
                PauseMenu.blocksRaycasts = true;
                Time.timeScale = 0;
            }
            else if (Time.timeScale == 0)
            {
                PauseMenu.alpha = 0;
                PauseMenu.interactable = false;
                PauseMenu.blocksRaycasts = false;
                Time.timeScale = 1;

                ControlsScreen.alpha = 0;
                ControlsScreen.blocksRaycasts = false;
                ControlsScreen.interactable = false;
            }
        }
    }
}
