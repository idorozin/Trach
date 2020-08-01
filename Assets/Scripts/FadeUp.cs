using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class FadeUp : MonoBehaviour
{
    [SerializeField]
    private float movement;
    

    [SerializeField] private TextMeshProUGUI text;

    [SerializeField]
    private float time = 1f;

    [SerializeField] private float fadeValue;

    void Start()
    {
        GetComponent<RectTransform>().anchoredPosition = new Vector3(19f, -244f, 0);
        transform.DOMoveY(transform.position.y + movement, time);
        text.DOFade(fadeValue, time);
    }
}
