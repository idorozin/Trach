
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform playerpos;
    public Score score;
    public static GameManager Instance;
    public Canvas canvas;
    public Camera camera;
    
    private void Awake()
    {
        Instance = this;
    }
    
    public float playerSpeed;

}
