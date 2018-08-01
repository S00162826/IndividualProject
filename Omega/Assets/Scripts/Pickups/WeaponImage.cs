using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponImage : MonoBehaviour {

    public Image gunPickedUp;
    public Text ammo;
    public Transform pickUp;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gun")
        {
            gunPickedUp.gameObject.SetActive(true);
            ammo.gameObject.SetActive(true);
            pickUp.gameObject.SetActive(false);
        }
    }

}
