using UnityEngine;
using System.Collections;

public class KrakenSwitch : MonoBehaviour {

	public GameObject gate;
	private Transform origPos;
	public Vector3 movedPos = new Vector3(0,0,0);
	public Vector3 offset  = new Vector3 (0.1f, 0, 0);
	public Transform goBack;
	public float dist = 30f;
	private bool moveGate = false;
	//bool boxCollided = false; 

	// Use this for initialization
	void Start () {
		origPos = gate.transform;
	}

	
	// Update is called once per frame
	void Update () {
		if (moveGate) {
			if (movedPos.x < dist) {
				gate.transform.position += offset;
				movedPos += new Vector3 (0.1f, 0, 0);
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
