using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float xspeed, yspeed, zspeed;
    Rigidbody rb;
    Vector3 nextGridSpace;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        xspeed = 2f;
        yspeed = 5f;
        zspeed = 3f;
    }


    void Update()
    {

        // if the W key was pressed - old Unity Input System
        if (Input.GetKey(KeyCode.W))
        {
            moveForward();
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3(-xspeed, 0, 1));
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3(0, 0, -zspeed));
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(xspeed, 0, 1));
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, yspeed, 0), ForceMode.Force);
        }

    }


    private void moveForward()
    {
        transform.position = this.transform.position + Vector3.forward;

        
        if (Vector3.Distance(this.transform.position, nextGridSpace) < 0.001f)
        {
            this.transform.position = nextGridSpace;
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(transform.position, nextGridSpace, 1f * Time.deltaTime);
        }
        
    }
}
