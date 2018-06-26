using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{

    public bool doesPlayerHaveKey;

    public Text keyPickedUp;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            doesPlayerHaveKey = true;
            Destroy(other.gameObject);
            keyPickedUp.text = "Key Collected";
            Destroy(keyPickedUp, 3f);        
        }     
    }

        void OnCollisionEnter(Collision col)
        {
        if (col.gameObject.tag == "Door" && doesPlayerHaveKey == true)
        {
           Destroy(col.gameObject);
        }
    }
}
