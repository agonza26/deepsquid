using UnityEngine;
using System.Collections;

public class Pickupable : MonoBehaviour {

	public float size = 1.0f;
	public int abilityIndex = 0;
	public Material[] mats = new Material[2];



	public bool isPickedUp;
	private string myTag = "none";



	// Use this for initialization
	void Start () {

		mats [0] = GetComponentInChildren<Renderer>().material;
		myTag = gameObject.tag;

	}

	// Update is called once per frame
	void Update () {
		

	}








	//oS  = other Size
	public bool grabbed(float oS){
		gameObject.layer = 2;
		bool held = true;

		switch (myTag) {

			
			case "AbilityEMP":
			case "AbilitySpeed":
			case "AbilityInk":
				GameObject.FindWithTag("Player").GetComponent<Abilities> ().abilities [abilityIndex] = true;
				Destroy (gameObject);
				held = false;
				break;

				

			case "Enemy":
				if (GetComponent<BasicEnemy> () != null) {
					BasicEnemy b = GetComponent<BasicEnemy> ();
						b.state = "grabbed";
						//held = false;

				}
				//set state to grabbed
				//pass in size
				break;
			case "Boids":
				break;


			case "box":
			default:
				GetComponent<Rigidbody> ().useGravity = false;
				//i//f(GetComponent<Rigidbody
				break;



		}
		return held;

	}

	/*
	if (p.gameObject.tag == "AbilitySpeed") {
		Destroy(p.gameObject);

		abilities [0] = true;
		carrying = false;
	}
	*/






	//will return the object back to its "normal" state
	public bool holding(Vector3 position, Quaternion rotation){
		
		bool holdin = true;
		switch (myTag) {
			case "Enemy":
				if (GetComponent<BasicEnemy> () != null) {
					GetComponent<BasicEnemy> ().struggle (); //returns if escaped
				}
				isPickedUp = true;
				transform.position = position;
				transform.rotation = rotation * Quaternion.Euler(0, 90f, 0);// euler to rotate on its side like we're eating it
				
				//get if it escaped or not
				
				break;
			case "Boids":


			case "box":
			default:
				transform.position = position;
				transform.rotation = rotation;

					//i//f(GetComponent<Rigidbody
					break;



		}

		return holdin;
	}



	private void letGo(){

		switch (myTag) {
		case "Enemy":
			isPickedUp = false;
			break;
		case "Boids":


		case "box":
		default:
			//i//f(GetComponent<Rigidbody
			break;



		}

	}






	private void neutralize(){
		GetComponent<Rigidbody>().useGravity = false;
		//put the object below player, move sorta smoothly with Lerp
		//float d = (o.GetComponent<Collider>().bounds.size.z) * 0.2f;

		/*
		playerZRot = player.transform.rotation;
		Vector3 UnderPlayerPosition = player.transform.position+player.transform.forward*-4;
		transform.position = Vector3.Lerp(o.transform.position, UnderPlayerPosition, Time.deltaTime * smooth);
		transform.rotation = playerZRot; //stop picked up object from rotating independently

		*/
	}

	public void changeMatToNml()
	{
		if (mats [0]) 
		{
			if (transform.childCount > 0) {
				GetComponentInChildren<Renderer> ().material = mats [0];
			} else {
				GetComponent<Renderer> ().material = mats [0];
			}
		}
	}

	public void changeMatToHL()
	{
		if (mats [1]) 
		{
			if (transform.childCount > 0) {
				GetComponentInChildren<Renderer> ().material = mats [1];
			} else {
				//GetComponent<Renderer> ().material = mats [1];
			}
		}
	}



}
