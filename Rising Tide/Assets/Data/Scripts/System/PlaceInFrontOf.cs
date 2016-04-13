using UnityEngine;
using System.Collections;

public class PlaceInFrontOf : MonoBehaviour {

	public Transform targetObj;
	private Vector3 FrontPosition;
	
	// Update is called once per frame
	void FixedUpdate () {
			FrontPosition = targetObj.position;
			FrontPosition.z += 2f;
			transform.position = FrontPosition;
	}
}
