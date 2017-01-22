using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
  SpriteRenderer sr;

  // Use this for initialization
  void Start()
  {
    sr = GetComponent<SpriteRenderer>();
  }

  // Update is called once per frame
  void Update()
  {
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    PlayerCharacter pc = collision.gameObject.GetComponent<PlayerCharacter>();
    if (pc != null)
    {
      if (pc.GetEmotionalState() == PlayerCharacter.StateOfEmotion.Angry)
      {
        Destroy(gameObject);
      }
      pc.m_AudioSource.PlayOneShot((AudioClip)Resources.Load("audio/sfx/boulder1"), 0.7f);
      pc.m_AudioSource.PlayOneShot((AudioClip)Resources.Load("audio/sfx/boulder2"), 0.7f);
    }
  }
}
