using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    //will input inspector to chose level
    public int index;
    public string levelName;

    //Animation variables
    public Image black;
    public Animator anim;

    //UI text that will display
    public Text enter;

    //Audio variable
    AudioSource enterSound;

    void Start()
    {
        //finds audio source
        enterSound = GameObject.FindGameObjectWithTag("EnterSFX").GetComponent<AudioSource>();
    }

    //What will happen when enter is pressed
    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            enterSound.Play();

            StartCoroutine(Fading());

            Destroy(enter);
        }
    }

    IEnumerator Fading()
    {
        anim.SetBool("fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(index);
    }
}
