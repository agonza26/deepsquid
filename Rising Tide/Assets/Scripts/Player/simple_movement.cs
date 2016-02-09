using UnityEngine;
using System.Collections;

public class simple_movement : MonoBehaviour {

	public float xSpeed = 120.0f;
	public float ySpeed = 120.0f;
	public float yMinLimit = -20f;
	public float yMaxLimit = 80f;
	public float distance = 5.0f;
	public float camRotMult = 200f;
	private Transform CameraTarg;
	private Quaternion ctRot;
	float x = 0.0f;
	float y = 0.0f;

	public float playerSpeed = 12.5f;
	public float distanceMin = .5f;
	public float distanceMax = 15f;
	private float tempSpeed;
	//private Rigidbody rb;//used for controlling player's

	public bool inkBoost = false;
	public bool inkBoostCD = false;
	public float inkAccBoost = 5f;

	public float dashInkCDTimer = 0f;
	public float dashInkCD = 4.5f;

	//velocity
	private float accCount = 0.025f;
	private float acc = 0.0f;
	public float accMax = 1f;
	public float coast = 0.1f;

	private float deccCount = 0.025f;
	public float deccMax = -1f;
	public float coastD = 0.1f;



	// Use this for initialization
	void Start () 
	{
		//rb = GetComponent<Rigidbody>();
		tempSpeed = playerSpeed;
		CameraTarg = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
		

		x += Input.GetAxis ("Mouse X") * xSpeed * distance * 0.0125f;
		y -= Input.GetAxis ("Mouse Y") * ySpeed * 0.0125f;
		y = ClampAngle (y, yMinLimit, yMaxLimit);


		Vector3 vel = Vector3.forward*Time.deltaTime*playerSpeed;
		Quaternion rotation = Quaternion.Euler (y, x, 0);
		CameraTarg.rotation = rotation;


		/*
		if (inkBoost == true && inkCD == true) {
			StartCoroutine(inkJump());
			//inkJump ();
		}
*/
		if (Input.GetKey ("w") && !Input.GetKey ("s")) { //move forwards
			ctRot = CameraTarg.transform.rotation;
			transform.rotation = ctRot;
			if (Input.GetKeyDown("space") && inkBoostCD == false) {
				//inkCD = true;
				//dashInkCDTimer = Time.time + dashInkCD;
				//StartCoroutine (resetInkCD ());
				float startTime = Time.time;
				StartCoroutine(inkJump());
				float endTime = Time.time;
				//Debug.Log ("Start time: " + startTime + ", End time: " + endTime);
				//inkJump ();

			} else {
				//Normal Movement Speed
				if (acc < accMax) {
					acc += accCount;
					accCount += 0.005f;
					if (acc > accMax) {
						acc = accMax;
					}
				}

			}



		} else if (Input.GetKey ("s") && !Input.GetKey ("w")) { //move backwards
			ctRot = CameraTarg.transform.rotation;
			transform.rotation = ctRot;
			if (acc > deccMax) {
				acc -= deccCount;
				deccCount += 0.005f;
				if (acc < deccMax) {
					acc = deccMax;
				}
			}


		}
		else {
			accCount = 0.025f;
			deccCount = 0.025f;

			//decrease spead to 0 naturally
			if ((acc >= 0)) {
				acc -= coast;

				if (coast > 0.01) {
					coast -= 0.01f;
				}

				if (acc < 0) {
					acc = 0;
					coast = 0.01f;
				}

			} else {
				acc += coastD;

				if (coastD > 0.01) {
					coastD -= 0.01f;
				}

				if (acc > 0) {
					acc = 0;
					coastD = 0.01f;
				}
			}

		}

		//change players position
		transform.Translate (vel * acc);

		//elevation control
		if (Input.GetKey ("r")){
			transform.Translate (Vector3.up * Time.deltaTime * 8f);
		}


		if (Input.GetKey ("f")) //Move straight down
		{
			transform.Translate (Vector3.down * Time.deltaTime * 8f);
		}

	}




	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}

	IEnumerator inkJump(){
		float startTime = Time.time;

		while(acc < (accMax + inkAccBoost)) {
			//Debug.Log("Speeding up");
			acc += accCount;
			accCount += 0.3f;
			yield return StartCoroutine (waitThisLong(0.05f));

		}
			//If reached top boosting speed, cap ACC at accMax+boost speed
			if (acc > (accMax + inkAccBoost)) {
				acc = accMax + inkAccBoost;
				inkBoostCD = true;

			} 
		yield return StartCoroutine (waitThisLong(1.05f));
		//accCount = 0.025f;
		if(inkBoostCD == true){
		
			while (acc > accMax) {
				//Debug.Log("Slowing down");	
				acc -= accCount;
				accCount += 0.001f;
				yield return StartCoroutine (waitThisLong(0.2f));
				Debug.Log ("time is : " + Time.time);
			}
				/*if (acc < accMax /*&& Input.GetKey("w")) {					
					acc = accMax;
					Debug.Log(accMax);
				}*/
		}
		
		float endTime = Time.time;
		
		Debug.Log ("Start time: " + startTime + ", End time: " + endTime);
		yield return StartCoroutine(waitThisLong(5f));
		inkBoostCD = false;
	}


	IEnumerator speedUp(){	
		

		yield return new WaitForSeconds (0.05f);


	}

	IEnumerator speedDown(){
		
		yield return new WaitForSeconds (0.10f);


	}

	IEnumerator tickSlow(){
		yield return new WaitForSeconds(0.6f);
	}
	
	IEnumerator waitThisLong(float x){
		yield return new WaitForSeconds(x);
	                                                                                                                               }


}
