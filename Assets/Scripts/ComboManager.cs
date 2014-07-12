using UnityEngine;
using System.Collections;

public class ComboManager : MonoBehaviour {

	public ShipFiring fireSettings;


	// Timers
	float	timeStartComboTimer;
	int		killsCounter;
	
	float	maxTimeBetweenKills = 1.0f;

	// Freeze combo
	int		Freeze_killsTo 	= 15;
	float	Freeze_Rate		= 0.7f;		// 30% slower
	bool	Freeze_Enabled	= false;
	
	float	Freeze_Timer;
	float 	Freeze_Duration	= 5.0f;
	
	// Health
	int 	killsToHealth	= 25;
	
	// Infinite mana
	int		InfiniteMana_killsTo 	= 40;
	bool	InfiniteMana_Enabled	= false;
	
	float	InfiniteMana_Timer;
	float	InfiniteMana_Duration	= 5.0f;
	

	// Use this for initialization
	void Start () {
		Reset();
	}
	
	// Update is called once per frame
	void Update () {
		float 	timeElapsed = Time.time - timeStartComboTimer;
		int		killsEarned = GameManager.instance.score - killsCounter;
		
		if ( timeElapsed < maxTimeBetweenKills ){
			if ( killsEarned > 0 ) {
				killsCounter += killsEarned;
				ResetTime();
				
				if ( killsCounter >= Freeze_killsTo && !Freeze_Enabled) {
					GameManager.instance.speedModifier = Freeze_Rate;
					Freeze_Timer = Time.time;
				}
				
				if ( killsCounter >= killsToHealth){
					GameManager.instance.lifePoints = 100;
				}
				
				if ( killsCounter >= InfiniteMana_killsTo ){
					fireSettings.crazyFireRate = 0.5f;
					InfiniteMana_Timer = Time.time;
					Reset();
				}
			}
		} else {
			Reset();
		}
		
		// Resetting
		Freeze_Reset();
		InfiniteMana_Reset();
	}
	
	void Reset(){
		ResetTime();
		ResetCounter();
	}
	
	void ResetTime(){
		timeStartComboTimer = Time.time;
	}
	
	void ResetCounter(){
		killsCounter = 0;
	}
	
	void Freeze_Reset(){
		if ( Freeze_Enabled && Time.time - Freeze_Timer >= Freeze_Duration ) {
			Freeze_Enabled 	= false;
			Freeze_Timer	= 0.0f;
			GameManager.instance.speedModifier = 1.0f;
		}
	}
	
	void InfiniteMana_Reset(){
		if ( InfiniteMana_Enabled && Time.time - InfiniteMana_Timer >= InfiniteMana_Duration ) {
			InfiniteMana_Enabled 		= false;
			InfiniteMana_Timer			= 0.0f;
			fireSettings.crazyFireRate 	= 4.0f;
		}
	}
	
}
