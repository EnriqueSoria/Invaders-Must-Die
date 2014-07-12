using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

	public int damage = 34;
	
	float	speed;
	
	// Use this for initialization
	void Start () {
		speed = 0.3f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float speedModifier = GameManager.instance.speedModifier;
		
		transform.position = new Vector3(transform.position.x,
		                                 transform.position.y - speed * speedModifier,
		                                 transform.position.z );
		if ( transform.position.y < -GameManager.instance.gameWidth ){
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "EnemyDeath") {
			Destroy(this.gameObject);
			Destroy(other.gameObject);
		}
	}
}
