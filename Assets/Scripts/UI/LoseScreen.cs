using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField] 
    private TextMeshProUGUI coinsText;

    public List<GameObject> toHide;
    
    public void PlayAgain()
    {
        ObjectPool.Instance.ReturnAllObjectsToPool();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void InitializeLoseScreen(int score, int coins)
    {
        scoreText.text = score.ToString();
        coinsText.text = coins.ToString();
        foreach (var o in toHide)
        {
            o.SetActive(false);
        }
    }

    public void Menu()
    {
        ObjectPool.Instance.ReturnAllObjectsToPool();
        Time.timeScale = 1;
        SceneManager.LoadScene("menu");
    }

}
