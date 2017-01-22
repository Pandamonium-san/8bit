using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimation : MonoBehaviour
{
    float time;
    Animator anim;
    float timeToDissapear;
    // Use this for initialization
    void Start()
    {
        time = 3.0f;
        anim = this.GetComponent<Animator>();
        timeToDissapear = 5f;
       
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0 && !anim.GetBool("move"))
        {
            anim.SetBool("move", true);
            Debug.Log("StartCatAnim");
            
        }
        if (time < -2)
        {
            this.gameObject.SetActive(false);
        }
        
    }

    public void Disappear()
    {
       
    }
}
