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
      GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip, 1);
    }
  }
}
