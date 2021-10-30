
using UnityEngine;

public abstract class GenericPooledObject : Destroyable, IPooledObject
{
    public string Tag { get; set; }
    public abstract void ReturnToPool();

    public override void Destroy()
    {
        ReturnToPool();
    }
}
