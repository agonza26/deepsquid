using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PushWave : MonoBehaviour {



	[Range(-3.000f, 3.000f)] public float pushFactor;

	public GameObject cameraObject;


	private float lifeTime = 3f;
	private float vel = 4f;
	private Vector3 homePos;

	private Vector3 waveStartPos = new Vector3(0, 0, 0);

	List<GameObject> encountered = new List<GameObject>();

	void Start(){
		//StartCoroutine(destroyMe ());
	}




	void Update(){


		//transform.position += transform.forward;
		Physics.IgnoreCollision (cameraObject.GetComponent<Collider> (), GetComponent<Collider>());
	}


	void OnTriggerEnter(Collider other){
		GameObject it = other.gameObject;


		if (!encountered.Contains (it)) {
			encountered.Add (it);
			Debug.Log (it);
			if (it.GetComponent<BasicEnemy> () != null) {
				it.GetComponent<BasicEnemy> ().outsideFactor+=transform.forward;
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
