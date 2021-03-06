using System;
using UnityEngine;
using UnityEngine.UI;
using ColorCorrectionCurves = UnityStandardAssets.ImageEffects.ColorCorrectionCurves;

namespace UnityStandardAssets._2D
{
    public class PlayerCharacter : MonoBehaviour
    {
        
        [SerializeField]
        private float m_DefaultMaxSpeed = 5f;
        [SerializeField]
        private float m_MaxSpeed = 5f;                    // The fastest the player can travel in the x axis.
        [SerializeField]
        private float m_DefaultJumpForce = 200f;
        [SerializeField]
        private float m_JumpForce = 200f;                  // Amount of force added when the player jumps.
        [SerializeField]
        private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField]
        private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool m_Grounded;            // Whether or not the player is grounded.
        private Transform m_CeilingCheck;   // A position marking where to check for ceilings
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator m_Anim;            // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.
        private bool m_UpsideDown = false;
        public float Health = 100f;
        

        public enum StateOfEmotion
        {
            Happy,
            Scared,
            Angry
        }


        private StateOfEmotion emotionalState;

        public void Start()
        {
          
        }


        private void Awake()
        {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();

            m_JumpForce = m_DefaultJumpForce;
            m_MaxSpeed = m_DefaultMaxSpeed;
            
           
        }


        private void FixedUpdate()
        {
            m_Grounded = false;

            if (!m_UpsideDown)
            {
                // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
                // This can be done using layers instead but Sample Assets will not overwrite your project settings.
                Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                        m_Grounded = true;
                }
            }
            else
            {
                // Do the same for ceilings
                Collider2D[] colliders = Physics2D.OverlapCircleAll(m_CeilingCheck.position, k_GroundedRadius, m_WhatIsGround);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                        m_Grounded = true;
                }
            }
            m_Anim.SetBool("Ground", m_Grounded);

            // Set the vertical animation
            m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);

            // Gravity change
            if (transform.position.y < 0.0f)
            {
                transform.localScale = new Vector3(transform.localScale.x, -1);
                m_Rigidbody2D.gravityScale = -1f;
                m_UpsideDown = true;
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x, 1);
                m_Rigidbody2D.gravityScale = 1f;
                m_UpsideDown = false;
            }

            switch (emotionalState)
            {
                case StateOfEmotion.Happy:
                    break;
                case StateOfEmotion.Scared:
                    TakeDamage(0.1f);
                    break;
                case StateOfEmotion.Angry:
                    TakeDamage(0.1f);
                    break;
                default:
                    break;
            }
        }

        public void TakeDamage(float damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                // die4
                Debug.Log("oh no u dead");
            }
        }

        public void SetEmotionalState(StateOfEmotion emotion)
        {
            emotionalState = emotion;
            m_JumpForce = m_DefaultJumpForce;
            m_MaxSpeed = m_DefaultMaxSpeed;
            switch (emotion)
            {
                case StateOfEmotion.Happy:
                    // be happy
                    break;
                case StateOfEmotion.Scared:
                    // be scared
                    m_JumpForce = m_DefaultJumpForce * 1.5f;
                    m_MaxSpeed = m_DefaultMaxSpeed * 1.5f;
                    break;
                case StateOfEmotion.Angry:
                    // ponch ur fokin f8ce m8
                    
                    break;
                default:
                    break;
            }
            UpdateColorOnCamera();
        }

        private void UpdateColorOnCamera()
        {
            ColorCorrectionCurves ColorCorect = Camera.main.GetComponent<ColorCorrectionCurves>();

            switch (emotionalState)
            {
                case StateOfEmotion.Happy:
                    // be happy
                    ColorCorect.blueChannel = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));
                    ColorCorect.depthBlueChannel = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1f, 1f));
                    break;
                case StateOfEmotion.Scared:
                    // be scared
                    ColorCorect.blueChannel = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 0.25f));
                    ColorCorect.depthBlueChannel = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1f, 0.25f));
                    break;
                case StateOfEmotion.Angry:
                    // ponch ur fokin f8ce m8
                    ColorCorect.blueChannel = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 0.1f));
                    ColorCorect.depthBlueChannel = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1f, 0.1f));
                    break;
                default:
                    break;
            }
            ColorCorect.UpdateParameters();
        }

        public void Move(float move, bool jump)
        {
            //only control the player if grounded or airControl is turned on
            if (m_Grounded || m_AirControl)
            {
                // The Speed animator parameter is set to the absolute value of the horizontal input.
                m_Anim.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
                m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }
            // If the player should jump...
            if (m_Grounded && jump && m_Anim.GetBool("Ground"))
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                m_Anim.SetBool("Ground", false);
                m_Rigidbody2D.AddForce(new Vector2(0f, m_Rigidbody2D.gravityScale * m_JumpForce));
            }
        }


        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
