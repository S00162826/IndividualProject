using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSoundFinalLevel : MonoBehaviour {

    //Setting the audio as an instance to be referenced in another script to stop
    //the audio in another scene if desired
    private static BgSoundFinalLevel instance = null;
    public static BgSoundFinalLevel Instance { get { return instance; } }

    private void Awake()
    {
        //Stops the audio being destroyed on a new scene i.e. 
        //audio continues to play even after the next scene has loaded
        if (instance != null && instance != this )
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
