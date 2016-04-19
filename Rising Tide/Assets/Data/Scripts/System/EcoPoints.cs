using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EcoPoints : MonoBehaviour {


	 
	public Dictionary<string,GameObject> Ecopoints = new Dictionary<string,GameObject>();
	public Dictionary<string,GameObject> Enemies = new Dictionary<string,GameObject>();
	public Dictionary<string,GameObject> Dump = new Dictionary<string,GameObject>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}




	void OnTriggerStay(Collider enter){
		
		//if we haven't collected any EcoPoints
		if (!Ecopoints.ContainsKey (enter.gameObject.name) && enter.gameObject.tag == "EcoPoint") {
			Ecopoints.Add (enter.gameObject.name, enter.gameObject);

			//if we haven't collected any Enemies
		} else if (!Enemies.ContainsKey (enter.gameObject.name) && enter.gameObject.tag == "Enemy") {
			Enemies.Add (enter.gameObject.name, enter.gameObject);

			//dump to find anything else ie player
		} else if(!Dump.ContainsKey (enter.gameObject.name)){
			Dump.Add (enter.gameObject.name, enter.gameObject);
		}
	}



	void OnTriggerExit(Collider enter){


		if (Ecopoints.ContainsKey (enter.gameObject.name) && enter.gameObject.tag == "EcoPoint") {
			Ecopoints.Remove (enter.gameObject.name);

		} else if (Enemies.ContainsKey (enter.gameObject.name) && enter.gameObject.tag == "Enemy") {
			Enemies.Remove (enter.gameObject.name);

		} else if(Dump.ContainsKey (enter.gameObject.name)){
			Dump.Remove (enter.gameObject.name);
		}
	}
}
