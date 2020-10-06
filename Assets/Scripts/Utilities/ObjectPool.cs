
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Dictionary<string,Queue<GameObject>> pools = new Dictionary<string, Queue<GameObject>>();

    private Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();
    
    [SerializeField] private List<PoolObject> objectsInPool;

    public static ObjectPool Instance;
   
    public Transform playerpos;
    [SerializeField]
    private Transform parent;

    private void Awake()
    {
        Instance = this;
        Init();

    }

   
    
    private void Init()
    {
        foreach (var poolObject in objectsInPool)
        {
            pools.Add(poolObject.tag , new Queue<GameObject>());
            prefabs.Add(poolObject.tag , poolObject.prefab);
        }
    }

    private void AddObject(string s, int i)
    {
        Errorr(s);

        for (int j = 0; j < i; j++)
        {
            GameObject go = Instantiate(prefabs[s]);
            go.SetActive(false);
            var component = go.GetComponent<IPooledObject>();
            if (component != null)
                component.Tag = s;
            pools[s].Enqueue(go);
            go.transform.parent = parent;
        }
    }

    public GameObject GetObject(string tag)
    {
        Errorr(tag);

        if (!pools[tag].Any())
        {
            AddObject(tag, 1);
        }

        GameObject go = pools[tag].Dequeue();
        go.transform.rotation = Quaternion.identity;
        go.SetActive(true);
        return go;
    }

    public void ReturnObject(string tag , GameObject go)
    {
        Errorr(tag);
        go.SetActive(false);
        pools[tag].Enqueue(go);
    }

    void Errorr (string tag){
        if (!pools.ContainsKey(tag) || !prefabs.ContainsKey(tag))
        {
            Debug.LogError(tag);
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
