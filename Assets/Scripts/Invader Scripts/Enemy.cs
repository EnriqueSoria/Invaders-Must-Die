using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public Vector3 velocity;

	// Use this for initialization
	void Start () {
		// Add random speed
		velocity = new Vector3( Random.Range(0.0f, 0.5f), Random.Range(0.5f, 1.5f), 0 );
		
		// Shoot
		InvokeRepeating("Shoot", Random.Range(0.5f, 1.5f), Random.Range(0.5f, 1.5f));
	}
	
	// Update is called once per frame
	void Update () {
		float speed = GameManager.instance.speedModifier;
	
		transform.Translate(  velocity.x * Time.deltaTime * speed, 
							 -velocity.y * Time.deltaTime * speed, 
							  velocity.z * Time.deltaTime * speed
		);
		
		// Garbage collector
		if ( gameObject.transform.position.y < -GameManager.instance.gameWidth ) {
			Death();
		}
		
		// Avoid enemys go out
		Vector3 fixedPosition = transform.position;
		if ( transform.position.x >= GameManager.instance.maxXScreen || transform.position.x <= GameManager.instance.minXScreen) {
			velocity.x = -velocity.x;
		}
	}
	
	// If a bullet hits on enemy, destroy it
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "EnemyDeath") {
			Death();
			GameManager.instance.score++;
			Destroy(other.gameObject);
		}
	}
	
	void Death(){
		Instantiate(Resources.Load("explosion"), transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
	
	void Shoot(){
		Instantiate(Resources.Load("EnemyBullet"), transform.position, Quaternion.identity);
	}
}
