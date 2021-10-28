﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Accident : MonoBehaviour
{
    [SerializeField] private Obstacle obs;
 
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.CompareTag("Player"))
        {
            ObjectPool.Instance.ReturnAllObjectsToPool();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }    
        
        else if (other.collider.gameObject.CompareTag("Border") || other.collider.gameObject.CompareTag("Bulldozer"))
        {
            obs.Destroy();
        }

        if (!other.collider.gameObject.CompareTag("Floor"))
        {
            obs.contact = true;
        }
        
    }

}
