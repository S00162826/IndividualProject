using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveComponent : MonoBehaviour
{

    public bool canCrawl;
    public bool cansStand;
    private SkinnedMeshRenderer SkinMeshRenderer;
    private BoxCollider boxCollider;
    private bool isCrawling = false;

    // Use this for initialization
    void Start()
    {
        SkinMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Standing()
    {

        //if (cansStand == true)
        //{
        //    if (Input.GetKeyUp("c") && isCrawling == false)
        //    {
        //        boxCollider.enabled = false;
        //        isCrawling = true;
        //        SkinMeshRenderer.enabled = false;
        //    }
        //    else if (Input.GetKeyUp("c") && isCrawling == true)
        //    {
        //        boxCollider.enabled = true;
        //        isCrawling = false;
        //        SkinMeshRenderer.enabled = true;
        //    }
        //}
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnableCrawling")
        {
            cansStand = true;
            canCrawl = true;
        }

        if (other.gameObject.tag == "NoStandZone" && isCrawling == false)
        {
            cansStand = false;
            canCrawl = false;
            boxCollider.enabled = false;
            isCrawling = true;
            SkinMeshRenderer.enabled = false;
        }

        if (other.gameObject.tag == "StandZone" && isCrawling == true)
        {
            cansStand = true;
            canCrawl = true;
            boxCollider.enabled = true;
            isCrawling = false;
            SkinMeshRenderer.enabled = true;
        }
    }

        // Update is called once per frame
        void Update()
        {
        if(cansStand == true)
        Standing();
        }
    }