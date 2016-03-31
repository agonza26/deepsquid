using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoidManager : MonoBehaviour {


	[Range(0f, 1f)]
	public float centerMultiplier = 0.5f;
	[Range(0f, 1f)]
	public float avoidanceMultiplier = 0.5f;
	[Range(0f, 1f)]
	public float velocityMultiplier = 0.5f;
	[Range(0f, 1f)]
	public float goalMultiplier = 0.5f;



	[Range(0,20)]
	public int flockSize = 3;
	public float velocityLimit = 3;



	public GameObject prefab; //object to have flocking
	public GameObject chasee; //object for enemies to follow


	public static List<GameObject> flock;






	// Use this for initialization
	void Start () {
		flock = new List<GameObject> ();

		for (int i = 0; i < flockSize; i++) {

			Vector3 position = new Vector3 (
				Random.value * GetComponent<Collider>().bounds.size.x,
				Random.value * GetComponent<Collider>().bounds.size.y,
				Random.value * GetComponent<Collider>().bounds.size.z
			) - GetComponent<Collider>().bounds.extents;

			flock.Add (Instantiate (prefab, transform.TransformPoint(position), transform.rotation) as GameObject);

		}
		flock.ForEach (f => init(f, flock));
	}








	// Update is called once per frame
	void Update () {
		flock.ForEach (f => f.GetComponent<BoidComponent>().run (f, flock, chasee));
	}







	private void init(GameObject self, List<GameObject> l)
	{
		if (self.GetComponent<BoidComponent> () != null) {
			self.GetComponent<BoidComponent> ().init (centerMultiplier, avoidanceMultiplier, velocityMultiplier, goalMultiplier,velocityLimit);
		} else {
			l.Remove (self);
		}
	}



}