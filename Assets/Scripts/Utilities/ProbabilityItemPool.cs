

using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

[Serializable]
public class ProbabilityItemPool<T>
{
    [SerializeField]
    public int outOf = 100;

    [SerializeField]
    public PObject<T>[] items;

    [SerializeField]
    private T defaultOption = default;

    public T GetRandomItem()
    {            
        int randNum = UnityEngine.Random.Range(0,outOf);
        foreach (var item in items)
        {
            if (item.MatchesNum(randNum))
            {
                return item.item;
            }
        }
        
        return defaultOption;
    }

}