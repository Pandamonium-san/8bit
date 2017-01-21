using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : Pickupable
{

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public override void Activate(PlayerCharacter pc)
  {
    base.Activate(pc);
    pc.SetEmotionalState(PlayerCharacter.StateOfEmotion.Happy);
  }
}
