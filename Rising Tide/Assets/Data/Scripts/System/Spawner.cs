using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public string[] systems = new string[1];


	void OnTriggerEnter(Collider it){

		if (it.name == "Player") {
		}


	}
}
