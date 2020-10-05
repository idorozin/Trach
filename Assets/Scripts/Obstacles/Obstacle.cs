using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Obstacle : MonoBehaviour,IPooledObject
{
    public string Tag { get; set; }

    [SerializeField]
    public float forwardSpeed;

    [SerializeField]
    private Rigidbody rb;

    public bool contact = false ;
    private Score score;



    void Update()
    {
        if(ObjectPool.Instance.playerpos.position.z -50 > transform.position.z)
            ReturnToPool();
    }

    void FixedUpdate()
    {
        if (contact)
        {
            rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y,forwardSpeed);       
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, forwardSpeed);
        }
    }
    
    void Start()
    {
        score =  GameObject.Find("Score").GetComponent<Score>();
    }
    
    public void Destroy()
    {
        ReturnToPool();
        score.OnCarDestroyed();
        GameObject explosion = ObjectPool.Instance.GetObject("explosion");
        explosion.transform.position = transform.position;
    }

    void ReturnToPool()
    {
        contact = false;
        gameObject.SetActive(false);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        ObjectPool.Instance.ReturnObject(Tag,gameObject);

    }

}
