using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmedEnemyWalking : MonoBehaviour
{
    //Setting variables
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBetweenShots;
    public float startTimeBetweenShots;

    //Need to reference player because the player will be the target
    private Transform player;

    //To reference the animator 
    private Animator anim;

    void Start()
    {
        //Identifies the Animator component of the object 
        //the script is applied to
        anim = GetComponent<Animator>();

        //Finds the player 
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //startTimeBetweenShots is what we see in the inspector 
        //for timeBetweenShots
        timeBetweenShots = startTimeBetweenShots;
    }

    void Update()
    {
        //Sets where the object this script is applied to looks
        Vector3 point = player.position;
        point.y = 0.0f;
        transform.LookAt(point);

        //Checks distance between target and self, at an inputted 
        //distance will move toward and stop

        if (Vector3.Distance(transform.position,player.position) > stoppingDistance)
        {
            //To schange the animation
            anim.SetBool("IsWalking", true);
            transform.position = Vector3.MoveTowards(transform.position,
                                                     player.position,
                                                     speed * Time.deltaTime);
        }

        else if (Vector3.Distance(transform.position, player.position) < stoppingDistance && 
                 Vector3.Distance(transform.position, player.position) > retreatDistance)
        {
            anim.SetBool("IsWalking", false);
            transform.position = this.transform.position;
        }

        //Checks distance between target,
        //will retreat if target is too close

        else if (Vector3.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                                                     player.position,
                                                     -speed * Time.deltaTime);
            anim.SetBool("IsWalking", true);
        }
    }
}

