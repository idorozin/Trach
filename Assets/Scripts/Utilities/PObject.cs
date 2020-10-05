

using UnityEngine;

[System.Serializable]
public class PObject
{
    public GameObject item;
    [HideInInspector]
    public int probability;
    public int minRange;
    public int maxRange;
    public string name;

    public bool MatchesNum(int num)
    {
        return num >= minRange && num < maxRange;
    }
   
}
