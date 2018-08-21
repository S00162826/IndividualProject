using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddComponent : MonoBehaviour
{

    public bool canCrawl = true;
    public bool cansStand = true;
    private SkinnedMeshRenderer SkinMeshRenderer;
    private BoxCollider boxCollider;
    private bool isCrawling = true;

    void Start()
    {
        SkinMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnableCrawling")
        {
            canCrawl = true;
            cansStand = true;
        }


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

        private void Standing()
    {

        //if (canCrawl == true)
        //{
        //    if (Input.GetKeyUp("c") && isCrawling == true)
        //    {
        //        boxCollider.enabled = true;
        //        isCrawling = false;
        //        SkinMeshRenderer.enabled = true;
        //    }
        //    else if (Input.GetKeyUp("c") && isCrawling == false)
        //    {
        //        boxCollider.enabled = false;
        //        isCrawling = true;
        //        SkinMeshRenderer.enabled = false;
        //    }
        //}
    }


        // Update is called once per frame
        void Update()
        {
        if(cansStand == true)
        Standing();
        }
    }