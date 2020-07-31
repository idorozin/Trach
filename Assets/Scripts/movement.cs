using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField]
    private Rigidbody rb;

    [SerializeField] private float thrust;

    [SerializeField] private float forwardSpeed = 0.02f;
    [SerializeField] private float wallDistance = 5f;
    [SerializeField] private float maxCameraDistance = 7f;
    private Vector2 lastMousePos;

    [SerializeField]
    private bool a = true;
    void Start()
    {

    }

    [SerializeField] private Transform pivot;

    private Vector3 force;
    [SerializeField]
    private ForceMode forcemode;

    private bool left;
    private bool right;
    private bool middle;
    [SerializeField]
    private float multiplier;
    [SerializeField]
    private float rotateSpeed;
    void Update()
    {

        Vector2 deltapos = Vector2.zero;

        if (Input.GetMouseButton(0))
        {
            Vector2 currentMousePos = Input.mousePosition;
            if (lastMousePos == Vector2.zero)
                lastMousePos = currentMousePos;

            deltapos = currentMousePos - lastMousePos;
            lastMousePos = currentMousePos;
            
            force = new Vector3(deltapos.x , 0f , 0f) * thrust;
            transform.Rotate(0,deltapos.x*multiplier,0 ,Space.World);
            if (deltapos.x == 0)
            {
                if (transform.eulerAngles.y > 0.5f && transform.eulerAngles.y < 200)
                {
                    Debug.Log("***");
                    transform.Rotate(0, -rotateSpeed, 0, Space.World);
                }


                if (transform.eulerAngles.y < 359.5f && transform.eulerAngles.y > 200)
                {
                    transform.Rotate(0, rotateSpeed, 0, Space.World);
                }
            }
        }
        else
        {
     
     
            if (transform.eulerAngles.y > 0.5f && transform.eulerAngles.y < 200)
            {
                Debug.Log("***");
                transform.Rotate(0, -rotateSpeed, 0, Space.World);
            }


            if (transform.eulerAngles.y < 359.5f && transform.eulerAngles.y > 200)
            {
                transform.Rotate(0, rotateSpeed, 0, Space.World);
            }

            lastMousePos = Vector2.zero;
        }


    }


    private void FixedUpdate()
    {        

/*        if (transform.position.x > wallDistance)
        {
            force = Vector3.zero;
        }

        if (transform.position.x < -wallDistance)
        {
            force = Vector3.zero;
        }*/

        /*if (transform.position.z < Camera.main.transform.position.z + maxCameraDistance)
        {
            pos.z = Camera.main.transform.position.z + maxCameraDistance;
        }*/

        rb.AddForce(force ,forcemode);
        rb.velocity = Vector3.forward * forwardSpeed;
        force = Vector3.zero;
    }

    private void LateUpdate()
    {

    }
}
