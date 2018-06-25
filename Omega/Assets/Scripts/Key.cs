using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public bool doesPlayerHaveKey;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            doesPlayerHaveKey = true;
            Destroy(other.gameObject);
        }

        
    }

        void OnCollisionEnter(Collision col)
        {
        if (col.gameObject.tag == "Door" && doesPlayerHaveKey == true)
        {
            
            Destroy(col.gameObject);
        }
    }

    void Start()
    {

    }

    void Update()
    {
       
    }
}
