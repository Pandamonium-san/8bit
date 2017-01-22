using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagull : MonoBehaviour
{
  [SerializeField]
  GameObject poop;

  Animator anim;
  Vector3 velocity;
  int bombDelay = 10;

  bool airstrike;

  // Use this for initialization
  void Start()
  {
    anim = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    transform.position += velocity * Time.deltaTime;
    anim.SetFloat("Speed", Mathf.Abs(velocity.x));
    if(airstrike && bombDelay-- <= 0)
    {
      Airstrike();
      bombDelay = 10;
    }
  }
  
  void Airstrike()
  {
    GameObject.Instantiate(poop, transform.position, new Quaternion());
  }

  public void OnTriggerEnter2D(Collider2D collision)
  {
    PlayerCharacter pc = collision.gameObject.GetComponent<PlayerCharacter>();
    if(pc != null)
    {
      pc.m_AudioSource.PlayOneShot((AudioClip)Resources.Load("Audio/sfx/seagull1"));
      StartCoroutine(ExecuteMission(pc));
    }
  }

  IEnumerator ExecuteMission(PlayerCharacter pc)
  {
    anim.SetBool("Start", true);
    yield return new WaitForSeconds(0.3f);
    airstrike = true;
    float diff = pc.transform.position.x - transform.position.x;
    if (diff > 0)
    {
      velocity = new Vector3(10, 6);
      transform.localScale = new Vector3(-1.0f, transform.localScale.y);
    }
    else
    {
      velocity = new Vector3(-10, 6);
      transform.localScale = new Vector3(1.0f, transform.localScale.y);
    }
    yield return new WaitForSeconds(1.0f);
    pc.m_AudioSource.PlayOneShot((AudioClip)Resources.Load("Audio/sfx/seagull2"));
  }
}
