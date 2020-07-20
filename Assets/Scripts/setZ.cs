using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setZ : MonoBehaviour
{
    [SerializeField] private Transform positions;
    [SerializeField] private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private Vector3 lastPos;
    // Update is called once per frame
    void Update()
    {
        if (lastPos == Vector3.zero)
        {
            lastPos = player.position;
        }

        var delta = player.position.z - lastPos.z;

        foreach (Transform child in positions)
        {
            child.position =  new Vector3(child.position.x,child.position.y,child.position.z + delta);
        }

        lastPos = player.position;
    }
}
