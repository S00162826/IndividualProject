using UnityEngine;

public class Pause : MonoBehaviour
{
    public static event System.Action GameIsPaused;
    public Transform canvas;
    public Transform HealthCanvas;
    public Transform MiniMapCanvas;
    public Transform weaponCanvas;
    public Transform itemCanvas;

    bool disabled;

    public void Update()
    {
        if  (GameIsPaused != null) { 
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Paused();
                GameIsPaused();
            }
        }
        //else (GameIsPaused != null);



    }

    public void Paused()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            HealthCanvas.gameObject.SetActive(false);
            MiniMapCanvas.gameObject.SetActive(false);
            itemCanvas.gameObject.SetActive(false);
            weaponCanvas.gameObject.SetActive(false);
            Time.timeScale = 0;
            AudioListener.volume = 0;
            GameIsPaused();
        }
        else
        {
            canvas.gameObject.SetActive(false);
            HealthCanvas.gameObject.SetActive(true);
            MiniMapCanvas.gameObject.SetActive(true);
            itemCanvas.gameObject.SetActive(true);
            weaponCanvas.gameObject.SetActive(true);
            Time.timeScale = 1;
            AudioListener.volume = 1;
            GameIsPaused = null;
        }
    }

    private void Disable()
    {
        disabled = true;
    }

}