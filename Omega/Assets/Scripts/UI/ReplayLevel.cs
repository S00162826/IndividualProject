using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReplayLevel : MonoBehaviour
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

    //Need to access canvas because was destroying itself on load 
    private Canvas LoseCanvas;

    void Start()
    {
        //finds audio source
        buttonSound = GameObject.FindGameObjectWithTag("ButtonSFX").GetComponent<AudioSource>();

        //finds canvas
        LoseCanvas = GameObject.FindGameObjectWithTag("GameOver").GetComponent<Canvas>();
    }

    //Method to choose in inspector on button
    public void NewGameBtn()
    {
        buttonSound.Play();
        Time.timeScale = 1;
        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        anim.SetBool("fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        KeepGameOverCanvas();
        SceneManager.LoadScene(index);       
    }

    void KeepGameOverCanvas()
    {
        LoseCanvas.transform.SetParent(null, false);
        DontDestroyOnLoad(LoseCanvas);
        LoseCanvas.gameObject.SetActive(false);
    }
}