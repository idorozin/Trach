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
        ps.time = 0;
        ps.Play(true);
        StartCoroutine(ReturnToPoolAfterSeconds());
    }

    private IEnumerator ReturnToPoolAfterSeconds()
    {
        yield return new WaitForSeconds(5);
        ReturnToPool();
    }


    public void ReturnToPool()
    {
        ps.Stop(true);
        ObjectPool.Instance.ReturnObject(Tag , gameObject);
    }
}
