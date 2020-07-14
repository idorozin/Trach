using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offest;

    private void LateUpdate()
    {
        if (target == null)
            return;
        Vector3 disiredPosition = target.position + offest;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, disiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothPosition;
    }
}
