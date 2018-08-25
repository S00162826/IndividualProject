using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
    //This just rotates an object
    //Is used for things such as collectables
    //In this case its only used on the gun collectables

    void Update()
    {
        //Only rotates along y axis becaus x and z are set to 0
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
    }
}