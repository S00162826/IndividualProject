using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSoundStopFinal : MonoBehaviour
{

    //This script is applied to scenes where we want to stop the
    //audio from BgSound

    //Instance of class BgSound
    BgSoundFinalLevel Instance;

    void Start()
    {
        //Stops Audio
        BgSoundFinalLevel.Instance.gameObject.GetComponent<AudioSource>().Stop();
    }

}
