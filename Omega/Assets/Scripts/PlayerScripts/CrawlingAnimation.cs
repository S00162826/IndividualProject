using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlingAnimation : MonoBehaviour
{
    //Animator variable
    public Animator animator;

    void Start()
    {
        //Finds desired animator variable
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Changes bool to true for animations when certain buttons are held
        if (Input.GetKey("w") ||
                Input.GetKey("a") ||
                Input.GetKey("s") ||
                Input.GetKey("d") ||
                Input.GetKey("up") ||
                Input.GetKey("down") ||
                Input.GetKey("left") ||
                Input.GetKey("right"))
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
