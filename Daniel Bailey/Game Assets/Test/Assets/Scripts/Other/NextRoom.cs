using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoom : MonoBehaviour
{
    public Transform NextPositon;
    public Camera MainCamera;
    public float NextRoomSize;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MainCamera.transform.position = NextPositon.transform.position;
            MainCamera.orthographicSize = NextRoomSize;
        }
    }
}
