using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FastCar : MonoBehaviour
{
    private int lives = 3;

    [SerializeField]
    private Obstacle obs;
    [SerializeField]
    private float viewDistance;
    private Rigidbody rb;
    [SerializeField] private GameObject exclamationMark;
    
    private bool done;

    private TargetIndicator targetIndicator;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    } 

    void Update(){
        
        NotifyPlayer();
        /*if(transform.position.z > GameManager.Instance.playerpos.position.z)
            rb.constraints = RigidbodyConstraints.None;*/
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.CompareTag("PlayerBack"))
        {
            ObjectPool.Instance.Return.Invoke();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (other.collider.gameObject.CompareTag("Obstacle"))
        {
            lives--;
            Debug.Log(lives);
            other.gameObject.GetComponent<Obstacle>().Destroy();
            if (lives == 0)
                obs.Destroy();
        }
    }

    void NotifyPlayer()
    {
        if (GameManager.Instance.playerpos.position.z - transform.position.z < 100)
        {
            targetIndicator.UpdateTargetIndicator();

        }
    }

    private void OnDisable()
    {
        if (targetIndicator == null)
            return;
        targetIndicator.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        lives = 3;
        targetIndicator = Instantiate(exclamationMark, GameManager.Instance.canvas.transform).GetComponent<TargetIndicator>();
        targetIndicator.InitialiseTargetIndicator(gameObject, GameManager.Instance.camera, GameManager.Instance.canvas);
        targetIndicator.InitialiseTargetIndicator(gameObject,GameManager.Instance.camera,GameManager.Instance.canvas);
    }
}
