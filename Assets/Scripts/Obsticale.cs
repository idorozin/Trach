using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticale : MonoBehaviour
{
    [SerializeField]
    private float forwardSpeed;

    [SerializeField]
    private Rigidbody rb;
    void FixedUpdate()
    {        
        rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y,forwardSpeed);
       
    }
}
