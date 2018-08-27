using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLoseConditions : MonoBehaviour
{
    //Canvas' I want to access
    private Canvas LoseCanvas;
    public Transform WinCanvas;


    public Transform MinimapCanvas;
    public Transform HealthCanvas;
    public Transform WeaponCanvas;
    public Transform ItemCanvas;
    public Canvas PauseCanvas;

    //So I can determine what happens when the game is over
    bool gameIsOver = false;

    void Awake()
    {
        //Assigns actions in other classes to use the methods in this class
        FieldOfViewDetection.PlayerSpotted += GameOverDisplay;
        FindObjectOfType<PlayerMovement>().OnLevelComplete += LevelCompleteDisplay;
        FindObjectOfType<PlayerMovement>().LaserContact += GameOverDisplay;
        FindObjectOfType<Health>().NoHealth += GameOverDisplay;
        LoseCanvas = GameObject.FindGameObjectWithTag("GameOver").GetComponent<Canvas>();
        LoseCanvas.enabled = false;

    }

    //What I want to happen when game is over
    public void GameOverDisplay()
    {
        LoseCanvas.enabled = true;
        gameIsOver = true;
        FieldOfViewDetection.PlayerSpotted -= GameOverDisplay;
        FindObjectOfType<PlayerMovement>().OnLevelComplete -= LevelCompleteDisplay;
        Time.timeScale = 0.1f;
        GameObject.Find("GameController").GetComponent<Pause>().enabled = false;
    }

    //What I want to happen when the player completes a level
    public void LevelCompleteDisplay()
    {
        WinCanvas.gameObject.SetActive(true);
        MinimapCanvas.gameObject.SetActive(false);
        HealthCanvas.gameObject.SetActive(false);
        WeaponCanvas.gameObject.SetActive(false);
        LoseCanvas.gameObject.SetActive(false);
        ItemCanvas.gameObject.SetActive(false);
        gameIsOver = true;
        GameObject.Find("GameController").GetComponent<Pause>().enabled = false;
    }
}
