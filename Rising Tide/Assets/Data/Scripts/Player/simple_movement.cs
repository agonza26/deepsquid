using UnityEngine;
using System.Collections;

public class simple_movement : MonoBehaviour {

	public float xSpeed = 120.0f;
	public float ySpeed = 120.0f;
	public float yMinLimit = -80f;
	public float yMaxLimit = 80f;
	public float distance = 5.0f;
	public float camRotMult = 200f;
	private Transform CameraTarg;
	private Quaternion ctRot;
	float x = 0.0f;
	float y = 0.0f;
	public ParticleSystem bubbles;

	public float playerSpeed = 12.5f;
	public float distanceMin = .5f;
	public float distanceMax = 15f;
	//private float tempSpeed;
	private float carryingSpeed = 1f;
	public float abilitySpeed;
	//private Rigidbody rb;//used for controlling player's

	bool inkJumpedBack = false;
	float inkAccBoost = 1f;
	public float travelSpeed = 1f;
	bool tentaclesForward;
	bool isDead = false;
	

	//velocity
	Vector3 vel;
	private float accCount = 0.025f;
	public float acc = 0.0f;
	public float accMax = 1f;
	public float coast = 0.1f;

	private float deccCount = 0.025f;
	public float deccMax = -1f;
	public float coastD = 0.1f;
	//private bool[] abilities;
	public GameObject abilityObject;



	// Use this for initialization
	void Start () 
	{
        CameraTarg = transform.GetChild(0);
		//abilities = abilityObject.GetComponent<AbilityProcurement> ().abilities;
	}
	
	// Update is called once per frame
	void Update () {
		if(!isDead)
		{
	
			abilitySpeed = GetComponent<Abilities> ().abilitySpeedVal;
			//abilities = abilityObject.GetComponent<AbilityProcurement> ().abilities;
			x += Input.GetAxis ("Mouse X") * xSpeed * distance * 0.0125f;
			if (y >= -90) {
				y -= Input.GetAxis ("Mouse Y") * ySpeed * distance * 0.0025f;
			} else {
				y = -89.5f;
			}
			if (y <= 90) {
				y -= Input.GetAxis ("Mouse Y") * ySpeed * distance * 0.0025f;
			} else {
				y = 89.5f;
			}


			vel = Vector3.forward * Time.deltaTime * playerSpeed * abilitySpeed;//*abilitySpeed;
			Quaternion rotation = Quaternion.Euler (y, x, 0);
			CameraTarg.rotation = rotation;
			bubbles.Pause();
			
			//bubbles.Play();	
			if (Input.GetKey ("w") && !Input.GetKey ("s")) { //move forwards
				ctRot = CameraTarg.transform.rotation;
				//transform.Rotate(0, 0, ctRot.z);
				transform.rotation = ctRot;
				transform.forward *= -1f;
				if(Time.deltaTime % 5 == 0)
				{
					bubbles.transform.position = transform.position;
					//bubbles.transform.rotation.y = 0;
					bubbles.Play();
				}
				if (acc < accMax) {
					acc += accCount;
					accCount += 0.005f;
					if (acc > accMax) {
						acc = accMax;
					}
				}
				if(Input.GetKey(KeyCode.LeftShift))
				{
					vel *= -1f;
					transform.forward *= -1f;
					travelSpeed = 2f;
					tentaclesForward = false;
				} 
				else 
				{
					travelSpeed = 1f;
					tentaclesForward = true;
				}

			} else if (Input.GetKey ("s") && !Input.GetKey ("w")) { //move backwards
				ctRot = CameraTarg.transform.rotation;
				transform.rotation = ctRot;
				transform.forward *= -1f;
				tentaclesForward = true;
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
				//transform.rotation = Quaternion.Lerp(transform.rotation, ctRot, 8f * Time.deltaTime);
				if(!tentaclesForward)
				{
					vel *= -1;
				}
			}
			
			//change players position
			if(GetComponent<PickupObject>().carrying)
			{
				carryingSpeed = 0.5f;
			} 
			else 
			{
				carryingSpeed = 1f;
			}

			
			transform.Translate (-vel * acc * inkAccBoost * carryingSpeed * travelSpeed);		
			//Debug.Log(tentaclesForward);
			
			//elevation control
			if (Input.GetKey ("r")){
				transform.Translate (Vector3.up * Time.deltaTime * 8f);
			}


			if (Input.GetKey ("f")) //Move straight down
			{
				transform.Translate (Vector3.down * Time.deltaTime * 8f);
			}
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

	//Controls the ink movement, like moving forward or backwards depending on
	//acceleration.
	public IEnumerator inkJump(){
		if(acc == 0 && inkJumpedBack == false){
			acc = -1;
			inkAccBoost = 5f;
			yield return StartCoroutine (waitThisLong(0.5f));
			acc = 0f;
			inkAccBoost = 1f;
			inkJumpedBack = true;
			
		}
		else if(inkJumpedBack != true){
			inkAccBoost = 5f;
			yield return StartCoroutine (waitThisLong(0.5f));
			inkAccBoost = 1f;
		}
		inkJumpedBack = false;
	}

	public void toggleDeathState()
	{
		isDead = true;
		Debug.Log("Simple Movement isDead " + isDead);
	}

	
	//Coroutine to wait x amount of time
	IEnumerator waitThisLong(float x){
		yield return new WaitForSeconds(x);
	                                                                                                                               }
		}
