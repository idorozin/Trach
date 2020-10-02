using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FastCar : MonoBehaviour
{
    private int lives = 2;

    [SerializeField]
    private Acciedent acciedent;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.CompareTag("PlayerBack"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (other.collider.gameObject.CompareTag("Obstacle"))
        {
            lives--;
            other.gameObject.GetComponent<Acciedent>().Destroy();
            if (lives == 0)
                acciedent.Destroy();
        }
    }
}
