using UnityEngine;
using System.Collections;

public class LocationUpdate : MonoBehaviour {

	private GameObject player;
	public GameObject loc;
	public GameObject backdrop;
	public bool locActive;
	// Use this for initialization
	void Start () {
		loc.SetActive (false);
		player = GameObject.FindGameObjectWithTag("Player");
		//backdrop = GameObject.Find ("locationbackdrop");
		backdrop.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider o){
		if (o.gameObject == player) {
			loc.SetActive (true);
			locActive = true;
			backdrop.SetActive (true);
		}
		
	}
	void OnTriggerExit (Collider o){
		if (o.gameObject == player) {
			loc.SetActive (false);
			locActive = false;
			backdrop.SetActive (false);
		}
	}
}
