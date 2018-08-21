using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLoseConditions : MonoBehaviour
{
    public Transform LoseCanvas;
    public Transform WinCanvas;


    public Transform MinimapCanvas;
    public Transform HealthCanvas;
    public Transform WeaponCanvas;
    public Transform ItemCanvas;

    bool gameIsOver;

    void Start()
    {
        FieldOfViewDetection.PlayerSpotted += GameOverDisplay;
        FindObjectOfType<PlayerMovement>().OnLevelComplete += LevelCompleteDisplay;
        FindObjectOfType<PlayerMovement>().LaserContact += GameOverDisplay;
        FindObjectOfType<Health>().NoHealth += GameOverDisplay;
    }

    public void GameOverDisplay()
    {
        LoseCanvas.gameObject.SetActive(true);
        gameIsOver = true;
        FieldOfViewDetection.PlayerSpotted -= GameOverDisplay;
        FindObjectOfType<PlayerMovement>().OnLevelComplete -= LevelCompleteDisplay;
        Time.timeScale = 0;
    }

    public void LevelCompleteDisplay()
    {
        WinCanvas.gameObject.SetActive(true);
        MinimapCanvas.gameObject.SetActive(false);
        HealthCanvas.gameObject.SetActive(false);
        WeaponCanvas.gameObject.SetActive(false);
        ItemCanvas.gameObject.SetActive(false);
        gameIsOver = true;
        //FieldOfViewDetection.PlayerSpotted -= GameOverDisplay;
    }
}
