using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponImage : MonoBehaviour
{
    //Visual representation in UI of the gun thats been picked up
    public Image gunPickedUp;

    //Shows player how much ammo is left in the gun
    public Text ammo;

    //This is what the player interacts with i.e. "Picks Up"
    public Transform pickUp;

    //Audio variable
    private AudioSource gunPickup;

    void Start()
    {
        //Finds audio source
        gunPickup = GameObject.FindGameObjectWithTag("GunSFX").GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        //Decides what hapens when the object this script is attached to
        //collides with the "Gun" object
        if (other.gameObject.tag == "Gun")
        {
            gunPickedUp.gameObject.SetActive(true);
            ammo.gameObject.SetActive(true);
            pickUp.gameObject.SetActive(false);
            gunPickup.Play();
        }
    }

}
