using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Score : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private Transform canvas;
    [SerializeField] private GameObject bonusVisual;
    [SerializeField]
    private TextMeshProUGUI text;
    private Vector3 start;
    private int bonus;

    void Start()
    {
        start = player.position;
    }

    void Update()
    {
        text.text = (Math.Round(player.transform.position.z - start.z) + bonus) + "";
    }

    public void OnCarDestroyed()
    {
        bonus += 50;
        GameObject go = Instantiate(bonusVisual);
        go.transform.parent = canvas;
    }
}
