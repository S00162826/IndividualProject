using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalSceneLoader : MonoBehaviour
{

    public int index;
    public string levelName;

    public Image black;
    public Animator anim;

   // public Text enter;

    void Start()
    {

    }

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
