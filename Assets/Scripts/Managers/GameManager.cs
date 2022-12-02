
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform playerpos;
    public Score score;
    public static GameManager Instance;
    public Canvas canvas;
    public Camera camera;
    public bool menu = false;
    [SerializeField]
    private LoseScreen loseScreen;
    private void Awake()
    {
        Instance = this;
    }
    
    public float playerSpeed;
    //TODO
    public bool fly;


    public bool pause = false;
    
    private void Update()
    {
        if (pause && Time.timeScale != 0)
        {
            Time.timeScale = 0;
            pause = false;
        }
        
    }


    public void GameOver()
    {
        loseScreen.gameObject.SetActive(true);
        loseScreen.InitializeLoseScreen(score.GetScore(), score.GetCoinsEarned());
        //Time.timeScale = 0;
        DataManager.instance.playerData.coins += score.GetCoinsEarned();
        if (score.GetScore() > DataManager.instance.playerData.highScore)
        {
            DataManager.instance.playerData.highScore = score.GetScore();
        }
        DataManager.instance.SaveData();
        AdManager.Instance.ShowInterstitial();
        Time.timeScale = 0;
        pause = true;
    }
}
