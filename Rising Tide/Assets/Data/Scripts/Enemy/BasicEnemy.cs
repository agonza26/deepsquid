using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicEnemy : MonoBehaviour {
	public float steerMult = 1f;
	public float followStraight = 5f;
	public float chaseSteer = 2f;
	public float	chaseStraight = 10f;
	public bool debug = true;
	public string ecosystem = "Eco-Test-1";
	public float damage = 3f;
	public float empLimit = 5f;
	public float steeringMax = 1f; //maximum steering magnitude
	public float velocityMax = 9f; //maximum velocity magnitude
	public string message = "none"; // used to tell the fish outside effects that aren't contained in this logic, ie sight or other compnents
									// might modify to a list

	public GameObject thing; //eventually make it a child of an object
	public bool waveAcc = true; //to know when we have accelerated from aen outside wave, controlled only with waves
	public Vector3 outsideFactor = Vector3.zero; //current outsideFactor from waves, 


	private string state = "idle";
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


	private List<string> effects = new List<string>();
	private List<string> statesList = new List<string> ();

	private int ecoID = -1;

	//private bool leftEco = false;
	//private float empTimer = 0;
	//private float straightRangeMin = 0f;
	//private float straightRangeMax = 0f;
	//private string lastState = "idle";

	void Start () {
		print ("i are starting");
		eco = GameObject.Find (ecosystem);
		lPC = GameObject.FindGameObjectWithTag ("gameController").GetComponent<LastPlayerSighting> ();
		//look towards target on start
		//transform.LookAt(currentTarget);//start off looking at the first point
		rigBod = GetComponent<Rigidbody>();//init rigitbody
		ecoID = eco.GetComponent<EcoPoints>().addEnem(gameObject);

	}


	public bool modifyState(string s){
		if (statesList.Contains(s)) {
			state = s;
			return true;
		} else {

			return false;
		}

	}






	void OnCollisionEnter(Collision c){
		
		GameObject other = c.gameObject;
	
		if (other.tag == "Player") {
			Player_stats p = other.GetComponent<Player_stats> ();
			if (state == "follow") {

				p.playerDamage (1f);
				flee ();
				print ("attacking");
				//be.stunMult = 1f;

			}
		}
	}



	void OnParticleCollision(GameObject other){
		if( !effects.Contains(other.name)){
			if (other.name == "ink" || other.name == "Ink") {
				effects.Add("ink");
			} else if (other.name == "emp" || other.name == "EMP") {
				effects.Add("emp");
			}
		}
	}



	void Update () {
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

			case "idle": //default idle/patrolling phase
			default:
				idle ();
				break;
		}
		waveHandler (); //always move with the wave independant of the state
	}






	//idle doessn't handle emp yet
	void idle(){
		if (effects.Contains ("emp")) {
			//lastState = state;
			state = "empDaze";
			effects.Remove ("emp");
			empDaze ();
			switchedStates = true;
		}



		if (message != "none" && !switchedStates) {
			if(!effects.Contains("ink")){
				switch (message) {
				
				case "foundPlayer":
					currentTarget = lPC.positionTransform;
					state = "follow";
					message = "none";
					follow ();
					switchedStates = true;
					break;
				}
			}
		}
			
		if (!switchedStates) {
			if (effects.Contains ("ink")) {
				effects.Remove ("ink");
				inkDaze = true;
			} else {
				if (inkDaze) {
					inkDaze = false;
				}
			}
			//assume haven't seen player
			if (!inkDaze) {
				if (Random.value < 0.9f) {
					if (!eco.GetComponent<EcoPoints> ().Enemies.ContainsKey (name)) {
						//if i left the area start turning around
						currentTarget = eco.transform;
					} else {
						if (currentTarget == null || Random.value < 0.01f) {
							GameObject[] keyList = new List<GameObject> (eco.GetComponent<EcoPoints> ().Ecopoints.Values).ToArray ();
							currentTarget = keyList [(int)Random.Range (0, (float)keyList.Length)].transform;
						}
					}
					velocityMax = Random.Range (velocityRangeMin, velocityRangeMax);
					steeringMax = Random.Range (steeringRangeMin, steeringRangeMax);

					Vector3 toTarget = Vector3.Normalize (currentTarget.position - transform.position);
					Vector3 desired_velocity = toTarget * velocityMax;
					Vector3 steering = desired_velocity - rigBod.velocity;

					steering = Vector3.ClampMagnitude (steering, steeringMax*steerMult);
					rigBod.velocity = Vector3.ClampMagnitude (rigBod.velocity + steering, velocityMax) + transform.forward * followStraight;
				}
				thing.transform.position = transform.position + rigBod.velocity;
				transform.LookAt (thing.transform);
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
			lPC.positionTransform = GameObject.FindGameObjectWithTag ("Player").transform;
			lPC.position = GameObject.FindGameObjectWithTag ("Player").transform.position;
			released = false;
			flee ();
		}
	}



	//state for when we have been shocked
	private void empDaze(){
		

	}


	//tune ink ability a bit

		
	private void follow(){


		if (effects.Contains ("emp")) {
			state = "empDaze";
			effects.Remove ("emp");
			empDaze ();
			switchedStates = true;
		}

		if (!effects.Contains ("ink")) {
			if (fleeingAway) {
				state = "runAway";
				currentTarget = lPC.positionTransform;
				fleeLifeTime = 0f;
				doubleBackTime = 0f;
				runAway ();
				fleeingAway = false;
			}
				
			velocityMax = Random.Range (velocityRangeMin, velocityRangeMax);
			steeringMax = Random.Range (steeringRangeMin, steeringRangeMax);


			Vector3 toTarget = Vector3.Normalize (currentTarget.position - transform.position);
			Vector3 desired_velocity = toTarget * velocityMax * 5f;
			Vector3 steering = desired_velocity - rigBod.velocity;
			steering = Vector3.ClampMagnitude (steering, steeringMax*steerMult);

			float distVar = Vector3.Distance (currentTarget.position, transform.position);
			//5,20
			rigBod.velocity = Vector3.ClampMagnitude (rigBod.velocity + steering, velocityMax * Mathf.Min (distVar / 5 + 1, chaseSteer)) + transform.forward * Mathf.Min (8 * 32 / (distVar), chaseStraight);

			thing.transform.position = transform.position + rigBod.velocity;
			transform.LookAt (thing.transform);
		} else {
			effects.Remove ("ink");
		}

	}


	public void flee(){
		fleeingAway = true;
		state = "runAway";
		currentTarget = lPC.positionTransform;
		fleeLifeTime = 0f;
		doubleBackTime = 0f;
		runAway ();
	}







	private void runAway(){
		if (effects.Contains ("emp")) {
			state = "empDaze";
			effects.Remove ("emp");
			empDaze ();
			switchedStates = true;
		}


		if (!switchedStates) {
		
			if (!effects.Contains ("ink")) {
				fleeLifeTime += Time.deltaTime;
				float counter = 1f;
				if (fleeLifeTime > 5) {

					counter = -1f;
					doubleBackTime += Time.deltaTime;

				}


				if (doubleBackTime > 10 || message == "foundPlayer") {
					if (message == "foundPlayer") {
						message = "none";
						state = "follow";
						follow ();

					} else {

						state = "idle";
						idle ();
					}
					fleeLifeTime = 0f;
					doubleBackTime = 0f;

				}




				velocityMax = Random.Range (velocityRangeMin, velocityRangeMax);
				steeringMax = Random.Range (steeringRangeMin, steeringRangeMax);


				Vector3 toTarget = Vector3.Normalize (currentTarget.position - transform.position);
				Vector3 desired_velocity = toTarget * velocityMax * 5f;
				Vector3 steering = desired_velocity - rigBod.velocity;
				steering = Vector3.ClampMagnitude (steering, steeringMax*steerMult);


				float distVar = Vector3.Distance (currentTarget.position, transform.position);

			
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













	/*
			if(carriedObject.tag == "Enemy"){
				carriedObject.GetComponent<EnemyHealth>().enemyTakeDmg(GetComponent<Player_stats>().giveDmg() * 8f * Time.deltaTime);
				
				if(carriedObject.GetComponent<EnemyHealth>().enemyHealthCurr <= 0)
				{
					GetComponent<Player_stats> ().playerDamage (-healthGain); //negative to counteract dammage
					Abilities a = GetComponent<Abilities> ();
					a.currStamina += 30;
					if (a.currStamina > a.maxStamina)
						a.currStamina = a.maxStamina;
					carrying = false;
					blood.transform.position = player.transform.position;
					blood.transform.forward = player.transform.forward;
					blood.Emit(20);
					dropObject();
				}
			}
	*/



















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
		rigBod.velocity += outsideFactor;
		if (waveAcc) {

			waveAccHandler ();
		}

	}

	public void changeDec(){
		lastFactor = outsideFactor;
		outsideDec = outsideFactor.magnitude / 20;

	}



	private void waveAccHandler(){
		if (outsideFactor.magnitude > 0) {
			outsideFactor -= lastFactor * outsideDec;
			if (outsideFactor.magnitude < 0.01f) {
				outsideFactor = Vector3.zero;

			}


		}else if (outsideFactor.magnitude < 0) {
			outsideFactor += lastFactor * outsideDec;
			if (outsideFactor.magnitude > -0.01f) {
				outsideFactor = Vector3.zero;
			}
		}
	}
		





}
