using System;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private List<PoolObject> objectsInPool;

    public static ObjectPool Instance;

    [SerializeField] private Transform parent;



    private Dictionary<string, Queue<GameObject>> pools = new Dictionary<string, Queue<GameObject>>();
    private Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();
    private List<IPooledObject> allObjects = new List<IPooledObject>();
    private GameObject go;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            Init();
        }
    }


    private void Init()
    {
        foreach (var poolObject in objectsInPool)
        {
            pools.Add(poolObject.tag, new Queue<GameObject>());
            prefabs.Add(poolObject.tag, poolObject.prefab);
            AddObject(poolObject.tag, poolObject.startSize);
        }
    }


    private void AddObject(string s, int i)
    {
        Debug.Log(s);
        for (int j = 0; j < i; j++)
        {
            GameObject go = Instantiate(prefabs[s]);
            go.SetActive(false);
            var component = go.GetComponent<IPooledObject>();
            component.Tag = s;
            allObjects.Add(component);
            pools[s].Enqueue(go);
            go.transform.parent = parent;
        }
    }

    public GameObject GetObject(string tag, bool setActive = true, bool resetRotation = true)
    {
        if (pools[tag].Count == 0)
        {
            AddObject(tag, 1);
        }

        go = pools[tag].Dequeue();
        if (go == null)
            return null;
        if (resetRotation)
        {
            go.transform.rotation = Quaternion.identity;
        }

        if (setActive)
        {
            go.SetActive(true);
        }

        return go;
    }

    public void ReturnObject(string tag, GameObject go, bool setParent = true)
    {
        if (setParent)
            go.transform.parent = this.gameObject.transform;
        if (!go.activeSelf)
            return;
        go.SetActive(false);
        pools[tag].Enqueue(go);
    }

    public void ReturnAllObjectsToPool()
    {
        foreach (IPooledObject pooledObject in allObjects)
        {
            pooledObject.ReturnToPool();
        }
    }
}

[Serializable]
internal class PoolObject
{
    public GameObject prefab;
    public string tag;
    public int startSize;
}