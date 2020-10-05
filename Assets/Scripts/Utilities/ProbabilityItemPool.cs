

using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ProbabilityItemPool : MonoBehaviour
{
    [SerializeField]
    public int outOf = 100;

    [SerializeField]
    public PObject[] items;

    [SerializeField]
    private string defaultOption = null;

    public string GetRandomItem()
    {            
        int randNum = UnityEngine.Random.Range(0,outOf);
        foreach (var item in items)
        {
            if (item.MatchesNum(randNum))
            {
                return item.name;
            }
        }
        
        return defaultOption;
    }

}