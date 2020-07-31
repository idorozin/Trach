using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Acciedent : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private GameObject restart;
    [SerializeField] private Obsticale obs;
    private bool destroyed;

    
    void Start()
    {
       score =  GameObject.Find("Score").GetComponent<Score>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }    
        
        else if (other.collider.gameObject.CompareTag("Border"))
        {
            destroyed = true;
            score.OnCarDestroyed();
            gameObject.SetActive(false);

            // Debug.Log(other.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>().velocity);
            //Destroy(other.gameObject.transform.parent.gameObject);
            //Destroy(this.gameObject.transform.parent.gameObject);
        }

        if (!other.collider.gameObject.CompareTag("Floor"))
        {
            obs.contact = true;
        }

    }
    
    private void OnDrawGizmos()
    {
        if (!destroyed)
            return;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x,transform.position.y,transform.position.z),3 );
    }
}
