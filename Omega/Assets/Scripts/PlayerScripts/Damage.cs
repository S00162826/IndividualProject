using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    //Variables for if something is doing damage and how much
    //Its must also be noted that damage can be used in reverse to add health
    public bool isDamaging;
    public float damage;
   
    //Takes / Heals damage over time its colliding with player
    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
            col.SendMessage((isDamaging) ? "TakeDamage" : "HealDamage", Time.deltaTime * damage,SendMessageOptions.RequireReceiver);
    }
}
