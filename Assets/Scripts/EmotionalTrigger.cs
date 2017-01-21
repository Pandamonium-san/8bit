using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class EmotionalTrigger : MonoBehaviour
{
  [SerializeField]
  bool pickup;
  public PlayerCharacter.StateOfEmotion emotionType;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void OnTriggerEnter2D(Collider2D other)
  {
    PlayerCharacter pc = other.GetComponent<PlayerCharacter>();
    if (pc != null)
    {
      if (pickup)
        pc.m_Anim.SetBool("Pickup", true);
      pc.SetEmotionalState(emotionType);
    }
    Debug.Log("bump", other);
  }
}
