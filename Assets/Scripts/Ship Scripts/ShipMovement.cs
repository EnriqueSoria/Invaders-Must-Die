using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	public int		direction	= 0;
	public float	speed		= 100000.0f;
	public float	sensibility	= 0.1f;
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float horizontalValue = Input.GetAxis("Horizontal");
		
		if(horizontalValue > sensibility && transform.position.x < GameManager.instance.maxXScreen - speed) {
			direction = 1;
		} else if (horizontalValue < -sensibility && transform.position.x > GameManager.instance.minXScreen + speed) {
			direction = -1;
		} else {
			direction = 0;
		}
		
		transform.position = new Vector3(
			transform.position.x + (direction * speed),
			transform.position.y,
			transform.position.z
			);
	}
}
