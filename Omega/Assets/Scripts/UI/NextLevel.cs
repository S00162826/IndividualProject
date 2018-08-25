using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    //will input inspector to chose level
    //for button
    public int index;
    public string levelName;

    //Animation variables
    public Image black;
    public Animator anim;

    //audio variable
    AudioSource buttonSound;

    void Start()
    {
        //finds audio source
        buttonSound = GameObject.FindGameObjectWithTag("ButtonSFX").GetComponent<AudioSource>();
    }

    //Method to choose in inspector on button
    public void NewGameBtn()
    {
        buttonSound.Play();
        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        anim.SetBool("fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(index);
    }
}