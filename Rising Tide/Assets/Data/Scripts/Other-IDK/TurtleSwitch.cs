using UnityEngine;
using System.Collections;

public class TurtleSwitch : MonoBehaviour {



	public bool questComplete;
	//bool boxCollided = false; 

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other) 
	{
		if (other.gameObject.CompareTag ("pillowBox")) {
			questComplete = true;
		}
	}
}
