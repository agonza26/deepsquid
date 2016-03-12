using UnityEngine;
using System.Collections;

public class LabSwitch : MonoBehaviour {

	public GameObject gate;
	public Transform origPos;
	public Vector3 movedPos = new Vector3(0,0,0);
	public Transform goBack;
	public float dist = 30f;
	bool boxCollided = false; 

	// Use this for initialization
	void Start () {
		origPos = gate.transform;
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other) 
	{
		if (other.gameObject.CompareTag ("box")) {
			if (movedPos.x < dist) {
				gate.transform.localPosition += new Vector3 (0.1f, 0, 0);
				movedPos += new Vector3 (0.1f, 0, 0);
			}//= Vector3.Lerp (origPos, movedPos, 0.1f);
		}
	}
}
