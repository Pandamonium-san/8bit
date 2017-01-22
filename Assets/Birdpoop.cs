using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birdpoop : MonoBehaviour
{

  [SerializeField]
  float lifeTime = 2;
  // Use this for initialization
  void Start()
  {
    if (transform.position.y > 0)
    {
      GetComponent<Rigidbody2D>().gravityScale = 1;
      transform.localScale = new Vector3(transform.localScale.x, 1);
    }
    else
    {
      GetComponent<Rigidbody2D>().gravityScale = -1;
      transform.localScale = new Vector3(transform.localScale.x, -1);
    }
  }

  // Update is called once per frame
  void Update()
  {
    lifeTime -= Time.deltaTime;
    if (lifeTime <= 0)
      Destroy(this.gameObject);
  }
}
