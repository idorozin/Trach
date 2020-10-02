using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float forwardSpeed;


    void Update()
    {
        rb.velocity = new Vector3(0, 0, forwardSpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.CompareTag("Obstacle"))
        {
            other.gameObject.GetComponent<Acciedent>().Destroy();
            Destroy(this.gameObject);
        }
    }
}
