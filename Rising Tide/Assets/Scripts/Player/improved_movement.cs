using UnityEngine;
using System.Collections;

public class improved_movement : MonoBehaviour {


	float inkAccBoost = 1f;
	float x = 0.0f;
	float y = 0.0f;



	public float playerSpeed = 12.5f;
	public float distanceMin = .5f;
	public float distanceMax = 15f;
	public float abilitySpeed;
	//private Rigidbody rb;//used for controlling player's


	public float playerDrag = 1f;
	public Vector3 outsideFactor = Vector3.zero;


	//stuff for accelleration

	private float accCount = 0.025f;
	public float acc = 0.0f;
	private float accMax = 1f;
	private float coast = 0.1f;

	private float deccCount = 0.025f;
	private float deccMax = -1f;
	private float coastD = 0.1f;
	public bool[] activeAbilities;
	public bool isDead = false;

	private float xSpeed = 120.0f;
	private float ySpeed = 120.0f;
	private float yMinLimit = -80f;
	private float yMaxLimit = 80f;
	private float distance = 5.0f;
	private float camRotMult = 200f;
	private float carryingSpeed = 1f;

	public float distMag = 10f;
	private Vector3 vel;
	private Vector3 direction;
	private Vector3 movement;
	public float currStamina;

	private Transform CameraTarg;
	private Quaternion ctRot;
	private Rigidbody rb;





	// Use this for initialization
	void Start () 
	{


		isDead = false;
		currStamina = GetComponent<Abilities> ().currStamina;
		rb = GetComponent<Rigidbody> ();
		rb.drag = playerDrag;
        CameraTarg = transform.GetChild(0);
        //CameraTarg = transform.parent;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!isDead) {
			currStamina = GetComponent<Abilities> ().currStamina;
			activeAbilities = GetComponent<Abilities> ().activeAbils;
			Debug.Log (activeAbilities [1]);
			rb.velocity = Vector3.zero;
			abilitySpeed = GetComponent<Abilities> ().abilitySpeedVal;
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

			Quaternion rotation = Quaternion.Euler (y, x, 0);
			CameraTarg.rotation = rotation;
			
			//Movement controlling elevation
			//Up
			if (Input.GetKey ("r")) {

			} 
			//Down
			if (Input.GetKey ("f")) { 

			}
			//Movement forward and backward
			//Moving forwards

			if (Input.GetKey ("w") && !Input.GetKey ("s")) { 
				ctRot = CameraTarg.transform.rotation;
				transform.rotation = ctRot;
				//transform.rotation = ctRot * Quaternion.Euler (Vector3.up * 180);

				if (activeAbilities [1] == true) {
					if (Input.GetKey ("space") && activeAbilities [1] == true && currStamina > 5) {
					
						inkAccBoost = -2f;
						if (acc < accMax) {
							acc += accCount;
							accCount += 0.005f;
							if (acc > accMax) {
								acc = accMax;
							}
						}

					} else {
						inkAccBoost = 1f;
						if (acc < accMax) {
							acc += accCount;
							accCount += 0.005f;
							if (acc > accMax) {
								acc = accMax;
							}
						}
					}
				
				} else {
					inkAccBoost = 1f;
					if (acc < accMax) {
						acc += accCount;
						accCount += 0.005f;
						if (acc > accMax) {
							acc = accMax;
						}
					}
				}
			}
		//Moving backwards
		else if (Input.GetKey ("s") && !Input.GetKey ("w")) {

				ctRot = CameraTarg.transform.rotation;
				transform.rotation = ctRot;
				//transform.rotation = ctRot * Quaternion.Euler (Vector3.up * 180);
				if (activeAbilities [1] == true) {
					if (Input.GetKey ("space") && activeAbilities [1] == true && currStamina > 5) {
						inkAccBoost = 2f;
						if (acc > deccMax) {
							acc -= deccCount;
							deccCount += 0.005f;
							if (acc < deccMax) {
								acc = deccMax;
							}
						}

					} else {
						inkAccBoost = 1f;
						if (acc > deccMax) {
							acc -= deccCount;
							deccCount += 0.005f;
							if (acc < deccMax) {
								acc = deccMax;
							}
						}
					}

				} else {
					inkAccBoost = 1f;
					if (acc > deccMax) {
						acc -= deccCount;
						deccCount += 0.005f;
						if (acc < deccMax) {
							acc = deccMax;
						}
					}
				}

				//transform.rotation = ctRot * Quaternion.Euler (Vector3.up * 180);

			} else if (Input.GetKey ("space") && activeAbilities [1] == true && currStamina > 5) {
				ctRot = CameraTarg.transform.rotation;
				//transform.rotation = ctRot * Quaternion.Euler (Vector3.up * 180);
				inkAccBoost = 2f;

				if (acc > deccMax) {
					acc -= deccCount;
					deccCount += 0.005f;
					if (acc < deccMax) {
						acc = deccMax;
					}
				}
			} else {
				Debug.Log ("Starting to slow down");
				inkAccBoost = 1f;
				accCount = 0.025f;
				deccCount = 0.025f;
				//decrease spead to 0 naturally
				if ((acc >= 0)) {
					Debug.Log ("acc >= 0");
					acc -= coast;

					if (coast > 0.01) {
						coast -= 0.01f;
					}

					if (acc < 0) {
						acc = 0;
						coast = 0.01f;
					}

				} else {
					Debug.Log ("acc <= 0");
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
			if (GetComponent<PickupObject> ().carrying) {
				carryingSpeed = 0.5f;
			} else {
				carryingSpeed = 1f;
			}



			direction = transform.forward + outsideFactor;
			//RaycastHit hit;
			// ... and if a raycast towards the player hits something...
			//if (Physics.Raycast (rb.position, direction, out hit, distMag)) {
			//Debug.DrawRay(transform.position, direction);
			//vel = direction * (hit.distance - hit.distance / 1000) ;
			//} else {
			vel = direction * distMag;

			//float directionFlip = -1f;
			vel = vel * Time.deltaTime * abilitySpeed * inkAccBoost * carryingSpeed;
			if (acc != 0) {
				movement = vel * acc + transform.position;
				rb.MovePosition (movement);
			} else {
				movement = outsideFactor + transform.position;
				rb.MovePosition (movement);
			}


			//transform.Translate (vel * acc * inkAccBoost * carryingSpeed);
			outsideFactor *= 0.5f;
			///Debug.Log (outsideFactor.magnitude);
			if (outsideFactor.magnitude < 0.01f)
				outsideFactor = Vector3.zero;

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
