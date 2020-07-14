using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acciedent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Time.timeScale = 0;
            //Destroy(other.gameObject.transform.parent.gameObject);
            //Destroy(this.gameObject.transform.parent.gameObject);
        }//a
    }
}
