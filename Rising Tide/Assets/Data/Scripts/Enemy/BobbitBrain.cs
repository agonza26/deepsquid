using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BobbitBrain : MonoBehaviour {


	public bool debugStatements = true;
	public string state = "patrol";
	public string message = "none";

	public float range = 5f;





	public float hideDist = 3f;







	public float vel = 5f; //velocity



	private bool isAttacking = false;
	private Vector3 startPos; //positon when enemy started lunging
	private Vector3 initPos; //the position when the player was mseen





	public float swimT; // how frequent the fish "swims", normal
	public float swimF; // how frequent the fish "swims", follow
	public float swimA; // how frequent the fish "swims, attack; temporary until distinct attacks are implemented per each fish
	public float huntT; // how long fish will look for player after loosing sight







	//time variables
	private float swimRadius = 0.2f; //turn radius of fish lol
	private float timeC = 0f; 
	private float timeS = 0f; 
	private float lifetime = 0f; 

	private Rigidbody rigBod; //reference to the rigid body

	private Vector3 currentT;        // same as above, just vector
	private LastPlayerSighting lPC; //used to get last player's sighting and reset valuable



	void Start () {
		lPC = GameObject.FindGameObjectWithTag ("gameController").GetComponent<LastPlayerSighting> ();

		//prepares patrol state
		currentT = lPC.position;
		startPos = lPC.resetPosition;
		//look towards target on start
		//transform.LookAt(currentT);//start off looking at the first point
		rigBod = GetComponent<Rigidbody>();//init rigitbody
	}











	void Update () {
		lifetime += Time.deltaTime; //increase how long this has been living

		timeC += Time.deltaTime; //increase timer clock 

		//used to call commands, does not control switching from a state to another
		switch (state) { //acts depending on state
		case "follow": //gets ready to attack
			follow ();
			break;
		case "sneek": //name of attack
			sneek ();
			break;
		case "hide": //will stir dust without attack and change position, retains health
			//hide();
			break;

		case "patrol": //just chillin
		default:
			patrol ();
			break;
		}

	}


	void OnParticleCollision(GameObject o){
	}










	void patrol()
	{
		if (message != "none") {
			switch (message) {
			case "seePlayer":
				Debug.Log ("we are here");
				initPos = transform.position;
				message = "none";
				state = "follow";
				follow ();
				break;
			}

		} else {



		}

	}








	//not completely implemented
	void sneek(){

		if (message != "none") {
			//switch (message) {

			//}
		}

		currentT = lPC.position;
		if (currentT != lPC.resetPosition && Vector3.Distance (startPos, currentT) <= range) {
			attack();
			isAttacking = true;
		} else {

			isAttacking = false;

			Debug.Log ("swim down");
		}







		if (timeS ==0) {
		}
		timeS += Time.deltaTime;
		if (timeS >= 5) {
			timeS = 0;
		}

	}







	//if the player is within striking distance, attack
	//otehrwise
	//		if we aren't fully hidden
	//			bury
	//		else
	//          stay put

	void follow(){


		startPos = transform.GetChild (0).position;

		currentT = lPC.position;
		if (currentT != lPC.resetPosition && Vector3.Distance (startPos, currentT) <= range*2) {
			Debug.Log ("sneak?");
			state = "sneek";
			sneek ();
		} else {

			if (Vector3.Distance (startPos, initPos) <= hideDist*2) {
				Debug.Log ("Not Here");
				rigBod.drag = 0f;
				transform.position += transform.up * -2;

			} else {

				rigBod.drag = 20000f;
				rigBod.velocity = transform.up*0;
			}

		}
	}







	void attack(){
		float mag = 1f;//used for debugging when trying to spawn objects, used to project visually some direction of Vector 3 to the world



		//where we would be going if we go straight
		Vector3 currentHeading = new Vector3 (transform.position.x + (transform.up * vel*mag).x, 
			transform.position.y + (transform.up * vel*mag).y, transform.position.z + (transform.forward * vel*mag).z);

		//will adjust enemy's rotation within bounds
		fixRotation (currentHeading, currentT);

		rigBod.velocity = (transform.up * vel );


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





















}