using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float xspeed, yspeed, zspeed;
    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        xspeed = 2f;
        yspeed = 5f;
        zspeed = 3f;
    }


    void Update()
    {

        // if the W key was pressed - old Unity Input System
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.AddForce(new Vector3(0, 0, zspeed));
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(new Vector3(-xspeed, 0, 1));
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.AddForce(new Vector3(0, 0, -zspeed));
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(new Vector3(xspeed, 0, 1));
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddForce(new Vector3(0, yspeed, 0), ForceMode.Force);
        }

    }
}
