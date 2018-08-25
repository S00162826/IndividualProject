using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmedEnemy : MonoBehaviour
{
    //Setting variables
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBetweenShots;
    public float startTimeBetweenShots;

    //Can set whatever object we want to be our projectile
    //in inspector e.g. bullet prefab
    public GameObject projectile;

    //Need to reference player because the player will be the target
    private Transform player;

    //Variable for sthe sound effect that will be played
    AudioSource bulletSound;

    void Start()
    {
        //Finds the player 
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //startTimeBetweenShots is what we see in the inspector 
        //for timeBetweenShots
        timeBetweenShots = startTimeBetweenShots;

        //Finds the audio source
        bulletSound = GameObject.FindGameObjectWithTag("ShootingSFX").GetComponent<AudioSource>();
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
            transform.position = Vector3.MoveTowards(transform.position,
                                                     player.position,
                                                     speed * Time.deltaTime);
        }

        else if (Vector3.Distance(transform.position, player.position) < stoppingDistance && 
                 Vector3.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }

        //Checks distance between target,
        //will retreat if target is too close
        else if (Vector3.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                                                     player.position,
                                                     -speed * Time.deltaTime);
        }
       
        //Setting projectile to be created / shot
        //when the time reaches 0
        //Also play sound effect at this time
        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile,transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
            bulletSound.Play();

        }
        else
        {
            //-= Tme.deltaTime because time between shots is like a counter
            timeBetweenShots -= Time.deltaTime;
        }
    }
}

