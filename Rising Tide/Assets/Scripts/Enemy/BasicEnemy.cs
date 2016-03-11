using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicEnemy : MonoBehaviour {


	public bool debugStatements = true;
	public string state = "patrol";
	public string message = "none";

	public float timeFS = 0.01f;
	public float vel = 5f; //velocity
	public float radius; //how far away from the patrol points should the fist start turning towards the next


	public float swimT; // how frequent the fish "swims", normal
	public float swimF; // how frequent the fish "swims", follow
	public float swimA; // how frequent the fish "swims, attack; temporary until distinct attacks are implemented per each fish
	public float huntT; // how long fish will look for player after loosing sight

	public float swimRadius = 30; //turn radius of fish lol

	public float wiggleVar; // possible distance away object will "wiggle"
	public float wiggleLimit; // how far away from path should the enemy wander

	public Transform pos1; //until I make an array
	public Transform pos2; //only three different places to patrol between
	public Transform pos3; 


	private bool seeking = true; //in seek state, true if we are heading towards last know place for player
	private int index = 1; //used to iterate through points, will be legacy later

	//time variables
	private float timeC = 0f; 
	private float timeF = 0f; 
	private float timeS = 0f; 
	private float timeHT = 0f; 


	private float waitTime = 0f;
	private float lifetime = 0f; 



	private Rigidbody rigBod; //reference to the rigid body
	private bool switchT = false;
	private Transform currentTarget; //where the enemy is currently trying to go towards
	private Vector3 currentT;        // same as above, just vector
	private LastPlayerSighting lPC; //used to get last player's sighting and reset valuable

	public float outsideDec = 0f;
	public bool waveAcc = true;
	public Vector3 outsideFactor = Vector3.zero;
	private Vector3 lastFactor = Vector3.zero;

	void Start () {
		lPC = GameObject.FindGameObjectWithTag ("gameController").GetComponent<LastPlayerSighting> ();

		//prepares patrol state
		currentTarget = pos1; 
		currentT = currentTarget.position;

		//look towards target on start
		transform.LookAt(currentTarget);//start off looking at the first point
		rigBod = GetComponent<Rigidbody>();//init rigitbody
	}




	void Update () {
		lifetime += Time.deltaTime; //increase how long this has been living

		timeC += Time.deltaTime; //increase timer clock 

		//used to call commands, does not control switching from a state to another
		switch (state) { //acts depending on state
			case "follow":
				
				follow ();
				break;
			case "seek":
				seek ();
				break;



			case "grabbed":
				grabbed ();
				break;

			case "recharge":
				recharge ();
				break;

			case "patrol":
			default:
				patrol ();
				break;
		}
		waveHandler ();

	}


	private void runAway(){



	}

	//start coroutine, after X seconds, go back to patrolling




	void OnParticleCollision(GameObject other){
		Debug.Log("Object has been hit by ink");
	}


	//returns true if escaped
	//false if still being held
	public bool struggle(){
		if (state != "grabbed")
			return true;

		float theNum = Random.Range (0.00F, 1.00F);
		print (theNum + "is the random number");

		return(theNum < 30);

	}





	private void grabbed(){
		//message system to switch to another states
		if (message != "none") {
			switch (message) {
				case "escape":
					state = "patrol";
					message = "none";
					patrol();
					break;
			}
		}



		//basically do nothing, maybe play some different action, its now dependant on the holder





	}



























	private void follow(){
		


		//message system to switch to another states
		if (message != "none") {
			switch (message) {
				case "lostPlayer":
					state = "patrol";
					message = "none";
					patrol();
					break;
			}
		}

		//get current player's location from eyes
		currentT = lPC.position;

		//iff
		if (currentT != lPC.resetPosition && timeF ==0) {
			swim ();
		}

		timeF += Time.deltaTime;
		if (timeF >= timeFS) {
			timeF = 0;
		}

	}




	void fixRotation (Vector3 heading, Vector3 target){
		//finds the angle between the projected point if going straight and to the target (player);
		float a = angleBetween (transform.InverseTransformPoint (heading), transform.InverseTransformPoint (target), "x"); //viewing from x axis
		float b = angleBetween (transform.InverseTransformPoint (heading), transform.InverseTransformPoint (target), "y"); //vidwing from y axis
		//decided z wasn't needed, might use for correction due to a fish's appearance, such as a shark

		//used to limit turning radius, might implement an increasing turning behavior later on.
		float upAngle = ((a > swimRadius) ? swimRadius : a); 
		float rightAngle = ((b > swimRadius) ? swimRadius : b);


		//converts to Quanternion
		Quaternion rotR = Quaternion.AngleAxis(rightAngle, Vector3.up);
		Quaternion rotU = Quaternion.AngleAxis(upAngle, Vector3.left);

		// rotate around World Left/Right
		transform.rotation =  transform.rotation * rotR;
		// rotate around Local Up/down
		transform.rotation = transform.rotation * rotU;
	}





	float angleBetween(Vector3 from, Vector3 to, string axis  ){
		Vector2 fromVector2;
		Vector2 toVector2;

		switch (axis) {
			case "x":
				fromVector2 = new Vector2(from.y, from.z);
				toVector2 = new Vector2(to.y, to.z);
				break;
			case "y":
				fromVector2 = new Vector2(from.x, from.z);
				toVector2 = new Vector2(to.x, to.z);
				break;
			case "z":
				fromVector2 = new Vector2(from.x, from.y);
				toVector2 = new Vector2(to.x, to.y);
				break;
			default:
				fromVector2 = new Vector2(0, 0);
				toVector2 = new Vector2(0,0);
				break;
		}



		float ang = Vector2.Angle(fromVector2, toVector2);
		Vector3 cross = Vector3.Cross(fromVector2, toVector2);

		if (cross.z > 0) {
			//ang = 360 - ang;// used if i want to represent it with 0 is to right of forwards, and 360 to left
			ang = -ang;      //used if i want to represent it with + to the right of forwards, and - to the left
		}
		return ang;

	}










	void patrol()
	{
		if (message != "none") {
			switch (message) {
				case "seePlayer":
					message = "none";
					state = "follow";
					follow ();
					break;
			}
				
		} else {
			float variance = Random.Range (0.001f, swimT);

			if (timeC >= variance) { //if we hit the assigned swim timer, its time to swim
				if (switchT) {
					changeTarget ();
				} 
				currentT = currentTarget.position;

				swim ();
				timeC = 0; //reset timer
			}
			//if we are near the current target, allows us to store if we have passed it 
			//and to switch direction when its time to swim
			float dist = Vector3.Distance (transform.position, currentTarget.position);
			if (dist < radius) {
				switchT= true;
			}
		}

	}







	void changeTarget(bool overRide = false, Transform custTarget = null){
		switch (index) {
		case 2:
			index = 3;
			currentTarget = pos3;
			break;
		case 3:
			index = 1;
			currentTarget = pos1;

			break;
		case 1:
		default:
			index = 2;
			currentTarget = pos2;
			break;
		}
		currentT = currentTarget.position;
		switchT= false;
		//eventually access map of points, then choose a neighbor
	}












	void recharge(){



		//message system to switch to another states
		if (message != "none") {
			//switch (message) {

			//}
		}

		//get current player's location from eyes
		currentT = lPC.position;

		waitTime += Time.deltaTime;
		if (waitTime >= 0.75f) {
			
			state = "patrol";

			waitTime = 0;
		}

	}





	//not completely implemented
	void seek(){

		if (message != "none") {
			switch (message) {
			case "foundPlayer":
				state = "follow";
				message = "none";
				follow();
				break;
			}
		}



		if (seeking) {
			currentT = lPC.position; //get last current player's location from eyes

			Vector3.Distance (transform.position, currentT);

			if (Vector3.Distance (transform.position, currentT) < 2) {  //if close to last spot of player, change to looking around
				seeking = false;
				huntT = 0;
			} else {
				swim ();
			}

		} else {
			timeHT += Time.deltaTime;

			//if the fish has exhausted all of its time looking for the target
			if (timeHT >= huntT) {
				//switch state to patrol

			} else {
				//go towards current node

			}
		}



		if (currentT != lPC.resetPosition && timeS ==0) {
			swim ();
		}

		timeS += Time.deltaTime;
		if (timeS >= 5) {

			timeS = 0;
		}

	}















	void swim(){
		float mag = 1f;//used for debugging when trying to spawn objects, used to project visually some direction of Vector 3 to the world
		//where we would be going if we go straight
		Vector3 currentHeading = new Vector3 (transform.position.x + (transform.forward * vel*mag).x, 
			transform.position.y + (transform.forward * vel*mag).y, transform.position.z + (transform.forward * vel*mag).z);

		//will adjust enemy's rotation within bounds
		fixRotation (currentHeading, currentT);
		rigBod.velocity = (transform.forward * vel );

	}











	void wiggle(int factor){
		Vector3 test = currentTarget.position;
		test += Vector3.up * Random.Range (-wiggleVar, wiggleVar);
		test += Vector3.down * Random.Range (-wiggleVar, wiggleVar);
		test += Vector3.left * Random.Range (-wiggleVar, wiggleVar);
		test += Vector3.right* Random.Range (-wiggleVar, wiggleVar);


		//check to see if we are too far
		float distX = Mathf.Abs(test.x-currentTarget.position.x);
		float distY = Mathf.Abs(test.y-currentTarget.position.y);
		float distZ = Mathf.Abs(test.z-currentTarget.position.z);
		if (distX > wiggleLimit||distY > wiggleLimit||distZ > wiggleLimit) {

		}
		transform.LookAt(test);
	}




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
