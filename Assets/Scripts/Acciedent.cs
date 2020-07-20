using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Acciedent : MonoBehaviour
{
    [SerializeField] private GameObject restart;
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }    
        
        if (other.collider.gameObject.CompareTag("Border"))
        {
           // Debug.Log(other.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>().velocity);
           this.gameObject.SetActive(false);
            //Destroy(other.gameObject.transform.parent.gameObject);
            //Destroy(this.gameObject.transform.parent.gameObject);
        }
    }
}
