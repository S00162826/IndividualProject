using UnityEngine;

public class Pause : MonoBehaviour
{
    public Transform canvas;
    public Transform HealthCanvas;
    public Transform MiniMapCanvas;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)/* || Input.GetKeyDown("PS4_Options")*/)
        {
            Paused();
        }
    }

    public void Paused()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            HealthCanvas.gameObject.SetActive(false);
            MiniMapCanvas.gameObject.SetActive(false);
            Time.timeScale = 0;
            AudioListener.volume = 0;
        }
        else
        {
            canvas.gameObject.SetActive(false);
            HealthCanvas.gameObject.SetActive(true);
            MiniMapCanvas.gameObject.SetActive(true);
            Time.timeScale = 1;
            AudioListener.volume = 1;
        }


    }
}