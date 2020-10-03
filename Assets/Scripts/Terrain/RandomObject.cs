using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObject : MonoBehaviour
{
    [SerializeField] private List<PObject> prefabs;
    
    
    void Start()
    {
        GameObject prefab = GetRandomPrefab();
        if (prefab == null)
            return;
        Instantiate(prefab, transform.position, Quaternion.identity);

    }
    
    private GameObject GetRandomPrefab()
    {
        int randNum = Random.Range(0, 100);
        foreach (var prefab in prefabs)
        {
            if (prefab.prob.MatchesNum(randNum))
            {
                return prefab.prefab;
            }

        }

        return null;
    }

}
