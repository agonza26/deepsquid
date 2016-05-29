using UnityEngine;
using System.Collections;

public class backdropActive : MonoBehaviour {
	private GameObject backDropActive;
	private LocationUpdate check;
	// Use this for initialization
	void Start () {
		backDropActive = GameObject.Find ("locationbackdrop");
		check = GameObject.Find ("LocationUIText").GetComponent<LocationUpdate> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (check.locActive) {
			backDropActive.SetActive (true);
		} else {
			backDropActive.SetActive (false);
		}
	}
}
