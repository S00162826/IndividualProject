using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalSceneLoader : MonoBehaviour
{
    //will input inspector to chose level
    public int index;
    public string levelName;

    //Animation variables
    public Image black;
    public Animator anim;

    //the scene can only be accessed when the player interacts with
    //"TheEnd" in the final level
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TheEnd")
        {
            StartCoroutine(Fading());
        }
    }
    
    IEnumerator Fading()
    {
        anim.SetBool("fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(index);
    }
}
