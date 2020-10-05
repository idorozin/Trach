using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour,IPooledObject
{
    public string Tag { get; set; }

    [SerializeField]
    private ParticleSystem ps;
    
    private void OnEnable()
    {
        ps.Play(true);
    }

    void Update()
    {
        if (!ps.isPlaying)
            ReturnToPool();
    }

    private void ReturnToPool()
    {
        gameObject.SetActive(false);
        ps.Stop(true);
        ObjectPool.Instance.ReturnObject(Tag , gameObject);
    }
}
