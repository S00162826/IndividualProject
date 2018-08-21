using UnityEngine;

public class FinalPause : MonoBehaviour
{
    public static event System.Action GameIsPaused;
    public static event System.Action GameIsUnPaused;
    public Transform canvas;
   
    bool disabled;

    public void Update()
    {
        if (GameIsPaused != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Paused();
               // GameIsPaused();
            }
        }
        //else 
        //    if (Input.GetKeyDown(KeyCode.Escape))
        //    {
        //        //Paused();
        //        GameIsUnPaused();
        //    }
        
        
       
        


    }

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