
using UnityEngine;

public class RandomObject : MonoBehaviour
{

    [SerializeField]
    private ProbabilityItemPool itemPool;

    [SerializeField] private Transform parent;
    void Start()
    {
        string prefab = GetRandomPrefab();
        if (prefab == null)
            return;
        GameObject go = ObjectPool.Instance.GetObject(prefab);
        go.transform.parent = parent;
        go.transform.position = transform.position;
        
    }
    
    private string GetRandomPrefab()
    {
        return itemPool.GetRandomItem();
    }

}
