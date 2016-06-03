using UnityEngine;
using System.Collections;

public class DynamicObjAv : MonoBehaviour {
	
	public float maxMag = 3f;
	private Vector3 directionalForce = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay(Collider c){
		GameObject o = c.gameObject;
		if(o.GetComponent<SpringJoint>()){
			directionalForce = Vector3. ClampMagnitude(o.transform.position  - GetComponentInParent<Transform>().position, maxMag);
			//o.GetComponent<Rigidbody>().AddForce(directionalForce);
			
			
		}
		
		
	}
}
