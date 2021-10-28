using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private void OnEnable()
    {
        transform.rotation = Quaternion.identity;
    }

    [SerializeField]
    private float rotateSpeed;

    void Update()
    {
        transform.Rotate(0,rotateSpeed * Time.deltaTime * 100, 0, Space.World);
    }
}
