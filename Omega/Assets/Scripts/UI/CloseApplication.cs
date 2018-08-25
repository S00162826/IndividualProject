using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CloseApplication : MonoBehaviour
{
    public void ExitGameButton()
    {
        Application.Quit();
    }
}