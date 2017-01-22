using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingIslandScript : MonoBehaviour {

    
    float time;
    Animator anim;
	// Use this for initialization
	void Start () {
       
        time = 5.0f;
        anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time < 0 && !anim.GetBool("fly"))
        {
            anim.SetBool("fly", true);
        }
        if (time < -1)
        {
            this.transform.Translate(Vector2.up * 0.01f, Space.World);

        }
	}
}
