using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitToMainMenu : MonoBehaviour
{

    public int index;
    public string levelName;

    public Image black;
    public Animator anim;


    public void NewGameBtn()
    {
        
        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        Time.timeScale = 1;
        anim.SetBool("fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(index);
    }
}