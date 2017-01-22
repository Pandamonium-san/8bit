using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birdpoop : MonoBehaviour {

  [SerializeField]
  float lifeTime;
	// Use this for initialization
	void Start () {
    GetComponent<Rigidbody2D>().gravityScale = transform.position.y > 0 ? 1 : -1;
  }

  // Update is called once per frame
  void Update () {
    lifeTime -= Time.deltaTime;
    if (lifeTime <= 0)
      Destroy(this.gameObject);
	}
}
