using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnStaticToPool : MonoBehaviour, IPooledObject
{
    public void Destroy()
    {
        throw new System.NotImplementedException();
    }

    public string Tag { get; set; }
    public void ReturnToPool()
    {
        throw new System.NotImplementedException();
    }
}
