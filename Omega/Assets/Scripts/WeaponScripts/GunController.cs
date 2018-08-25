using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    //so we can decide what happens when gun is firing
    public bool isFiring;

    //Bullet is of type bulletcontroller
    public BulletController bullet;

    //creating variables for use
    public float bulletSpeed;
    public float timeBetweenShots;
    private float shotCounter;

    //This will be where the bullet / projectile
    //will come from
    public Transform firePoint;

    //Need to be able to access ammo because if
    //no ammo, wont be able to shoot
    public float ammo;

    //for the player to see how much ammo they have
    public Text ammoRemaining;

    void Update()
    {
        //what happens when te gun is firings
        if (isFiring)
        {
            //shot counter and time between shots so all bullets dont come out at once
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;

                //Instantiates i.e. creates the new bullet at fire point
                BulletController newBullet = Instantiate(bullet,
                    firePoint.position, firePoint.rotation) as BulletController;

                //sets the speed of the bullet
                newBullet.speed = bulletSpeed;

                //remove bullet from ammo after each shot
                ammo = ammo - 1;

            }
        }
        else
        {
            shotCounter = 0;
        }

        ammoRemaining.text = ammo.ToString();

        if (ammo < 4)
        {
            ammoRemaining.color = Color.red;
        }
        else
            ammoRemaining.color = Color.white;

        //Prevents player from shooting when out of ammo
        //isFiring always false if theres no ammo in the gun
        if (ammo == 0)
        {
            isFiring = false;
            ammoRemaining.text = "No Ammo";
        }
    }
}
