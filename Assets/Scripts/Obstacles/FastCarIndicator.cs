using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FastCarIndicator : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, GameManager.Instance.playerpos.position.z - 10f);
    }
}
