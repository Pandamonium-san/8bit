using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimation : MonoBehaviour
{
  AudioSource m_AudioSource;
  float time;
  Animator anim;
  float timeToDissapear;
  // Use this for initialization
  void Start()
  {
    time = 3.0f;
    anim = this.GetComponent<Animator>();
    timeToDissapear = 5f;

    m_AudioSource = gameObject.AddComponent<AudioSource>();
    m_AudioSource.spatialBlend = 0;
    StartCoroutine(Sounds());
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
      //this.gameObject.SetActive(false);
      GetComponent<SpriteRenderer>().enabled = false;
    }

  }

  IEnumerator Sounds()
  {
    m_AudioSource.PlayOneShot((AudioClip)Resources.Load("Audio/sfx/shorewaves1"));
    yield return new WaitForSeconds(6.0f);
    m_AudioSource.PlayOneShot((AudioClip)Resources.Load("Audio/sfx/splash1"));
    yield return new WaitForSeconds(1.5f);
    m_AudioSource.PlayOneShot((AudioClip)Resources.Load("Audio/sfx/unplug1"));
  }

  public void Disappear()
  {

  }
}
