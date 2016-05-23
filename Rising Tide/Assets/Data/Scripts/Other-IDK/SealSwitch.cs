using UnityEngine;
using System.Collections;

public class SealSwitch : MonoBehaviour {



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
		if (other.gameObject.CompareTag ("milkBox")) {
			questComplete = true;
		}
	}
}
