
using System;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    [SerializeField] private List<PoolObject> objectsInPool;

    public static ObjectPool Instance;
   
    [SerializeField]
     private Transform parent;   



    private Dictionary<string,Queue<GameObject>> pools = new Dictionary<string, Queue<GameObject>>();
    private Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();
    private GameObject go;
    public Action Return;

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
            pools.Add(poolObject.tag , new Queue<GameObject>());
            prefabs.Add(poolObject.tag , poolObject.prefab);
            AddObject(poolObject.tag , poolObject.startSize);   
        }
    }


    void Start()
    {
        //TODO call after call on persist
        Return += () =>
        {
            foreach (var key in pools.Keys)
            {
                foreach (GameObject go in pools[key])
                {
                    go.transform.parent = gameObject.transform;
                }
            }
        };
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

    public GameObject GetObject(string tag, bool setActive = true , bool resetRotation = true)
    {
        Errorr(tag);
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

    public void ReturnObject(string tag , GameObject go , bool setParent = true)
    {
        Errorr(tag);
        if(setParent)
            go.transform.parent = this.gameObject.transform;
        if(!go.activeSelf)
            return;
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
