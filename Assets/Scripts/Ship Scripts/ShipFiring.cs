using UnityEngine;
using System.Collections;

public class ShipFiring : MonoBehaviour {

	public	float	fireRate		= 0.05f;
	public	float	comboFireRate	=  1.0f;
	public	float	crazyFireRate	=  4.0f;
	public	float	madFireRate		= 10.0f;
	
	float	lastShoot,
			lastComboShoot,
			lastCrazyShoot,
			lastMadShoot;

	// Use this for initialization
	void Start () {
		lastShoot 		= 0.0f;
		lastComboShoot 	= Time.time;
		lastCrazyShoot	= Time.time;
		lastMadShoot	= Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	
		// FIRE 1
		float timeSinceLastShoot = Time.time - lastShoot;
		if(Input.GetButtonDown("Fire1") && timeSinceLastShoot >= fireRate) {
			Shoot();
			lastShoot = Time.time;
			return;
		}
		
		// FIRE 2
		float timeSinceLastCombo = Time.time - lastComboShoot;
		if(Input.GetButtonDown("Fire2") && timeSinceLastCombo >= comboFireRate) {
			ShootCombo();
			lastComboShoot = Time.time;
			return;
		}
		
		// FIRE 3
		float timeSinceLastCrazy = Time.time - lastCrazyShoot;
		if(Input.GetButtonDown("Fire3") && timeSinceLastCrazy >= crazyFireRate) {
			ShootCrazy();
			lastCrazyShoot = Time.time;
			return;
		}
		
		// FIRE 4
		float timeSinceLastMad = Time.time - lastMadShoot;
		if(Input.GetButtonDown("Fire4") && timeSinceLastMad >= madFireRate) {
			StartCoroutine("ShootMad");
			lastMadShoot = Time.time;
			return;
		}
		
	}
	
	void Shoot(){
		Instantiate(Resources.Load("Bullet"), transform.position, Quaternion.identity );
	}
	
	void ShootCombo(){
		ShootMany(3);
	}
	
	void ShootCrazy(){
		ShootMany(10);
	}
	
	void ShootMany( int n ){
		bool esPar = (n % 2 == 0);
	
		int firstIndex 	= -(int) n / 2;
		int lastIndex	= -firstIndex;
		
		if ( !esPar ) lastIndex++;
		
		for (int i = firstIndex; i < lastIndex; i++){
			float offset = 0.5f * i;
			Vector3 vec =  new Vector3(transform.position.x + offset , transform.position.y, transform.position.z);
			Instantiate(Resources.Load("Bullet"), vec, Quaternion.identity );
		}
	}
	
	IEnumerator ShootMad(){
		float minScreen = GameManager.instance.minXScreen;
		float maxScreen = GameManager.instance.maxXScreen;
		float step		= (maxScreen - minScreen) / 15.0f;
		
		for (float i = minScreen; i < maxScreen; i += step){
				Vector3 vec =  new Vector3( i , transform.position.y, transform.position.z);
				Instantiate(Resources.Load("Bullet"), vec, Quaternion.identity );
				yield return new WaitForSeconds(0.05f);
		}
	}
}
