using UnityEngine;
using System.Collections;

public class Pickupable : MonoBehaviour {

	public string ttName = "testtubeWhole";
	public float size = 1.0f;
	public int abilityIndex = 0;




	private string myTag = "none";
	private bool thrown = false; 


	// Use this for initialization
	void Start () {
		//mats [0] = GetComponentInChildren<Renderer>().material;
		myTag = gameObject.tag;

	}




	// Update is called once per frame
	void Update () {


	}




	void OnCollisionEnter(Collision o){
		/*if (thrown) {
			if (o.gameObject.name != ttName) {
				thrown = false;
			}
		}*/
	}








	//oS  = other Size
	public bool grabbed(float oS){
		gameObject.layer = 2;
		bool held = true;

		switch (myTag) {


		case "AbilityEMP":
		case "beautyKit":
			GameObject.FindWithTag ("borkVisualCollider").GetComponent<TutorialObject> ().beautyKitFound = true;
			Destroy (gameObject);
			held = false;
			break;
		case "AbilitySpeed":
		case "AbilityInk":
			GameObject.FindWithTag ("Player").GetComponent<Abilities> ().abilities [abilityIndex] = true;
			Destroy (gameObject);

			held = false;
			break;



		case "Enemy":
			if (GetComponent<BasicEnemy> () != null) {
				BasicEnemy b = GetComponent<BasicEnemy> ();
				b.modifyState("grabbed");
				//held = false;

			}
			//set state to grabbed
			//pass in size
			break;
		case "Boids":
			break;


		case "box":
		default:
			GetComponent<Rigidbody> ().isKinematic = true;
			thrown = false;
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
			//isPickedUp = true;
			transform.position = position;
			transform.rotation = rotation * Quaternion.Euler(0, 90f, 0);// euler to rotate on its side like we're eating it

			//get if it escaped or not

			break;
		case "Boids":


		case "box":
		default:
			transform.position = position;
			transform.rotation = rotation;
			thrown = false;
			//i//f(GetComponent<Rigidbody
			break;



		}

		return holdin;
	}



	public void letGo(bool test, Vector3 test2, float force , Vector3 v ){

		switch (myTag) {
		case "Enemy":
			GetComponent<BasicEnemy> ().release();
			//isPickedUp = false;
			break;
		case "Boids":
		case "box":
		default:
			//GetComponent<Rigidbody> ().useGravity = true;
			GetComponent<Rigidbody> ().isKinematic = false;
			GetComponent<Rigidbody> ().useGravity = true;
			//GetComponent<Rigidbody> ().velocity = v;
			if (test) {
				GetComponent<Rigidbody> ().AddForce (transform.InverseTransformDirection (test2) * -10000);
			}
			//i//f(GetComponent<Rigidbody
			thrown = true;
			break;



		}

	}


	public bool isThrown(){
		return thrown;
	}

	public void changeThrown(){
		thrown = !thrown;
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
	/*
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
				GetComponent<Renderer> ().material = mats [1];
			}
		}
	}*/



}