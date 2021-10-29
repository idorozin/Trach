using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IPooledObject))]
public class ReturnObjectToPoolWhenBehindPlayer : MonoBehaviour
{
    private IPooledObject pooledObject;
    [SerializeField]
    private bool autoDestroy = true;

    void Start()
    {
        pooledObject = GetComponent<IPooledObject>();
    }

    void Update()
    {
        if(autoDestroy && GameManager.Instance.playerpos.position.z -20 > transform.position.z)
            pooledObject.ReturnToPool();
    }

}
