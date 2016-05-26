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

	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3 (startSize, startSize, startSize);
		GetComponent<SphereCollider>().enabled = false;
	}
	






	public void startGrowing(){
		coroutineDone = false;
		startTime = Time.time;
		StartCoroutine (a());


	}







	public IEnumerator a(){
		GetComponent<SphereCollider>().enabled = true;
		
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
		GetComponent<SphereCollider>().enabled = false;
	}









}
