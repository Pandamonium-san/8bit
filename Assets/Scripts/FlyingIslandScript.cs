using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingIslandScript : MonoBehaviour {

    public GameObject island;
    float time;
	// Use this for initialization
	void Start () {
        island = GameObject.Find("FlyingIsland");
        time = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time < 0)
        {
            island.transform.Translate(Vector2.up * Time.deltaTime, Space.World);
        }
	}


}
