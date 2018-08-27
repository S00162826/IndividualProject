using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSoundFinalRestart : MonoBehaviour
{
    //Instance of class BgSoundFinalLevel
    BgSoundFinalLevel Instance;

    void Start()
    {
        //Audio
        BgSoundFinalLevel.Instance.gameObject.GetComponent<AudioSource>().volume=1;
    }

}
