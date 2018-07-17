using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{

    public int index;
    public string levelName;

    public Image black;
    public Animator anim;

    public Text enter;

    void Start()
    {

    }

    
    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
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
