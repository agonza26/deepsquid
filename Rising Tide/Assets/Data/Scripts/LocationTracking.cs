using UnityEngine;
using System.Collections;

public class LocationTracking : MonoBehaviour {
	public bool here;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider o){
		if (o.gameObject == player)
			here = true;
	}
}
