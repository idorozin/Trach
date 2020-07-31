using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aa : MonoBehaviour
{

    [SerializeField] private Transform go;

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.position.x,transform.position.y,go.position.z+2f);
    }
}
