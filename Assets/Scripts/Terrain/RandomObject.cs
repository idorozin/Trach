using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObject : MonoBehaviour
{
   //[SerializeField] private List<PObject<GameObject>> prefabs;

    private ProbabilityItemPool itemPool;
    void Start()
    {
        string prefab = GetRandomPrefab();
        if (prefab == null)
            return;
        //Instantiate(prefab, transform.position, Quaternion.identity);

    }
    
    private string GetRandomPrefab()
    {
        return itemPool.GetRandomItem();
    }

}
