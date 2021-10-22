
using UnityEngine;

public class Persist : MonoBehaviour
{
    private IPooledObject pooledObject;

    private void Start()
    {
        pooledObject = GetComponent<IPooledObject>();
        ObjectPool.Instance.Return += BackToPool;
    }

    private void BackToPool()
    {
        pooledObject.ReturnToPool();
    }
}
