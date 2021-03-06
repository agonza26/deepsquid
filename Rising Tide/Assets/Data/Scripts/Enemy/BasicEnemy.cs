﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicEnemy : MonoBehaviour {
	public string fishType = "dankFish";
	public float damage = 1f;
	public bool timedFollow = false;
	public float followTimer = 10f;
	public float evadeTimer = 5f;
	public float returnTimer = 5f;

	public float steerMult = 1f;
	public float followStraight = 5f;

	public float chaseSteer = 2f;
	public float chaseStraight = 10f;
	public bool debug = true;
	public string ecosystem = "Eco-Test-1";
	public bool haveMultiEcos = false;
	public string[] muliEcos = new string[1];
	private string[] ecosystemDataBase;

	public float empTimeLimit = 3f;
	public float steeringMax = 1f; //maximum steering magnitude
	public float velocityMax = 9f; //maximum velocity magnitude



	private float timerforWaveAbility = 0f;

	private float timeLImitforWave = 5f;



	public bool overrideDebugValue = false;

	//not something you should change in the instector
	public string message = "none"; // used to tell the fish outside effects that aren't contained in this logic, ie sight or other compnents
	public GameObject thing; //eventually make it a child of an object
	private bool waveAcc = false; //to know when we have accelerated from aen outside wave, controlled only with waves
	public Vector3 outsideFactor = Vector3.zero; //current outsideFactor from waves, 




	private string state = "idle";
	private string prevState = "idle"; //used for emp;
	private bool inkDaze = false;
	private bool released = false;
	private bool fleeingAway = false;
	private bool switchedStates = false;

	private float outsideDec = 0f;
	private float fleeLifeTime = 0f;
	private float doubleBackTime = 0f;

	private float velocityRangeMin = 2f;//5f;
	private float velocityRangeMax = 5f;//10f;
	private float steeringRangeMin = 0.5f;
	private float steeringRangeMax = 4f;
	private Vector3 lastFactor = Vector3.zero; //stores the last iteration of the facter after we exit the currents

	private GameObject eco;
	private Rigidbody rigBod; //reference to the rigid body
	private Transform currentTarget = null; //where the enemy is currently trying to go towards
	private LastPlayerSighting lPC; //used to get last player's sighting and reset valuable
	public float randomPathFloat = 0.01f;

	private List<string> effects = new List<string>();
	private List<string> statesList = new List<string> ();
	private Vector3 toTarget = Vector3.zero;
	private Vector3 desired_velocity = Vector3.zero;
	private Vector3 steering = Vector3.zero;

	public ParticleSystem blood;
	public AudioSource death;
	public AudioSource foundPlayerSound;
	public float empDazeTimer = 5f;
	private float empTimer = 0f;
	public float empDamage = 200f;

	//private bool leftEco = false;
	//private float empTimer = 0;
	//private float straightRangeMin = 0f;
	//private float straightRangeMax = 0f;
	//private string lastState = "idle";



	public bool isHostile = true;



	public void changeAcc(bool t){
		waveAcc = t;

	}


	void Start () {
		debug = overrideDebugValue;
		setDiffStats();

		eco = GameObject.Find (ecosystem);
		lPC = GameObject.FindGameObjectWithTag ("gameController").GetComponent<LastPlayerSighting> ();
		//look towards target on start
		//transform.LookAt(currentTarget);//start off looking at the first point
		rigBod = GetComponent<Rigidbody>();//init rigitbody
		eco.GetComponent<EcoPoints>().Add(gameObject);
		if (debug) {
			state = "debug";


		}
		blood.Emit(25);



	}


	public bool modifyState(string s){
		if (statesList.Contains(s)) {
			state = s;
			return true;
		} else {

			return false;
		}

	}


	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "EMP") {
			effects.Add ("emp");
			GameObject.FindGameObjectWithTag ("borkVisualCollider").GetComponent<TutorialObject> ().abilityUsageCheck ("emp");

		} else if (c.gameObject.tag == "EcoPoint") {

			if (c.gameObject.transform == currentTarget) {
				changePlaces ();
			}


		}

	}



	void OnCollisionEnter(Collision c){
		
		GameObject other = c.gameObject;
	
		if (other.tag == "Player") {
			Player_stats p = other.GetComponent<Player_stats> ();
			if (state == "follow") {
				p.playerDamage (damage);
				flee ();
				//be.stunMult = 1f;

			}
		}
	}



	void OnParticleCollision(GameObject other){
		if( !effects.Contains(other.name)){
			if (other.name == "ink" || other.name == "Ink") {
				effects.Add("ink");
				GameObject.FindGameObjectWithTag ("borkVisualCollider").GetComponent<TutorialObject> ().abilityUsageCheck ("ink");
			} else if (other.name == "emp" || other.name == "EMPps") {
				effects.Add("emp");
			}
		}
	}




	void Update () {
		blood.transform.position = transform.position;
		//used to call commands, does not control switching from a state to another
		switch (state) { //acts depending on state
			case "follow": //sees player, currently following
				follow ();
				break;

			case "empDaze":
				empDaze ();
				break;


			case "grabbed": //being grabbed by the player
				grabbed ();
				break;
			case "runAway":
				runAway ();
				break;
			case "debug":
				debugState ();
				break;
			case "idle": //default idle/patrolling phase
			default:
				idle ();
				break;
		}
		waveHandler (); //always move with the wave independant of the state
	}




	void debugState(){
		//does nothing, strickly for debugging, can modify for printing later or something
	}


	void setDiffStats(){
		switch (gameObject.GetComponent<BasicEnemy> ().fishType) {
		case "barracuda":
			damage = 15;
			followTimer = 10;
			evadeTimer = 4;
			returnTimer = 7;
			steerMult = 13;
			followStraight = 10;
			chaseSteer = 2;
			chaseStraight = 10;
			steeringMax = 9.4f;
			velocityMax = 35;





			break;
		case "tuna":
			damage = 8;
			followTimer = 10;
			evadeTimer = 5;
			returnTimer = 5;
			steerMult = 2;
			followStraight = 5;
			chaseSteer = 2;
			chaseStraight = 8;
			steeringMax = 2;
			velocityMax = 14;


			//enemyHealthMax = 25;
			//PlayerHealthRestoreValue = 10;
			break;


		case "swordfish":

			damage = 20;
			followTimer = 20;
			evadeTimer = 10;
			returnTimer = 10;
			steerMult = 8;
			followStraight = 15;
			chaseSteer = 1;
			chaseStraight = 8;
			steeringMax = 10;
			velocityMax = 75;

		//	enemyHealthMax = 75;
			//PlayerHealthRestoreValue = 40;
			break;


		case "angler":
			damage = 20;
			followTimer = 20;
			evadeTimer = 10;
			returnTimer = 10;
			steerMult = 8;
			followStraight = 15;
			chaseSteer = 1;
			chaseStraight = 8;
			steeringMax = 3;
			velocityMax = 20;


		//	/enemyHealthMax = 45;
			//PlayerHealthRestoreValue = 18;
			break;


		case "whale":
			damage = 60;
			followTimer = 10;
			evadeTimer = 15;
			returnTimer = 20;
			steerMult = 1;
			followStraight = 2;
			chaseSteer = 2;
			chaseStraight = 5;
			steeringMax = 2;
			velocityMax = 2;
			//enemyHealthMax = 200;
			//PlayerHealthRestoreValue = 9000;
			break;


		case "manta":
			isHostile = false;
			damage = 8;
			followTimer = 10;
			evadeTimer = 5;
			returnTimer = 5;
			steerMult = 1;
			followStraight = 5;
			chaseSteer = 2;
			chaseStraight = 8;
			steeringMax = 2;
			velocityMax = 9;

			//enemyHealthMax = 65;
			//PlayerHealthRestoreValue= 15;

		

			//enemyHealthMax = 35;
			//PlayerHealthRestoreValue= 13;
			break;
		case "shark":
			damage = 35;
			followTimer = 10;
			evadeTimer = 5;
			returnTimer = 5;
			steerMult = 4;
			followStraight = 5;
			chaseSteer = 20;
			chaseStraight = 20;
			steeringMax = 10;
			velocityMax = 45;
			//enemyHealthMax = 100;
			//PlayerHealthRestoreValue = 60;
			break;

		case "flounder":
		default:
			isHostile = false;
			damage = 5;
			followTimer = 10;
			evadeTimer = 15;
			returnTimer = 20;
			steerMult = 1;
			followStraight = 2;
			chaseSteer = 2;
			chaseStraight = 5;
			steeringMax = 5;
			velocityMax = 4;

			break;
		}

		empTimeLimit = 3;
		empDazeTimer = 3;
		empDamage = 35;

	}



	private void changePlaces(){
		GameObject[] keyList = new List<GameObject> (eco.GetComponent<EcoPoints> ().Ecopoints.Values).ToArray ();
		currentTarget = keyList [(int)Random.Range (0, (float)keyList.Length-1)].transform;
	}


	void idle(){
		if (effects.Contains ("emp")) {
			empPrep ();
		}

		if (message != "none" && !switchedStates) {
			if(!effects.Contains("ink")){
				switch (message) {
				
				case "foundPlayer":
					currentTarget = lPC.positionTransform;

					message = "none";
					if (foundPlayerSound)
						foundPlayerSound.Play ();

					if (isHostile) {
						state = "follow";
						follow ();

					} else {
						flee ();

					}


					switchedStates = true;
					break;
				}
			}
		}
			
		if (!switchedStates) {
			//if you get hit by ink
			if (effects.Contains ("ink")) {
				effects.Remove ("ink"); //remove it from effects
				inkDaze = true; //show that you've been hit by ink
			} else {
				//no longer being effected and should turn off
				inkDaze = false;
			}


			//assume haven't seen player

			if (Random.value < 0.9f) {
				if (!inkDaze) {
					if (!eco.GetComponent<EcoPoints> ().Enemies.ContainsKey (name)) {
						//if i left the area start turning around
						currentTarget = eco.transform;
					} else {

						if (currentTarget == eco.transform) {



						}


						if (currentTarget == null || Random.value < randomPathFloat) {
							changePlaces ();
						}
					}
					toTarget = Vector3.Normalize (currentTarget.position - transform.position);
					desired_velocity = toTarget * velocityMax;
					steering = desired_velocity - rigBod.velocity;
					steering = Vector3.ClampMagnitude (steering, steeringMax * steerMult);
					rigBod.velocity = Vector3.ClampMagnitude (rigBod.velocity + steering, velocityMax) + transform.forward * followStraight;
				}
				thing.transform.position = transform.position + rigBod.velocity;
				transform.LookAt (thing.transform);
			}
		} else {
			switchedStates = false;
		}
	}




	//tune ink ability a bit
	private void follow(){
		//print ("found player tho");
		if (effects.Contains ("emp")) {
			empPrep ();

		}else if (!effects.Contains ("ink")) {
			
			if (fleeingAway) {
				state = "runAway";
				currentTarget = lPC.positionTransform;
				runAway ();
				switchedStates = true;
				fleeingAway = false;


			} else {
				switch (message) {
					case "lostPlayer":
						state = "idle";
						message = "none";
						follow ();
						switchedStates = true;
						break;
				}
				if (!switchedStates) {


					velocityMax = velocityRangeMax;//Random.Range (velocityRangeMin, velocityRangeMax);
					steeringMax = Random.Range (steeringRangeMin, steeringRangeMax);


					toTarget = Vector3.Normalize (currentTarget.position - transform.position);
					desired_velocity = toTarget * velocityMax * 5f;
					steering = desired_velocity - rigBod.velocity;
					steering = Vector3.ClampMagnitude (steering, steeringMax * steerMult);

					float distVar = Vector3.Distance (currentTarget.position, transform.position);
					//5,20
					rigBod.velocity = Vector3.ClampMagnitude (rigBod.velocity + steering, velocityMax * Mathf.Min (distVar / 5 + 1, chaseSteer)) + transform.forward * Mathf.Min (8 * 32 / (distVar), chaseStraight);

					thing.transform.position = transform.position + rigBod.velocity;
					transform.LookAt (thing.transform);
				}
			}


		} else {
			effects.Remove ("ink");
		}

		switchedStates = false;

	}





	//method to be called not a state
	public void flee(){
		fleeingAway = true;
		state = "runAway";

		lPC.positionTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		lPC.position = GameObject.FindGameObjectWithTag ("Player").transform.position;
		currentTarget = lPC.positionTransform;
		fleeLifeTime = 0f;
		doubleBackTime = 0f;
		runAway ();
	}




	private void empPrep(){
		
		GetComponent<EnemyHealth> ().enemyTakeDmg (empDamage);
		prevState = state;
		state = "empDaze";
		effects.Remove ("emp");
		empDaze ();
		switchedStates = true;

	}


	//actual flee state
	private void runAway(){
		if (effects.Contains ("emp")) {
			empPrep ();
		}


		if (!switchedStates) {
		
			if (!effects.Contains ("ink")) {
				fleeLifeTime += Time.deltaTime;
				float counter = 1f;
				if (fleeLifeTime > evadeTimer) {

					counter = -1f;
					doubleBackTime += Time.deltaTime;

				}


				if (doubleBackTime > evadeTimer+returnTimer) {
					if (message == "foundPlayer") {
						message = "none";
						if (isHostile) {
							state = "follow";
							follow ();
						} else {
							flee ();

						}
					} else {

						state = "idle";
						idle ();
					}
					fleeLifeTime = 0f;
					doubleBackTime = 0f;

				}




				velocityMax = Random.Range (velocityRangeMin, velocityRangeMax);
				steeringMax = Random.Range (steeringRangeMin, steeringRangeMax);


				toTarget = Vector3.Normalize (currentTarget.position+(new Vector3(1,1,1)) - transform.position);
				desired_velocity = toTarget * velocityMax * 5f;
				steering = desired_velocity - rigBod.velocity;
				steering = Vector3.ClampMagnitude (steering, steeringMax*steerMult);


				float distVar = Vector3.Distance (currentTarget.position+(new Vector3(1,1,1)), transform.position);

			
				rigBod.velocity = Vector3.ClampMagnitude (rigBod.velocity + steering * (-1 * counter), velocityMax * Mathf.Min (distVar / 5 + 5, chaseSteer*2)) + transform.forward * Mathf.Min (8 * 32 / (distVar), chaseStraight*2);



				thing.transform.position = transform.position + rigBod.velocity;
				transform.LookAt (thing.transform);

			} else {
				effects.Remove ("ink");
			}

		} else {

			switchedStates = false;
		}


	}






	public void release(){
		released = true;
	}



	//returns true if escaped
	//false if still being held
	public bool struggle(){
		if (state != "grabbed")
			return true;

		float theNum = Random.Range (0.00F, 1.00F);


		return(theNum < 30);

	}



	//state for when we are grabbed
	private void grabbed(){
		if (released) {
			released = false;
			flee ();
		}
	}



	//state for when we have been shocked
	private void empDaze(){
		empTimer += Time.deltaTime;
		if (empTimer >= empDazeTimer) {
			state = prevState;
			prevState = "idle";
		}
	}








	//not in place

	//do the wiggle dance
	public void wiggle(){
		//add fruits to the salad

		float circleDist = rigBod.velocity.magnitude / 3;
		Vector3 circleCenter = rigBod.velocity.normalized * circleDist;


		var randomPoint = Random.insideUnitCircle;
		var CircleRadius = circleCenter.magnitude/3;
		var displacement = new Vector3(randomPoint.x, randomPoint.y) * CircleRadius;
		displacement = Quaternion.LookRotation(rigBod.velocity) * displacement;

		rigBod.velocity += (circleCenter + displacement);
		//yummy yummy
	}



	public string getState(){

		return state;
	}





	public void kiil(){
		if( GameObject.Find("Player").GetComponent<PickupObject>().getTarget() == fishType) {
			GameObject.Find("Player").GetComponent<PickupObject> ().incrementTarget ();
		}
		if (death) {
			death.Play ();
		}
		if (blood) {
			blood.transform.position = transform.position;
			blood.Emit (25);
		}
	}




	public void biith(){
		GetComponent<EnemyHealth> ().resetHealth ();
		GetComponent<EnemyHealth>().prevMod = 0;
		effects.Clear ();
		if (debug) {
			state = "debug";
		} else {
			state = "idle";
		}
	}












	Vector3 minVectorMag(Vector3 item, float mag){
		if (item.magnitude < mag) {
			return item.normalized * mag;

		} else {

			return item;
		}
	}




	// where mu is the center of the bell curve, and sigma is proportional to its "width"
	float calcEuler(float x,float mu, float sigma){
		return Mathf.Exp(-   Mathf.Pow((x-mu), 2f)/(2f*Mathf.Pow(sigma,2f)))/Mathf.Sqrt(2f*Mathf.PI*   Mathf.Pow(sigma,2f));
	}




	//methods that modify/control external movement from waves
	private void waveHandler(){

		if (outsideFactor.magnitude != 0) {
			timerforWaveAbility += Time.deltaTime;

			if (timerforWaveAbility >= 3f) {
				outsideFactor = Vector3.zero;
				waveAcc = false;
				timerforWaveAbility = 0;
			}
		}
		rigBod.velocity += outsideFactor;




		if (waveAcc) {
			waveAccHandler ();
		}

	}

	public void changeDec(){
		lastFactor = outsideFactor;
		outsideDec = outsideFactor.magnitude / 20;
		GameObject.FindGameObjectWithTag ("borkVisualCollider").GetComponent<TutorialObject> ().abilityUsageCheck ("current");
	}



	private void waveAccHandler(){
		if (outsideFactor.magnitude > 0) {
			outsideFactor -= lastFactor * outsideDec;
			if (outsideFactor.magnitude < 0.01f) {
				outsideFactor = Vector3.zero;
				waveAcc = false;
			}


		}else if (outsideFactor.magnitude < 0) {
			outsideFactor += lastFactor * outsideDec;
			if (outsideFactor.magnitude > -0.01f) {
				outsideFactor = Vector3.zero;
				waveAcc = false;
			}
		}
	}
		





}
