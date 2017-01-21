using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour, IInteractable {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  public virtual void Activate(PlayerCharacter pc)
  {
    pc.m_Anim.Play("Pickup");
  }
}
