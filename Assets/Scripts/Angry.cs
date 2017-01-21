using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Angry : MonoBehaviour {

    public Image angry;
    public Image scarred;

	// Use this for initialization
	void Start () {
        angry = angry.GetComponent<Image>();
        scarred = scarred.GetComponent<Image>();
        angry.enabled = false;
        scarred.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {        

        if (collision.gameObject.tag == "Player")
        {
            angry.enabled = true;
            scarred.enabled = false;
        }
    }
}
