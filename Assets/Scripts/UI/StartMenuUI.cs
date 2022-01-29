using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartMenuUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI coinsText;
    [SerializeField]
    private TextMeshProUGUI highScoreText;

    public void Start()
    {
        coinsText.text = "" + DataManager.instance.playerData.coins;
        highScoreText.text = "" + DataManager.instance.playerData.highScore;
    }
}
