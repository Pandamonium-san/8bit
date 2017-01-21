using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public GameObject startButton;
    public GameObject leaveGameButton;
    // Use this for initialization
    void Start()
    {
        startButton = GameObject.Find("ButtonStart");
        leaveGameButton = GameObject.Find("ButtonLeave");
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void StartGameFunction()
    {
        //if (Input.GetKeyDown(KeyCode.F1))
        //{
            SceneManager.LoadScene("level1");       

        //}

    }

    public void LeaveGameFunction()
    {        
        Application.Quit();              
    }

}
