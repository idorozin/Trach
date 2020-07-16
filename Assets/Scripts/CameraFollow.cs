using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
 
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float smoothSpeedX = 0.125f;    
    [SerializeField]
    private float smoothSpeedZ = 0.125f;
    [SerializeField]
    private Vector3 offset;

    void Update ()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPositionX = Vector3.Lerp(transform.position, desiredPosition, smoothSpeedX * Time.deltaTime);
        Vector3 smoothedPositionZ = Vector3.Lerp(transform.position, desiredPosition, smoothSpeedZ * Time.deltaTime);
        var smoothedPosition = new Vector3(smoothedPositionX.x,transform.position.y,smoothedPositionZ.z);
        transform.position = new Vector3(target.transform.position.x + offset.x,transform.position.y,smoothedPositionZ.z);
    }
}
