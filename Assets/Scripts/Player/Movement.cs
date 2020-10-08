using System;
using System.Collections;
using System.Collections.Generic;
//using System.Transactions;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float thrust;

    [SerializeField] public float forwardSpeed = 0.02f;
    private Vector2 lastMousePos;

    private Vector3 force;
    [SerializeField] private ForceMode forcemode;

    [SerializeField] private float maxVelocity;
    [SerializeField] private float forceMultiplier;

    private bool lastPoszero = true;
    
    void Update()
    {
        Vector2 deltapos = Vector2.zero;

        if (Input.GetMouseButton(0))
        {
            Vector2 currentMousePos = Input.mousePosition;
            if (lastPoszero)
            {
                lastPoszero = false;
                lastMousePos = currentMousePos;
            }

            deltapos = currentMousePos - lastMousePos;
            lastMousePos = currentMousePos;
            var forceX = deltapos.x * thrust;
            if (Math.Abs(forceX) > maxVelocity)
            {
                forceX = forceX > 0 ? maxVelocity : -maxVelocity;
            }

            forceX_ = forceX;


            force = new Vector3(forceX, 0f, 0f);
        }
        else
        {
            lastPoszero = true;
            lastMousePos = Vector2.zero;
        }
    }


    private void FixedUpdate()
    {
        rb.AddForce(force*forceMultiplier, forcemode);
        rb.velocity = Vector3.forward * forwardSpeed;
        force = Vector3.zero;
    }


    [SerializeField] private float amount;
    [SerializeField] private float rotateSpeed;

    [SerializeField] private float multiplier;

    private float forceX_;
    void Start()
    {
        StartCoroutine(up());
    }

    IEnumerator up()
    {
        while (forwardSpeed < 100)
        {
            yield return new WaitForSeconds(15f);
            forwardSpeed++;
        }
    }
}