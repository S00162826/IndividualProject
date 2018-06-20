using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour {

    public bool isFiring;

    public BulletController bullet;
    public float bulletSpeed;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;

    public float ammo;

    public Text ammoRemaining;

	void Start ()
    {
		
	}
	
	void Update ()
    {

            if (isFiring)
            {
                shotCounter -= Time.deltaTime;
                if (shotCounter <= 0)
                {
                    shotCounter = timeBetweenShots;

                    BulletController newBullet = Instantiate(bullet,
                        firePoint.position, firePoint.rotation) as BulletController;

                    newBullet.speed = bulletSpeed;

                    ammo = ammo - 1;
                    //if (ammo <= 0)
                    //{
                    //    ammo = 0;
                    //    return;
                    //}
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

        if (ammo == 0)
        {
            ammoRemaining.text = "No Ammo";
        }


    }
}
