
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform playerpos;
    public Score score;
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }
}
