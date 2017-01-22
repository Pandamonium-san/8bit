using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Angry : MonoBehaviour
{
  [SerializeField]
  PlayerCharacter pc;

  public Image angry;
  public Image scarred;

  // Use this for initialization
  void Start()
  {
    pc = FindObjectOfType<PlayerCharacter>();
    angry.enabled = true;
    scarred.enabled = true;
    scarred.color = Color.white * 0;
    angry.color = Color.white * 0;
  }

  // Update is called once per frame
  void Update()
  {
    if (pc.GetEmotionalState() == PlayerCharacter.StateOfEmotion.Angry)
    {
      angry.color = Color.white * (1.0f - (pc.Health / 100) * 0.5f);
      scarred.color = Color.white * 0;
    }
    else if (pc.GetEmotionalState() == PlayerCharacter.StateOfEmotion.Scared)
    {
      scarred.color = Color.white * (0.75f - (pc.Health / 100) * 0.5f);
      angry.color = Color.white * 0;
    }
    else
    {
      angry.color = Color.white * 0;
      scarred.color = Color.white * 0;
    }
  }
}
