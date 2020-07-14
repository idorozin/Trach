using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class movement : MonoBehaviour
{

    [SerializeField]
    private Rigidbody rb;

    [SerializeField] private float thrust;

    [SerializeField] private float forwardSpeed = 0.02f;
    [SerializeField] private float wallDistance = 5f;
    [SerializeField] private float maxCameraDistance = 7f;
    private Vector2 lastMousePos;
    
    
    void Start()
    {

    }

    void Update()
    {
        rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y,forwardSpeed);
        Vector2 deltapos = Vector2.zero;

        if (Input.GetMouseButton(0))
        {
            Vector2 currentMousePos = Input.mousePosition;
            if (lastMousePos == Vector2.zero)
                lastMousePos = currentMousePos;

            deltapos = currentMousePos - lastMousePos;
            lastMousePos = currentMousePos;
            
            Vector3 force = new Vector3(deltapos.x , 0f , 0f) * thrust;
            rb.AddForce(force);      
        }
        else
        {
            lastMousePos = Vector2.zero;
        }
    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        if (transform.position.x > wallDistance)
        {
            pos.x = wallDistance;
        }

        if (transform.position.x < -wallDistance)
        {
            pos.x = -wallDistance;
        }

        if (transform.position.z < Camera.main.transform.position.z + maxCameraDistance)
        {
            pos.z = Camera.main.transform.position.z + maxCameraDistance;
        }

        transform.position = pos;
    }
}
