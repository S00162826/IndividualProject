using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private BoxCollider boxCollider;
    private bool isCrawling = false;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (Input.GetKeyDown("c") && isCrawling == false)
        {
            isCrawling = true;
            boxCollider.size = new Vector3(1.0f, .3f, 2.92f);
            boxCollider.center = new Vector3(0f, -.34f, 0f);
        }
        else if (Input.GetKeyDown("c") && isCrawling == true)
        {
            boxCollider.size = new Vector3(1.0f, 1.0f, 1.0f);
            boxCollider.center = new Vector3(0f, 0f, 0f);
            isCrawling = false;
        }
    }
}
