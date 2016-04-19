using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicEnemy : MonoBehaviour {


	public string ecosystem = "Eco-Test-1";
	public bool debugStatements = true;
	public string state = "idle";
	public string message = "none";



	public float outsideDec = 0f;
	public bool waveAcc = true;
	public Vector3 outsideFactor = Vector3.zero; //current outsideFactor from currents
	private Vector3 lastFactor = Vector3.zero; //stores the last iteration of the facter after we exit the currents
	public float steeringMax = 1f; //maximum steering magnitude
	public float velocityMax = 9f; //maximum velocity magnitude

	private bool testBool = false;



	public GameObject thing; //eventually make it a child of an object
	private bool leftEco = false;
	private Rigidbody rigBod; //reference to the rigid body
	private Transform currentTarget = null; //where the enemy is currently trying to go towards
	private LastPlayerSighting lPC; //used to get last player's sighting and reset valuable
	private GameObject eco;
	private float fleeLifeTime = 0f;
	private float doubleBackTime = 0f;




	private float velocityRangeMin = 2f;//5f;
	private float velocityRangeMax = 5f;//10f;
	private float steeringRangeMin = 0.5f;
	private float steeringRangeMax = 4f;







	void Start () {
		 
		eco = GameObject.Find (ecosystem);
		lPC = GameObject.FindGameObjectWithTag ("gameController").GetComponent<LastPlayerSighting> ();
		//look towards target on start
		//transform.LookAt(currentTarget);//start off looking at the first point
		rigBod = GetComponent<Rigidbody>();//init rigitbody
	}






	void OnParticleCollision(GameObject other){
		if(other.name == "ink" || other.name == "Ink"){
			state = "recharge";
		}
	}



	void Update () {

		print (state);
		//used to call commands, does not control switching from a state to another
		switch (state) { //acts depending on state
			case "follow": //sees player, currently following
				follow ();
				break;
			case "seek": //saw player, currently looking for player
				seek ();
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



	void idle(){


		if (message != "none") {
			switch (message) {
			
			case "foundPlayer":
				currentTarget = lPC.positionTransform;
				state = "follow";
				message = "none";
				follow();
				break;
			}
		}





		//assume haven't seen player


		if(currentTarget!= null)
			Debug.DrawRay (transform.position, currentTarget.position - transform.position);


		if (Random.value < 0.9f) {
			if (!eco.GetComponent<EcoPoints>().Enemies.ContainsKey(name)) {
				//if i left the area start turning around
				currentTarget = eco.transform;
			} else {
				if(currentTarget == null || Random.value < 0.01f){
					GameObject[] keyList = new List<GameObject>(eco.GetComponent<EcoPoints>().Ecopoints.Values).ToArray();
					currentTarget = keyList [(int)Random.Range (0, (float)keyList.Length   )].transform;
				}
			}

			velocityMax = Random.Range (velocityRangeMin, velocityRangeMax);
			steeringMax = Random.Range (steeringRangeMin, steeringRangeMax);

			
			Vector3 toTarget = Vector3.Normalize (currentTarget.position - transform.position);
			Vector3 desired_velocity = toTarget * velocityMax;
			Vector3 steering = desired_velocity - rigBod.velocity;
			steering = Vector3.ClampMagnitude (steering, steeringMax);
			rigBod.velocity = Vector3.ClampMagnitude (rigBod.velocity + steering, velocityMax) + transform.forward * 5f;

		}


		thing.transform.position = transform.position + rigBod.velocity;
		transform.LookAt (thing.transform);

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




		
	private void grabbed(){
	}
		
	private void follow(){
		
		if (testBool) {
			state = "runAway";
			currentTarget = lPC.positionTransform;
			fleeLifeTime = 0f;
			doubleBackTime = 0f;
			runAway ();
			testBool = false;
		}


	
		


		velocityMax = Random.Range (velocityRangeMin, velocityRangeMax);
		steeringMax = Random.Range (steeringRangeMin, steeringRangeMax);


		Vector3 toTarget = Vector3.Normalize (currentTarget.position - transform.position);
		Vector3 desired_velocity = toTarget * velocityMax*5f;
		Vector3 steering = desired_velocity - rigBod.velocity;
		steering = Vector3.ClampMagnitude (steering, steeringMax);


		float distVar = Vector3.Distance (currentTarget.position, transform.position);
		if(currentTarget!= null)
			Debug.DrawRay (transform.position, currentTarget.position - transform.position);

		//5,20
		rigBod.velocity = Vector3.ClampMagnitude (rigBod.velocity + steering, velocityMax*Mathf.Min( distVar/5 +1,2f)) + transform.forward * Mathf.Min( 8*32/(distVar), 10f) ;

	


		thing.transform.position = transform.position + rigBod.velocity;
		transform.LookAt (thing.transform);
	}
		
	public void flee(){
		testBool = true;
		state = "runAway";
		currentTarget = lPC.positionTransform;
		fleeLifeTime = 0f;
		doubleBackTime = 0f;
		runAway ();
	}


	private void runAway(){

		fleeLifeTime += Time.deltaTime;
		float counter = 1f;
		if (fleeLifeTime > 15) {
			print ("double back");
			counter = -1f;
			doubleBackTime += Time.deltaTime;

		}


		if (doubleBackTime > 20 || message == "foundPlayer" ) {
			if (message == "foundPlayer") {
				message = "none";
				print("we did it");
				state = "follow";
				follow ();

			} else {
				print("lost player");
				state = "idle";
				idle ();
			}
			fleeLifeTime = 0f;
			doubleBackTime = 0f;

		}




		velocityMax = Random.Range (velocityRangeMin, velocityRangeMax);
		steeringMax = Random.Range (steeringRangeMin, steeringRangeMax);


		Vector3 toTarget = Vector3.Normalize (currentTarget.position - transform.position);
		Vector3 desired_velocity = toTarget * velocityMax*5f;
		Vector3 steering = desired_velocity - rigBod.velocity;
		steering = Vector3.ClampMagnitude (steering, steeringMax);


		float distVar = Vector3.Distance (currentTarget.position, transform.position);
		if(currentTarget!= null)
			Debug.DrawRay (transform.position, currentTarget.position - transform.position);
		
		rigBod.velocity = Vector3.ClampMagnitude (rigBod.velocity + steering*(-1*counter) , velocityMax*Mathf.Min( distVar/5 + 5,5f))  + transform.forward * Mathf.Min( 8*32/(distVar), 20f) ;




		thing.transform.position = transform.position + rigBod.velocity;
		transform.LookAt (thing.transform);


	}




	private void seek(){
	}
		
	private void recharge(){
	}











	/* message paradigm

	*/












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












	//returns true if escaped
	//false if still being held
	public bool struggle(){
		if (state != "grabbed")
			return true;

		float theNum = Random.Range (0.00F, 1.00F);


		return(theNum < 30);

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
