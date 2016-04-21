using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PushWave : MonoBehaviour {



	[Range(-3.000f, 3.000f)] public float pushFactor;
	public float speed = 1f;

	private GameObject cameraObject;


	private float lifeTime = 3f;
	//private float vel = 4f;
	private Vector3 homePos;


	List<GameObject> encountered = new List<GameObject>();

	void Start(){
		cameraObject = GameObject.FindGameObjectWithTag ("MainCamera");
		//StartCoroutine(destroyMe ());
	}




	void Update(){


		transform.position += transform.forward*speed;
		Physics.IgnoreCollision (cameraObject.GetComponent<Collider> (), GetComponent<Collider>());
	}


	void OnTriggerEnter(Collider other){
		GameObject it = other.gameObject;


		if (!encountered.Contains (it)) {
			encountered.Add (it);
			Debug.Log (it);
			if (it.GetComponent<BasicEnemy> () != null) {
				it.GetComponent<BasicEnemy> ().outsideFactor+=transform.forward * pushFactor;
				it.GetComponent<BasicEnemy> ().waveAcc = true;
				it.GetComponent<BasicEnemy> ().changeDec ();
			}

		}

	}






	public IEnumerator destroyMe(){
		Debug.Log ("before");
		yield return StartCoroutine (waitThisLong (lifeTime));
		Debug.Log ("after");
		Destroy (gameObject);

	}






	//Coroutine to wait x amount of time
	IEnumerator waitThisLong(float x){
		yield return new WaitForSeconds(x);

	}





}
