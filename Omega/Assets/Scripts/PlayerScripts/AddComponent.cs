using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddComponent : MonoBehaviour
{
    //bools to check what the player can do
    public bool canCrawl = true;
    public bool cansStand = true;
    private bool isCrawling = true;

    //A mesh renderer or in this case skinned mesh renderer
    //Is the visual of an object
    //E.g. if a cubes mesh renderer is turned off te cube is invisible
    private SkinnedMeshRenderer SkinMeshRenderer;

    //Box collider variable
    private BoxCollider boxCollider;
    

    void Start()
    {
        //Finds wanted SkinMeshRenderer
        SkinMeshRenderer = GetComponent<SkinnedMeshRenderer>();

        //Finds wanted BoxCollider
        boxCollider = GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnableCrawling")
        {
            canCrawl = true;
            cansStand = true;
        }

        //Under certain conditions the mesh render will be turned off or on
        //the box collider will also be changed to fit the purpose
        //this creates the illusion that the player is going from standing
        //to crawling or vice versa when in actuallity there is constantly a 
        //standing player and contantly a crawling player but only one can be active at a time
        if (other.gameObject.tag == "NoStandZone" && isCrawling == true)
        {
            cansStand = false;
            canCrawl = false;
            boxCollider.enabled = true;
            isCrawling = false;
            SkinMeshRenderer.enabled = true;
        }

        if (other.gameObject.tag == "StandZone" && isCrawling == false)
        {
            cansStand = true;
            canCrawl = true;
            boxCollider.enabled = false;
            isCrawling = true;
            SkinMeshRenderer.enabled = false;
        }
    }
}