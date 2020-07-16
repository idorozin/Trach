using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acciedent : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.CompareTag("Player"))
        {
           // Debug.Log(other.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>().velocity);
           Time.timeScale = 0;
            //Destroy(other.gameObject.transform.parent.gameObject);
            //Destroy(this.gameObject.transform.parent.gameObject);
        }//a
    }
}
