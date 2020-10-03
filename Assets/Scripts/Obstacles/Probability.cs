
[System.Serializable]
public class Probability
{

    public int minRange;
    public int maxRange;

    public bool MatchesNum(int num)
    {
        return num >= minRange && num < maxRange;
    }
}
