using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
  // Use this for initialization
  void Start()
  {

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
        Debug.Log("ro dah");
      }
      Debug.Log("fos");
      AudioSource audioSource = collision.gameObject.GetComponent<AudioSource>();
      audioSource.PlayOneShot((AudioClip)Resources.Load("audio/sfx/boulder1"), 0.7f);
      audioSource.PlayOneShot((AudioClip)Resources.Load("audio/sfx/boulder2"), 0.7f);
    }
  }
}
