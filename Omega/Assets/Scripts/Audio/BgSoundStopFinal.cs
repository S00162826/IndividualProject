using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSoundStopFinal : MonoBehaviour
{

    //This script is applied to scenes where we want to stop the
    //audio from BgSoundFinal

    //Instance of class BgSound
    BgSoundFinalLevel Instance;

    void Start()
    {
        //Stops Audio
        BgSoundFinalLevel.Instance.gameObject.GetComponent<AudioSource>().volume = 0;
    }

}
