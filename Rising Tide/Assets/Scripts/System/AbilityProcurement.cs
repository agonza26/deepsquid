using UnityEngine;
using System.Collections;

public class AbilityProcurement : MonoBehaviour {
	//0 = speed?
	//1 = ink?
	//2 = charge?
	//3 = poison?
	public bool[] abilities = new bool[4];
	private bool procured;
	public GameObject player;
	public GameObject inkAbilityObject;
	// Use this for initialization
	void Start () {
		procured = player.GetComponentInParent<PickupObject>().carrying;

		for (int i = 0; i < 4; i++) {
			abilities [i] = false;
		}


	}

	// Update is called once per frame
	void Update () {
		//procured = ;
		Debug.Log ("Procured in abilities is: " + procured);
		if(player.GetComponentInParent<PickupObject>().carrying && inkAbilityObject.tag == "AbilityInk"){
			Debug.Log ("trueueueue");
			inkAbilityObject.SetActive (false);
			abilities [1] = true;
			player.GetComponentInParent<PickupObject> ().carrying = false;

		}

	}
}
