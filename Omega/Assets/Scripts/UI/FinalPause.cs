using UnityEngine;

public class FinalPause : MonoBehaviour
{
    //This is so the win lose condition script know when to
    //activate certain methods
    public static event System.Action GameIsPaused;
    public static event System.Action GameIsUnPaused;

    //Want to access canvas
    public Transform canvas;
   
    bool disabled;

    public void Update()
    {
        //Uses Pause method when Escape is pressed
        if (GameIsPaused != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Paused();
            }
        }
    }

    //What I want to happen when the game is paused
    //Freeze time
    //Hide other canvas'
    //stop audio
    public void Paused()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            
            Time.timeScale = 0;
            AudioListener.volume = 0;
            GameIsPaused();
        }
        else
        {
            canvas.gameObject.SetActive(false);
            
            Time.timeScale = 1;
            AudioListener.volume = 1;
            GameIsUnPaused();
        }
    }

    private void Disable()
    {
        disabled = true;
    }

}