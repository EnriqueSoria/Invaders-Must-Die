using UnityEngine;
using System.Collections;

public class WelcomeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Start")){
			Application.LoadLevel(Application.loadedLevel+1);
		}
	}
}
