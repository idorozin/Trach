

using UnityEngine;

[System.Serializable]
public class PObject<T>
{
    [HideInInspector]
    public int probability;
    public int minRange;
    public int maxRange;
    public T item;

    public bool MatchesNum(int num)
    {
        return num >= minRange && num < maxRange;
    }
   
}
