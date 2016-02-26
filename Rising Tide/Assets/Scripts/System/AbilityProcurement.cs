using UnityEngine;
using System.Collections;

public class AbilityProcurement : MonoBehaviour {
	//0 = speed?
	//1 = ink?
	//2 = charge?
	//3 = poison?
	public bool[] abilities = new bool[4] {false, false, false, false};
	private bool procured;
	public GameObject player;
	public GameObject inkAbilityObject;
	public GameObject speedAbilityObject;
	// Use this for initialization
	void Start () {
		procured = player.GetComponentInParent<PickupObject>().carrying;

		/*for (int i = 0; i < 4; i++) {
			abilities [i] = false;
		}*/


	}

	// Update is called once per frame
	void Update () {
		//procured = ;
		/*if (player.GetComponentInParent<PickupObject> ().carrying) {
			if(speedAbilityObject.tag == "AbilitySpeed") {
				//player.GetComponentInParent<Pickupable> ().gameObject == speedAbilityObject ) {
				speedAbilityObject.SetActive (false);
				abilities [0] = true;
				//player.GetComponentInParent<Abilities> ().SetAbilityArray (0);
				player.GetComponentInParent<PickupObject> ().carrying = false;
			}
			if(inkAbilityObject.tag == "AbilityInk") {
				Debug.Log ("I picked up ink ");
				inkAbilityObject.SetActive (false);
				abilities [1] = true;
				//player.GetComponentInParent<Abilities>().SetAbilityArray(1);
				player.GetComponentInParent<PickupObject> ().carrying = false;

			}

		}*/
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
			Debug.Log ("I picked up ink " + abilities[1]);

		} 






	}
}
