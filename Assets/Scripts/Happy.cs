using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Happy : MonoBehaviour {

    public Image scarred;
    public Image angry;

    // Use this for initialization
    void Start()
    {
        scarred = scarred.GetComponent<Image>();
        angry = angry.GetComponent<Image>();
        angry.enabled = false;
        scarred.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            scarred.enabled = false;
            angry.enabled = false;
        }
    }
}
