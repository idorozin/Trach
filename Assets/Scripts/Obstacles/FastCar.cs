using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
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

    private GameObject canvas_;
    private GameObject mark = null;
    public Canvas canvas;
    private bool done;

    private TargetIndicator targetIndicator;


    void Start()
    {
        Debug.Log("fast car start");
        canvas_ = GameObject.Find("ScoreCanvas");
        canvas = canvas_.GetComponent<Canvas>();
        rb = gameObject.GetComponent<Rigidbody>();
        targetIndicator = Instantiate(exclamationMark, canvas.transform).GetComponent<TargetIndicator>();
        targetIndicator.InitialiseTargetIndicator(gameObject, Camera.main, canvas);
    } 

    void Update(){
        
        NotifyPlayer();
        if(transform.position.z > GameManager.Instance.playerpos.position.z)
            rb.constraints = RigidbodyConstraints.None;
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
            other.gameObject.GetComponent<Obstacle>().Destroy();
            if (lives == 0)
                obs.Destroy();
        }
    }

    void NotifyPlayer()
    {
        
        if (done)
            return;
        
        /*
        if (GameManager.Instance.playerpos.position.z - transform.position.z < 0.1f)
        {
            done = true;
            targetIndicator.DisableIndicator()
        }
        */


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
}
