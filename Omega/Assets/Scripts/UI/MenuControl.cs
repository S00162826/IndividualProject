﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{

    public int index;
    public string levelNAme;

    public Image black;
    public Animator anim;

    public Text enter;

    void Start()
    {

    }

    
    void Update()
    {
        if (Input.GetKeyDown("return"))
            Destroy(enter);
    }
}
