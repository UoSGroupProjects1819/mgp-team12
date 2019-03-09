using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    //Movement Variables
    public Rigidbody2D RigidBody;
    public float Movespeed;

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
}
