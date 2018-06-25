using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLoseConditions : MonoBehaviour
{
    public Transform LoseCanvas;
    public Transform WinCanvas;

    bool gameIsOver;

    void Start()
    {
        FieldOfViewDetection.PlayerSpotted += GameOverDisplay;
        FindObjectOfType<PlayerMovement>().OnLevelComplete += LevelCompleteDisplay;
    }

    public void GameOverDisplay()
    {
        LoseCanvas.gameObject.SetActive(true);
        gameIsOver = true;
        FieldOfViewDetection.PlayerSpotted -= GameOverDisplay;
        FindObjectOfType<PlayerMovement>().OnLevelComplete -= LevelCompleteDisplay;

    }

    public void LevelCompleteDisplay()
    {
        WinCanvas.gameObject.SetActive(true);
        gameIsOver = true;
        FieldOfViewDetection.PlayerSpotted -= GameOverDisplay;
    }
}
