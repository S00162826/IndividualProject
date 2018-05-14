using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void NewGameBtn(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }
}