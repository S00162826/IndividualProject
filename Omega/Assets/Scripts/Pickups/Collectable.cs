using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    //Creating variables
    public float totalCollectables;
    public float collectablesFound;
    public Text collectables;

    //For sound effect
    AudioSource collectable;

    void Start()
    {
        //FInds sound effect
        collectable = GameObject.FindGameObjectWithTag("CollectableSFX").GetComponent<AudioSource>();
    }

    //If the collectable collides with player play sound effect,
    //increase collectables found by 1
    //Set active to false to make it disappear

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable" && gameObject.tag == "CollectableCollider")
        {
            collectable.Play();
            collectablesFound += 1;
            other.gameObject.SetActive(false);
        }
           
    }
        void Update()
    {
        collectables.text = "Collectables Found : " + collectablesFound.ToString()
                            + "/" + totalCollectables.ToString();
    }
}
