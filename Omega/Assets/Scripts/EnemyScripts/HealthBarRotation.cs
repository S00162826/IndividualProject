using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarRotation : MonoBehaviour {

    //This is to lock the enemy healthbars rotation
    //doesnt look great if the ealthbar rotates with the enemy
    //and can be harder to see if it goes sideways

    Quaternion rotation;

    //Essentially just sets its starting rotation to always be its rotaion

    void Awake()
    {
        rotation = transform.rotation;
    }
    void LateUpdate()
    {
        transform.rotation = rotation;
    }
}
