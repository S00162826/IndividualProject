using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Transform canvas;
    public Button replay;
    bool gameIsOver;

    void Start()
    {
        FieldOfViewDetection.PlayerSpotted += GameOverDisplay;
    }

    void Update()
    {
        //if(gameIsOver)
            
    }

    public void GameOverDisplay()
    {
        canvas.gameObject.SetActive(true);
        gameIsOver = true;
        FieldOfViewDetection.PlayerSpotted -= GameOverDisplay;

    }
}
