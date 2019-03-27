using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoom : MonoBehaviour
{
    public Transform BackPosition;
    public Transform FrontPositon;
    public Camera MainCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Entered");
            if (this.gameObject.tag == "VerticleRoom")
            {
                if(collision.transform.position.y < this.transform.position.y)
                {
                    //move camera up
                    MainCamera.transform.position = FrontPositon.transform.position;
                }

                else
                {
                    //move camera down
                    MainCamera.transform.position = BackPosition.transform.position;
                }
            }

            if (this.gameObject.tag == "HorizontalRoom")
            {
                if (collision.transform.position.x < this.transform.position.x)
                {
                    //move camera right
                    MainCamera.transform.position = FrontPositon.transform.position;
                }

                else
                {
                    //move camera left
                    MainCamera.transform.position = BackPosition.transform.position;
                }
            }
        }
    }
}
