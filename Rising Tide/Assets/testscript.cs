using UnityEngine;
using System.Collections;

public class testscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnParticleCollision(GameObject other){
		print ("box hit a " + other.name);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
