using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
  [RequireComponent(typeof(PlayerCharacter))]
  public class PlayerController : MonoBehaviour
  {
    private PlayerCharacter m_Character;
    private bool m_Jump;
    private bool m_Interact;
    
    private void Awake()
    {
      m_Character = GetComponent<PlayerCharacter>();
    }

    private void Update()
    {
      if (!m_Jump)
      {
        // Read the jump input in Update so button presses aren't missed.
        m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
      }
      if(!m_Interact)
      {
        m_Interact = CrossPlatformInputManager.GetButtonDown("Fire1");
      }
    }

    private void FixedUpdate()
    {
      // Read the inputs.
      float h = CrossPlatformInputManager.GetAxis("Horizontal");
      // Pass all parameters to the character control script.
      m_Character.Move(h, m_Jump);
      m_Character.Interact(m_Interact);
      m_Jump = false;
      m_Interact = false;
    }
  }
}
