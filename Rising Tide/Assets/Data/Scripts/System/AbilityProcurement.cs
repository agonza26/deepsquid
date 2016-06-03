using UnityEngine;
using System.Collections;

public class AbilityProcurement : MonoBehaviour {
	//0 = speed?
	//1 = ink?
	//2 = charge?
	//3 = poison?
	public bool[] abilities = new bool[4] {false, false, false, false};

	public GameObject player;
	public GameObject inkAbilityObject;
	public GameObject speedAbilityObject;
	public GameObject testObject;
	//public GameObject jank;
	// Use this for initialization
	void Start () {


		/*for (int i = 0; i < 4; i++) {
			abilities [i] = false;
		}*/


	}

	// Update is called once per frame
	void Update () {

		if (speedAbilityObject.tag == "AbilitySpeed") {
			//player.GetComponentInParent<Pickupable> ().gameObject == speedAbilityObject ) {
			speedAbilityObject.SetActive (false);
			abilities [0] = true;
			//player.GetComponentInParent<Abilities> ().SetAbilityArray (0);
			player.GetComponentInParent<PickupObject> ().carrying = false;
		}

		if (inkAbilityObject.tag == "AbilityInk") {
			
			inkAbilityObject.SetActive (false);
			abilities [1] = true;
			//player.GetComponentInParent<Abilities>().SetAbilityArray(1);
			player.GetComponentInParent<PickupObject> ().carrying = false;


		} 






	}
}
