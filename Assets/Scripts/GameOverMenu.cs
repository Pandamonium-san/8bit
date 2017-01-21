﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RestartGameFunction()
    {
        SceneManager.LoadScene("UIStartMenu");
    }

    public void LeaveGameFunction()
    {
        Application.Quit();
    }
}
