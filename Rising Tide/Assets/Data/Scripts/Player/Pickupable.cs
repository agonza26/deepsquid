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
		

	//oS  = other Size
	public bool grabbed(float oS){
		gameObject.layer = 2;
		bool held = true;

		switch (myTag) {
			case "AbilityEMP":
			case "AbilitySpeed":
			case "beautyKit":
					//GameObject.FindWithTag ("borkVisualCollider").GetComponent<TutorialObject> ().beautyKitFound = true;
				Destroy (gameObject);
				held = false;
				break;
			case "AbilityInk":
				GameObject.FindWithTag("Player").GetComponent<Abilities> ().abilities [abilityIndex] = true;
				Destroy (gameObject);
				held = false;
				break;
			case "Enemy":
				if (GetComponent<BasicEnemy> () != null) {
					BasicEnemy b = GetComponent<BasicEnemy> ();
					b.modifyState ("grabbed");
				}
				thrown = false;
				//set state to grabbed
				//pass in size
				break;
			case "Boids":
				break;


			case "box":
			default:
				GetComponent<Rigidbody> ().useGravity = false;
	            thrown = false;
				//i//f(GetComponent<Rigidbody
				break;
		}
		return held; //return if we continue to hold it
	}




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



	public void letGo(bool th = false, float force = 1f, Vector3 direction =default(Vector3)){
		switch (myTag) {
			case "Enemy":
				GetComponent<BasicEnemy> ().release();
				//isPickedUp = false;
				break;
			case "Boids":
			case "box":
			default:
				GetComponent<Rigidbody>().useGravity = true; //disabling for now
				GetComponent<Rigidbody> ().drag = 1f;
				break;
		}

		if(th)
			GetComponent<Rigidbody> ().AddForce (direction * force);;
		thrown = th;
	}


	public bool isThrown(){
		return thrown;
	}

	public void changeThrown(){
		thrown = !thrown;
	}


}
