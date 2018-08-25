using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    //Bools to check what players keys the player has collected
    public bool doesPlayerHaveKey;
    public bool doesPlayerHaveLvl2Key;
    public bool doesPlayerHaveLvl3Key;
    public bool doesPlayerHaveLvl4Key;

    //Visual representation of keys that the player has collected
    public Image keyPickedUp;
    public Image lvl2KeyPickedUp;
    public Image lvl3KeyPickedUp;
    public Image lvl4KeyPickedUp;

    //Sound effect variables
    AudioSource doorOpen;
    AudioSource keyPickup;

    void Start()
    {
        //Finds dound effects
        doorOpen = GameObject.FindGameObjectWithTag("DoorSFX").GetComponent<AudioSource>();
        keyPickup = GameObject.FindGameObjectWithTag("KeySFX").GetComponent<AudioSource>();
    }

    //When the player picks up the key sets bool of certain key to true
    //This is so when a player has certain keys they can unlock certain doors
    //The keys disappear and a sound effect plays
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            doesPlayerHaveKey = true;
            Destroy(other.gameObject);
            keyPickedUp.gameObject.SetActive(true);   
            keyPickup.Play();

        }

        if (other.gameObject.tag == "KeyLvl2")
        {
            keyPickup.Play();
            doesPlayerHaveLvl2Key = true;
            Destroy(other.gameObject);
            lvl2KeyPickedUp.gameObject.SetActive(true);
        }

        if (other.gameObject.tag == "KeyLvl3")
        {
            keyPickup.Play();
            doesPlayerHaveLvl3Key = true;
            Destroy(other.gameObject);
            lvl3KeyPickedUp.gameObject.SetActive(true);
        }

        if (other.gameObject.tag == "KeyLvl4")
        {
            keyPickup.Play();
            doesPlayerHaveLvl4Key = true;
            Destroy(other.gameObject);
            lvl4KeyPickedUp.gameObject.SetActive(true);
        }
    }

    //if the player has the right key they can "open" the door
    //bools check if they have the right key
    //it destroys the door if the have the right key
    //sound effect plays also

        void OnCollisionEnter(Collision col)
        {
        if (col.gameObject.tag == "Door" && doesPlayerHaveKey == true)
        {
           doorOpen.Play();
           Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "DoorLvl2" && doesPlayerHaveLvl2Key == true)
        {
            doorOpen.Play();
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "DoorLvl3" && doesPlayerHaveLvl3Key == true)
        {
            doorOpen.Play();
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "DoorLvl4" && doesPlayerHaveLvl4Key == true)
        {
            doorOpen.Play();
            Destroy(col.gameObject);
        }
    }
}
