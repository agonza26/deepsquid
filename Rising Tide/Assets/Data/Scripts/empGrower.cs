using UnityEngine;
using System.Collections;

public class empGrower : MonoBehaviour {
	public bool debugFeatures = true;
	public float growScale = 0.5f;
	public float sizeLimit = 28f;
	public float startSize = 0.1f;
	private float startTime = -1f;
	public float waitTime = 0.001f;
	public bool coroutineDone = true;

	private bool switchBool = true;
	private float r = 0f;
	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3 (startSize, startSize, startSize);
	}
	
	// Update is called once per frame
	void Update () {
		if (debugFeatures && false) {
			r += Time.deltaTime;
			if (switchBool && r > 3f) {
				startGrowing ();
				switchBool = false;
			}
		}
	}

	public void startGrowing(){
		coroutineDone = false;
		startTime = Time.time;
		StartCoroutine (a());


	}







	public IEnumerator a(){
		
		if(debugFeatures)
			Debug.Log ("a() started");

		while (transform.localScale.x < sizeLimit) {
			transform.localScale += new Vector3 (growScale, growScale,growScale);
			yield return new WaitForSeconds(waitTime);
		}


		while (transform.localScale.x > startSize) {
			yield return new WaitForSeconds(waitTime);
			transform.localScale -= new Vector3 (growScale, growScale,growScale);
		}


		if (debugFeatures) {
			Debug.Log ("a() stopped");
			print (Time.time - startTime);
		}
		coroutineDone = true;

	}


























	public IEnumerator b(){
		if(debugFeatures)
			Debug.Log ("b() started");



		while (transform.localScale.x < sizeLimit) {
			transform.localScale += new Vector3 (growScale, growScale,growScale);
			yield return new WaitForSeconds(waitTime);
		}
		if(debugFeatures)
			Debug.Log ("b() ended");
		//yield return null;

	}



}
