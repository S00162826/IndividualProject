using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    public int index;
    public string levelName;

    public Image black;
    public Animator anim;


    public void NewGameBtn()
    {
        
        
        //if (Time.timeScale == 0)
        //{

        //    Time.timeScale = 1;
            StartCoroutine(Fading());
        //}
        //SceneManager.LoadScene(newGameLevel);
    }

    public void Restart()
    {
        
        StartCoroutine(Fading());
        //SceneManager.LoadScene(level);
        //if (Time.timeScale == 0)
        //{
        //    Time.timeScale = 1;
        //}

    }



    public void ExitGameBtn()
    {
        Application.Quit();
    }

   IEnumerator Fading()
    {
        anim.SetBool("fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(index);
    }
}