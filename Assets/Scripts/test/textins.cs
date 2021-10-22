using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textins : MonoBehaviour
{
    [SerializeField] private GameObject go;
    [SerializeField] private Transform canvas;
    [SerializeField]
    private GameObject go2;

    [ContextMenu("spawn")]
    public void ins()
    {
        GameObject go_ = Instantiate(go,canvas);
    }    
    [ContextMenu("spawn2")]
    public void ins2()
    {
        GameObject go_ = Instantiate(go2,canvas);
    }
}
