using UnityEngine;
using System.Collections;

public class endGameSwitch : MonoBehaviour {



	public bool questComplete;
	//bool boxCollided = false; 

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Player")) {
			questComplete = true;
		}
	}
}
