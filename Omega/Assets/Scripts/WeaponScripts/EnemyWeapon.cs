using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    //Variable for speed of projectile
    public float speed;

    //Want to find the player but also can be good to set 
    //target point on player
    private Transform player;
    private Vector3 target;

     void Start()
    {
        //Finds the playe to access
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //Determines target position
        target = new Vector3(player.position.x, player.position.y,player.position.z);
    }

    void Update()
    {
        //the projectile will move toward the target position
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //will destroy itself when it reaches target position
        if (transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z)
        {
            DestroyProjectile();
        }
    }

    //What to do when enters trigger areas
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }

        //stops from shooting through walls
        if (other.gameObject.tag == "Wall")
        {
            DestroyProjectile();
        }
    }

    //can call this to destroy itself
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
