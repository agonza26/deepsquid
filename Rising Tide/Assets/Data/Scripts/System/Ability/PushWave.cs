using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PushWave : MonoBehaviour {



	[Range(-3.000f, 3.000f)] public float pushFactor;
	public float speed = 1f;

	private GameObject cameraObject;


	public float lifeTime = 0.5f;
	//private float vel = 4f;
	private Vector3 homePos;
	private float timePassed = 0f;

	List<GameObject> encountered = new List<GameObject>();

	void Start(){
		cameraObject = GameObject.FindGameObjectWithTag ("MainCamera");
		//StartCoroutine(destroyMe ());
	}




	void Update(){

		//speed *= -1f;
		transform.position += transform.forward*speed;
		Physics.IgnoreCollision (cameraObject.GetComponent<Collider> (), GetComponent<Collider>());
		timePassed += Time.deltaTime;
		if (timePassed > lifeTime) {
			//Debug.Log ("after");
			if (GetComponentInChildren<DetachPS> ()) {
				GetComponentInChildren<DetachPS> ().DetachParticles ();
			}
			Destroy (gameObject);
		}
	}


	void OnTriggerEnter(Collider other){
		GameObject it = other.gameObject;


		if (!encountered.Contains (it)) {
			encountered.Add (it);
			if (it.GetComponent<BasicEnemy> () != null) {
				it.GetComponent<BasicEnemy> ().outsideFactor+=  it.transform.InverseTransformDirection( transform.TransformDirection (transform.forward) )* pushFactor;
				it.GetComponent<BasicEnemy> ().changeAcc (true);
				it.GetComponent<BasicEnemy> ().changeDec ();
			}

		}
		//Destroy (gameObject);

	}









}
