using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public string[] systems = new string[1];
	public bool currentlyAlive = true;
	public string typeOfSpawner = "gate or sphere";

	void Start(){
		if (currentlyAlive) {
			sphereRegulator ("enter");
		} else {
			sphereRegulator ("exit");
		}
	}




	void OnTriggerEnter(Collider it){
		if (it.name == "Player") {
			switch (typeOfSpawner) {
			case "gate":
				gateRegulator ();
				break;
			case "sphere":
				sphereRegulator ("enter");
				break;
			}
		}
	}

	void OnTriggerExit(Collider it){
		if (it.name == "Player") {
			switch (typeOfSpawner) {
				case "gate":
					gateRegulator ();
					break;
				case "sphere":
					sphereRegulator ("exit");
					break;
			}
		}
	}






	private void sphereRegulator(string key){
		switch (key) {
			case "enter":
				for(int i = 0 ; i< systems.Length; ++i){
					GameObject.Find (systems [i]).GetComponent<EcoPoints> ().respawn ();
				}
				break;
			case "exit":
				for(int i = 0 ; i< systems.Length; ++i){
					GameObject.Find (systems [i]).GetComponent<EcoPoints> ().despawn ();
				}
				break;
		}
		currentlyAlive = !currentlyAlive;
	}



	private void gateRegulator(){
		for(int i = 0 ; i< systems.Length; ++i){
			if (!currentlyAlive) {
				GameObject.Find (systems [i]).GetComponent<EcoPoints> ().respawn ();
			} else {
				GameObject.Find (systems [i]).GetComponent<EcoPoints> ().despawn ();
			}
		}
		currentlyAlive = !currentlyAlive;
	}
}
