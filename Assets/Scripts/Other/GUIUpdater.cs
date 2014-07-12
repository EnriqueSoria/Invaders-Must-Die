using UnityEngine;
using System.Collections;

public class GUIUpdater : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if ( this.name.Equals("GUIScore") )
			this.guiText.text = GameManager.instance.score + "";
		if ( this.name.Equals("GUIMaxScore") )
			this.guiText.text = PlayerPrefs.GetInt("Puntuacion") + "";
		if ( this.name.Equals("LifeLight") ) {
			Vector3 pos = transform.position;
			pos.z = 0.0f;
			transform.position = pos;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if ( this.name.Equals("GUIScore") )
			this.guiText.text = GameManager.instance.score + "";
		
		if ( this.name.Equals("LifeLight") ) {
			Vector3 pos 	= transform.position;
			int		life	= GameManager.instance.lifePoints;
			if ( life < 40){
				pos.z = -2.0f;
				transform.position = pos;
			} else if ( life < 70 ) {
				pos.z = -6.5f;
				transform.position = pos;
			} else {
				pos.z = 0.0f;
			}
			
		}
	}
}
