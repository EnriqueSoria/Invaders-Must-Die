using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	float	speed;

	// Use this for initialization
	void Start () {
		speed = 0.3f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector3(transform.position.x,
						 transform.position.y + speed,
						 transform.position.z );
		if ( transform.position.y > GameManager.instance.gameWidth ){
			Destroy(gameObject);
		}
	}
}
