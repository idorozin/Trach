using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticale : MonoBehaviour
{
    [SerializeField]
    public float forwardSpeed;

    [SerializeField]
    private Rigidbody rb;

    public bool contact = false ;



    void FixedUpdate()
    {
        if (contact)
        {
            rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y,forwardSpeed);       
        }
        else
            rb.velocity = new Vector3(0,rb.velocity.y,forwardSpeed);       
    }
}
