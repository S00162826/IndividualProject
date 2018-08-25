using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSoundStop : MonoBehaviour
{
    //This script is applied to scenes where we want to stop the
    //audio from BgSound

    //Instance of class BgSound
    BgSound Instance;

    void Start()
    {
        //Stops Audio
        BgSound.Instance.gameObject.GetComponent<AudioSource>().Stop();
    }

}
