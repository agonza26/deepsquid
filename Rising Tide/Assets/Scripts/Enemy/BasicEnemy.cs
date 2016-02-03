using UnityEngine;
using System.Collections;

public class BasicEnemy : MonoBehaviour {
	public Transform pos1; //until I make an array
	public Transform pos2; //only three different places to patrol between
	public Transform pos3;

	public float dg = 5f; //drag
	public float vel = 5f; //velocity

	public float radius; //how far away from the patrol points should the fist start turning towards the next
	public float magicNum; //dont remember at the moment
	public float wiggleVar; // how far away from path should the enemy wander
	public float swimT; // how frequent the fish "swims", normal

	//not used at the moment
	/*
	public float swimPanicT; // how frequent the fish "swims", Panic
	public float swimAttackT; // how frequent the fish "swims, Attack
	public float swimHuntT; // how frequent the fish "swims, Hunt
	*/



	private int index = 1;
	private float timeC = 0f;
	private Rigidbody rigBod;
	private Transform currentHeading;
	private Transform currentTarget;



	//SARA calls



	void Start () {

		//wish i could use pointers and better copy methods :(
		currentTarget = pos1; 
		currentHeading = currentTarget;
		transform.LookAt(currentHeading);//start off looking at the first point


		rigBod = GetComponent<Rigidbody>();//init rigitbody
		rigBod.velocity = (transform.forward * vel); //assign forward direction velocity 
		rigBod.drag = dg; //drag slows down enemy to emulate water
	}





	//this model could be used for a steering director possibly
	void Update () {
		timeC += Time.deltaTime; //increase timer clock 
		if (timeC >= swimT) { //if we hit the assigned swim timer, its time to swim
			swim ();
			timeC = 0; //reset timer
		}
	
		//if we are near the current target
		float dist = Vector3.Distance (transform.position, currentTarget.position);
		if (dist < radius) {
			changeTarget ();
		}
	}




	void swim(bool straight = false, int factor = 1){
		if (straight) {
			//Not sure what else to add here at the moment 
		}else{
			wiggle (factor); //simple implementation of randomness untill steering ai(backlogged a lot)
			//same here
		}
		rigBod.velocity = (transform.forward * vel);

	}


	void wiggle(int factor){
		Vector3 test = currentHeading.position;
		test += Vector3.up * Random.Range (-magicNum, magicNum);
		test += Vector3.down * Random.Range (-magicNum, magicNum);
		test += Vector3.left * Random.Range (-magicNum, magicNum);
		test += Vector3.right* Random.Range (-magicNum, magicNum);


		//check to see if we are too far
		float distX = Mathf.Abs(test.x-currentTarget.position.x);
		float distY = Mathf.Abs(test.y-currentTarget.position.y);
		float distZ = Mathf.Abs(test.z-currentTarget.position.z);
		if (distX > wiggleVar||distY > wiggleVar||distZ > wiggleVar) {

			Debug.Log("we are too far off");
		}


		transform.LookAt(test);
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
		currentHeading = currentTarget; //temporary test
		transform.LookAt(currentHeading);
	}



}
