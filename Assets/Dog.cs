using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
  Animator anim;
  // Use this for initialization
  void Start()
  {
    anim = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
  }

  public void OnTriggerEnter2D(Collider2D collision)
  {
    PlayerCharacter pc = collision.GetComponent<PlayerCharacter>();
    if (pc != null)
    {
      anim.SetBool("Start", true);
      StartCoroutine(Bark(pc));
    }
  }

  IEnumerator Bark(PlayerCharacter pc)
  {
    pc.m_AudioSource.PlayOneShot((AudioClip)Resources.Load("Audio/sfx/bark1"));
    yield return new WaitForSeconds(0.2f);
    pc.m_AudioSource.PlayOneShot((AudioClip)Resources.Load("Audio/sfx/bark2"));
    yield return new WaitForSeconds(0.3f);
    pc.m_AudioSource.PlayOneShot((AudioClip)Resources.Load("Audio/sfx/bark2"));
    yield return new WaitForSeconds(1f);
    anim.SetBool("Start", false);
  }
}
