using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    //Variable for speed of projectile
    public float speed;

    //Audio variable
    AudioSource explosion;

    void Start()
    {
        //Access audio source
        explosion = GameObject.FindGameObjectWithTag("ExplosionSFX").GetComponent<AudioSource>();
    }

    void Update()
    {
        //Determines how the projectile moves
        //also sets it to destroy itself after 3 seconds
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, 3f);
    }

    //So the projectile doesnt go through walls have it destroy itself
    //on contact
    private void OnTriggerEnter(Collider other)
    {     
        if (other.gameObject.tag == "Wall")
        {
            DestroyProjectile();
        }

        //in this case though it destroys the final wall as well
        //as itself and plays a sound effect
        if (other.gameObject.tag == "FinalWall")
        {
            explosion.Play();
            Destroy(other.gameObject);
            DestroyProjectile();
        }
    }

    //can call this to destroy itself
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
