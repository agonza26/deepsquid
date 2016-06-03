using UnityEngine;
using System.Collections;

public class LabSwitch : MonoBehaviour {

	public GameObject gate;
	public Transform origPos;
	private Vector3 origPosVect;
	public Vector3 movedPos = new Vector3(0,0,0);
	public Transform goBack;
	public float dist = 30f;
	private bool moveGate = false;
	//bool boxCollided = false; 

	// Use this for initialization
	void Start () {
		origPos = gate.transform;
		origPosVect = gate.transform.localPosition;
		movedPos = origPosVect + new Vector3 (30f, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (moveGate) {
			GameObject.FindGameObjectWithTag ("borkVisualCollider").GetComponent<TutorialObject> ().gateIsOpen = true;
			if (movedPos.x < dist) {
				gate.transform.localPosition += new Vector3 (0.5f, 0, 0);
				movedPos += new Vector3 (0.5f, 0, 0);
			}//= Vector3.Lerp (origPos, movedPos, 0.1f);

		}
	}

	void OnTriggerEnter(Collider other) 
	{
		
		if (other.gameObject.CompareTag ("box")) {
			moveGate = true;
		}
	}

}
