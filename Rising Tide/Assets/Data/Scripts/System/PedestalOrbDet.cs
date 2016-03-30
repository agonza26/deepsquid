using UnityEngine;
using System.Collections;

public class PedestalOrbDet : MonoBehaviour {

	public float speed;
	public Transform target;
	Rigidbody rb;
	bool hasAnOrb;
	Light orbILight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponentInParent<inkObjectPuzzle>().activated && hasAnOrb) 
		{
			orbILight.range = 4.25f;	
		} else if(hasAnOrb)
		{
			orbILight.range = 1f;
		}
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.transform.tag == "inkOrb") 
		{
			if (!hasAnOrb) 
			{
				c.transform.position = target.position;//Vector3.MoveTowards (transform.position, target.position, step);
				orbILight = c.GetComponentInChildren<Light>();
				rb = c.GetComponent<Rigidbody>();
				rb.isKinematic = true;
				rb.useGravity = false;
				hasAnOrb = true;
				GetComponentInParent<inkObjectPuzzle>().toggleHasAnOrb();

			}
		}
	}
}
