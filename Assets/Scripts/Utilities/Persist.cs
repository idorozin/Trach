
using UnityEngine;

public class Persist : MonoBehaviour
{
    private IPooledObject pooledObject;

    private void Start()
    {
        pooledObject = GetComponent<IPooledObject>();
        if(pooledObject == null)
            Debug.Log(gameObject.name);
        ObjectPool.Instance.Return += BackToPool;
    }

    private void BackToPool()
    {
        pooledObject.ReturnToPool();
    }
}
