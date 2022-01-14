using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    public List<GameObject> toHide;
    
    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        //TODO
    }

    public void InitializeLoseScreen(int score)
    {
        scoreText.text = score.ToString();
        foreach (var o in toHide)
        {
            o.SetActive(false);
        }
    }

}
