using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour {

    public GameObject resetButton;
	// Use this for initialization
	void Start () {
        resetButton = GameObject.Find("ButtonReset");
	}
	
	// Update is called once per frame
	void Update () {
        ResetScene();
	}

    public void ResetScene()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("pressR");
        }
    }
}
