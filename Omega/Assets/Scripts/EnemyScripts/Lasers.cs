using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour
{
    private bool disabled;

     void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FieldOfViewDetection.PlayerSpotted += Disable;
        }
    }

    private void Disable()
    {
        disabled = true;
    }

}
