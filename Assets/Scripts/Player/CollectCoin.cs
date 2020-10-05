using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField]
    private MissileSpawner missileSpawner;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TrackSides"))
        {
            GameObject.Find("Player").GetComponent<MissileSpawner>().misiiles += 3;
            Destroy(this.gameObject);
        }
    }
}
