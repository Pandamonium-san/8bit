using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rock : MonoBehaviour, IInteractable
{
  new private Rigidbody2D rigidbody;

  // Use this for initialization
  void Start()
  {
    rigidbody = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void Activate(PlayerCharacter pc)
  {

    if (pc.GetEmotionalState() == PlayerCharacter.StateOfEmotion.Angry)
    {
      if (pc.m_FacingRight)
        rigidbody.velocity = new Vector3(10, rigidbody.velocity.y, 0);
      else
        rigidbody.velocity = new Vector3(-10, rigidbody.velocity.y, 0);
      pc.m_AudioSource.PlayOneShot((AudioClip)Resources.Load("audio/sfx/boulderHitGround1"), 1.0f);
    }
  }

  public void OnCollisionEnter2D(Collision2D collision)
  {
    PlayerCharacter pc = collision.gameObject.GetComponent<PlayerCharacter>();
    if(pc!=null && pc.GetEmotionalState() == PlayerCharacter.StateOfEmotion.Angry)
    {
      float yDiff = pc.transform.position.y - transform.position.y;
      if (yDiff > 1)
        return;
      if (pc.m_FacingRight)
        rigidbody.velocity = new Vector3(10, rigidbody.velocity.y, 0);
      else
        rigidbody.velocity = new Vector3(-10, rigidbody.velocity.y, 0);
      pc.m_AudioSource.PlayOneShot((AudioClip)Resources.Load("audio/sfx/boulderHitGround1"), 1.0f);
    }
  }

}
