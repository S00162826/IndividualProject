using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSoundRestart : MonoBehaviour
{
    //Instance of class BgSound
    BgSound Instance;

    void Start()
    {
        //Audio
        BgSound.Instance.gameObject.GetComponent<AudioSource>().volume=1;
    }

}
