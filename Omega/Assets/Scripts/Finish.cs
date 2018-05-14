using UnityEngine;

public class Finish : MonoBehaviour
{
    public Transform canvas;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Finish")
        {
            Finished();
        }
    }

    public void Finished()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            AudioListener.volume = 0;
        }
        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            AudioListener.volume = 1;
        }
    }
}