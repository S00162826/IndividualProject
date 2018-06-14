using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public Transform FinishCanvas;

    //Creates a new GameObject called player
    GameObject player;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Links player to the GameObject with the tag "Player"
        player = GameObject.Find("Player");
    }

    void Update()
    {

        

    }

    void OnTriggerEnter(Collider other)
    {
        //How the player reacts when it collides with other objects

        #region End of level collision
        if (other.gameObject.CompareTag("Finish"))
        {
            FinishCanvas.gameObject.SetActive(true);
        }
        #endregion
    }

}
