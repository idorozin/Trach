
using System.Collections.Generic;
using UnityEngine;

public interface IPooledObject
{
    string Tag { get; set; }

    void ReturnToPool();
}
