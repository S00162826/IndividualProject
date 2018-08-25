using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour
{
    //So the lasers react to the player trigger
    
    //For disabling the players movement
    private bool disabled;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Uses PlayerSpotted for gameover and disable player
            FieldOfViewDetection.PlayerSpotted += Disable;
        }
    }

    private void Disable()
    {
        disabled = true;
    }

}
