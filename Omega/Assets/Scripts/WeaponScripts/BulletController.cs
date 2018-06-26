using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed;

    void Start()
    {

    }

    //void OnTriggerEnter(Collider col)
    //{
    //    if (col.gameObject.tag == "Wall")
    //    {
    //        Destroy(gameObject);
           
    //    }

    //}

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, 3f);
    }
}
