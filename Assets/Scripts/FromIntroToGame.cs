using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FromIntroToGame : MonoBehaviour {

    float time;
	// Use this for initialization
	void Start () {
        time = 12.0f;
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time < 0)
        {
            ChangeScene();
        }
	}

    public void ChangeScene()
    {
        SceneManager.LoadScene("level1");
    }
}
