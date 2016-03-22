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
	private float accMax = 2f;
	private float coast = 0.1f;

	private float deccCount = 0.025f;
	private float deccMax = -1.5f;
	private float coastD = 0.1f;
	public bool[] activeAbilities;
	public bool isDead = false;

	private float xSpeed = 45.0f;
	private float ySpeed = 45.0f;

	private float distance = 5.0f;
	private float carryingSpeed = 1f;
	private Vector3 lastFactor = Vector3.zero;
	private float outsideDec = 0f;
	public bool waveAcc = true;

	public float distMag = 10f;
	private Vector3 vel;
	private Vector3 direction;
	private Vector3 movement;
	public float currStamina;

	private Transform CameraTarg;
	private Quaternion ctRot;
	private Rigidbody rb;


	bool sqid = false;


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
		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			if (!sqid){
				Cursor.lockState = CursorLockMode.Locked;
			}else {
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}

			sqid = !sqid;

		}


		if (!isDead) {
			currStamina = GetComponent<Abilities> ().currStamina;
			activeAbilities = GetComponent<Abilities> ().activeAbils;
			//Debug.Log (activeAbilities [1]);
			rb.velocity = Vector3.zero;
			abilitySpeed = GetComponent<Abilities> ().abilitySpeedVal;
			x += Input.GetAxis ("Mouse X") * xSpeed * distance * 0.0125f;
			if (y >= -85.6) {
				y -= Input.GetAxis ("Mouse Y") * ySpeed * distance * 0.0025f;
			} else {
				y = -85.5f;
			}
			if (y <= 85.6) {
				y -= Input.GetAxis ("Mouse Y") * ySpeed * distance * 0.0025f;
			} else {
				y = 85.5f;
			}

			Quaternion rotation = Quaternion.Euler (y, x, 0);
			CameraTarg.rotation = rotation;
			
		
			ctRot = CameraTarg.transform.rotation;
			//if (!GetComponent<PickupObject>.parented) {
			transform.rotation = ctRot;
			transform.forward *= -1;
			//}




			if (Input.GetKey ("r")) {

			} 
			//Down
			if (Input.GetKey ("f")) { 

			}
			//Movement forward and backward
			//Moving forwards




			if (Input.GetKey ("w") && !Input.GetKey ("s")) { 
				
				//transform.rotation = ctRot * Quaternion.Euler (Vector3.up * 180);

				if (activeAbilities [1] == true) {
					if (Input.GetKey ("space") && activeAbilities [1] == true && currStamina > 5) {
					
						inkAccBoost = -3f;
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

			
				//transform.rotation = ctRot * Quaternion.Euler (Vector3.up * 180);
				if (activeAbilities [1] == true) {
					if (Input.GetKey ("space") && activeAbilities [1] == true && currStamina > 5) {
						inkAccBoost = 3f;
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
				inkAccBoost = 3f;
				if (acc > deccMax) {
					acc -= deccCount;
					deccCount += 0.005f;
					if (acc < deccMax) {
						acc = deccMax;
					}
				}
			} else {
				
				inkAccBoost = 1f;
				accCount = 0.025f;
				deccCount = 0.025f;
				//decrease spead to 0 naturally
				if ((acc >= 0)) {
					
					
					acc -= coast;

					if (coast > 0.02) {
						coast -= 0.01f;
					}

					if (acc < 0) {
						acc = 0;
						coast = 0.01f;
					}

				} else {
					
					acc += coastD;

					if (coastD > 0.02) {
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



			direction = transform.forward*-1 + outsideFactor;
			RaycastHit hit;
			// ... and if a raycast towards the player hits something...
			//Debug.DrawRay(transform.position, direction*10000);

			//Debug.DrawRay(rb.position, direction*10000);

			if (!Physics.Raycast (rb.position, direction, out hit, distMag)) {
				
				vel = direction * (hit.distance - hit.distance / 1000) ;
			} else {
				vel = direction * distMag;

				//float directionFlip = -1f;
				vel = vel * Time.deltaTime * abilitySpeed * inkAccBoost * carryingSpeed;

				//if(!GetComponent<PickupObject>().parented){
				if (acc != 0) {
					movement = vel * acc + transform.position;
					rb.MovePosition (movement);
				} else {
					movement = outsideFactor + transform.position;
					rb.MovePosition (movement);
				}

			}
			if (waveAcc) {
				waveHadler ();
			}
		}
	}


	private void waveHadler(){
		if (outsideFactor.magnitude > 0) {
			outsideFactor -= lastFactor * outsideDec;
			if (outsideFactor.magnitude < 0.01f) {
				outsideFactor = Vector3.zero;

			}
		} else if (outsideFactor.magnitude < 0) {
			outsideFactor += lastFactor * outsideDec;
			if (outsideFactor.magnitude > -0.01f) {
				outsideFactor = Vector3.zero;

			}


		}

	}


	public void changeDec(){
		lastFactor = outsideFactor;
		outsideDec = outsideFactor.magnitude / 20;

	}
	public Vector3 getMovement(){
		return movement;
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
	
	}
	
	//Coroutine to wait x amount of time
	IEnumerator waitThisLong(float x){
		yield return new WaitForSeconds(x);
	                                                                                                                               }
		}
