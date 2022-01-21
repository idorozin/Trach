using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private Transform canvas;
    [SerializeField] private GameObject bonusVisual;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private TextMeshProUGUI coinsText;
    private Vector3 start;
    private int coins;

    public int GetCoinsEarned()
    {
        return coins;
    }

    void Start()
    {
        start = player.position;
        EventManager.Instance.onCoinCollected.Subscribe(OnCoinCollected);
    }

    private void OnCoinCollected()
    {
        coins += 1;
        coinsText.text = coins.ToString();    
    }

    void Update()
    {
        text.text = (Math.Round(player.transform.position.z - start.z)) + "";
    }

    public int GetScore()
    {
        return (int) (Math.Round(player.transform.position.z - start.z));
    }

    public void OnCarDestroyed()
    {
        coins += 10;
        coinsText.text = coins.ToString();
        /*GameObject go = ObjectPool.Instance.GetObject("bonus");
        if (go == null)
            return;
        go.transform.SetParent(canvas,false);
        go.transform.parent = canvas.transform;
        go.GetComponent<FadeUp>().DoFadeUp();*/
    }
}
