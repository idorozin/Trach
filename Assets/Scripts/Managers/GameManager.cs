
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform playerpos;
    public Score score;
    public static GameManager Instance;
    public Canvas canvas;
    public Camera camera;
    
    [SerializeField]
    private LoseScreen loseScreen;
    private void Awake()
    {
        Instance = this;
    }
    
    public float playerSpeed;


    public void GameOver()
    {
        loseScreen.gameObject.SetActive(true);
        loseScreen.InitializeLoseScreen(score.GetScore(), score.GetCoinsEarned());
        Time.timeScale = 0;

    }
}
