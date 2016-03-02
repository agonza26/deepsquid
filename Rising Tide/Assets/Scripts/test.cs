using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}


	void OnParticleCollision(GameObject other){

		if (other.tag == "Enemy") {
			if (other.GetComponent <BasicEnemy>() != null) {
				//other.GetComponent <BasicEnemy> ().ink = true;
			}
		}
	}
}