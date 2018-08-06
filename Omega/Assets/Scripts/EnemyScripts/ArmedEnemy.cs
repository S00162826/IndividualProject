using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmedEnemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBetweenShots;
    public float startTimeBetweenShots;

    public GameObject projectile;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBetweenShots = startTimeBetweenShots;
    }

    void Update()
    {
        Vector3 point = player.position;
        point.y = 0.0f;
        transform.LookAt(/*player.position*/point);

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
        else if (Vector3.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                                                     player.position,
                                                     -speed * Time.deltaTime);
        }

        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile,transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
}

