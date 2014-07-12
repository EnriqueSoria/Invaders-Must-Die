using UnityEngine;
using System.Collections;

public class ShipDeath : MonoBehaviour {

	public int	lifePoints;

	// Use this for initialization
	void Start () {
		lifePoints = GameManager.instance.lifePoints;
	}
	
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "EnemyBullet") {
			ReceiveDamage(34);
		}
	}
	
	void ReceiveDamage(int damage){
		lifePoints -= damage;
		GameManager.instance.lifePoints = lifePoints;
		//Instantiate(Resources.Load("small flames"), transform.position, Quaternion.identity);
		
		
		if(lifePoints <= 0){
			Death();
		}
	}
	
	void Death(){
		int points = GameManager.instance.score;
		
		if (!PlayerPrefs.HasKey("Puntuacion") || PlayerPrefs.GetInt("Puntuacion") < points) {
			PlayerPrefs.SetInt("Puntuacion", GameManager.instance.score);
		}
		Application.LoadLevel(0);
		Destroy(gameObject);
	}
}
