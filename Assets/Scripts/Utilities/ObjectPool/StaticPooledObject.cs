using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticPooledObject : GenericPooledObject
{
    public override void ReturnToPool()
    {
        ObjectPool.Instance.ReturnObject(Tag,gameObject);
    }
}
