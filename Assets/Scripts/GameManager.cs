using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public	static	GameManager		instance;
	
	// Game related
	public	float	gameWidth	= 6,
					minXScreen,
					maxXScreen;

	// Player related
	public int		lifePoints	= 100;
	public int		score		= 0;
	public int		maxScore	= 0;
	
	// Combos
//	public float	comboStopTime			= 2.0f;		// If no kill in... comboStopTime... 
//														// seconds, combo kills get restarted.
//	
//	//public bool	comboFreeze				= false;
//	public int		comboFreezeNeededKills	= 10;		// How many kills are needed to active combo
//	public float	comboFreezeDuration		= 5.0f;		// How much will combo last
//	public float	comboFreezeRate			= 0.5f;		// How much will be speed decreased
	
	// Enemy related
	public 			float	speedModifier	= 1.0f;				// Enemy speed modifier
	public const 	float	spawnSpeedMod	= 1.0f;				// Enemy spawn modifier
	
	
	
	
	public 	float 	comboTime;
	public	int 	comboCounter;

	// Executes before Start()
	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		minXScreen = -gameWidth / 2.0f;
		maxXScreen =  gameWidth / 2.0f;
		
		InvokeRepeating("CreateEnemy", 
						Random.Range(0.2f * spawnSpeedMod, 1.0f * spawnSpeedMod), 
						Random.Range(0.2f * spawnSpeedMod, 1.0f * spawnSpeedMod)
		);
		
	}
	
	void CreateEnemy(){
		Vector3 spawnPoint = new Vector3( Random.Range(minXScreen,maxXScreen), 5.0f, 0.0f );
		Instantiate(Resources.Load("Enemy"), spawnPoint, Quaternion.identity);
	}
	
}
