using UnityEngine;
using System.Collections;

public class improved_movement : MonoBehaviour {
	public float rotationDeadZone = 250f;
	public float rotationSpeedMax = 1f;

	public float currStamina;
	public float acc = 0.0f;
	public float rotMax = 10f;
	public bool[] activeAbilities;
	public bool isDead = false;

	public Vector3 outsideFactor = Vector3.zero;
	public bool waveAcc = true;
	public float speedMod = 1.5f;

	//stuff for accelleration

	private float accCount = 0.025f;
	private float accMax = 2f;
	private float coast = 0.1f;
	private float coastD = 0.1f;

	private float xSpeed = 45.0f;
	private float ySpeed = 45.0f;



	private float abilitySpeed;
	private Vector3 lastFactor = Vector3.zero;
	private float outsideDec = 0f;
	private float deccCount = 0.025f;
	private float deccMax = -1.5f;
	private float distMag = 10f;
	private Vector3 vel;
	private Vector3 direction;
	private Vector3 movement;

	private bool isEgg;
	private GameObject helperObject;
	private Transform CameraTarg;
	private Quaternion ctRot;
	private Rigidbody rb;


	float currentX = 0.0f;
	float currentY = 0.0f;
	float x = 0.0f;
	float y = 0.0f;
	bool sqid = false;


	// Use this for initialization
	void Start () 
	{
		helperObject = GameObject.FindGameObjectWithTag ("borkVisualCollider");
		isEgg = helperObject.GetComponent<TutorialObject> ().isEgg;
		isDead = false;
		currStamina = GetComponent<Abilities> ().currStamina;
		rb = GetComponent<Rigidbody> ();

        CameraTarg = transform.GetChild(0);
        //CameraTarg = transform.parent;
	}

	public void getSlider(float rate){
		rotationSpeedMax = rate;

	}


	private void rotationHandler2(bool isEgg){
		if (!isEgg) {

			//target rotations
			print("rotation speed" + rotationSpeedMax);

			x += Input.GetAxis ("Mouse X") * 4000f; //left and right
			y = Mathf.Clamp ( y-Input.GetAxis ("Mouse Y") * rotationSpeedMax, -85.5f, 85.5f); //up and down


			
			currentX += Input.GetAxis ("Mouse X") * rotationSpeedMax ;

			if (currentX < x - rotationDeadZone) {
				//currentX += Mathf.Min(200, x-rotationDeadZone - currentX) ;

			} else if (currentX > x + rotationDeadZone) {
				//currentX -= Mathf.Min (200, currentX - x + rotationDeadZone);

			} if (currentY < y) {
				currentY +=  Mathf.Min(rotationSpeedMax, y-rotationDeadZone - currentY) ;

			} else if (currentY > y) {
				currentY -= Mathf.Min (rotationSpeedMax, currentY - x + rotationDeadZone);

			} 
				

		}

		if (!isDead) {
			Quaternion rotation = Quaternion.Euler (y, currentX, 0);
			CameraTarg.rotation = rotation;
			transform.rotation = CameraTarg.rotation;
			transform.forward *= -1;
		}

	}


	private void rotationHandler(bool isEgg){
		if (!isEgg) {
			
			//target rotations

			//left and right
			x += Input.GetAxis ("Mouse X") * 225* 0.0125f;
			//up and down
			y = Mathf.Clamp ( y-Input.GetAxis ("Mouse Y")  * 225 * 0.0025f, -85.5f, 85.5f); //up and down







		}

		if (!isDead) {
			Quaternion rotation = Quaternion.Euler (y, x, 0);
			CameraTarg.rotation = rotation;
			transform.rotation = CameraTarg.rotation;
			transform.forward *= -1;
		}

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		isEgg = helperObject.GetComponent<TutorialObject> ().isEgg;
		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			if (!sqid){
				Cursor.lockState = CursorLockMode.Locked;
			}else {
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
			sqid = !sqid;
		}
			
		rotationHandler2 (isEgg);

		if (!isDead && !isEgg){
			rb.velocity = Vector3.zero;
			currStamina = GetComponent<Abilities> ().currStamina;
			activeAbilities = GetComponent<Abilities> ().activeAbils;
			abilitySpeed = GetComponent<Abilities> ().abilitySpeedVal;

			Vector3 elevation = Vector3.zero;
			//Control moving up an down
			if (Input.GetKey ("r") && ! Input.GetKey ("f")) {
				elevation += transform.up * 0.3f;
			} else if (Input.GetKey ("f") && ! Input.GetKey ("r")) { 
				elevation += transform.up * -0.3f;
			}
			Vector3 horzPos = Vector3.zero;
			//Control moving left and right
			if (Input.GetKey ("a") && !Input.GetKey ("d")) {
				horzPos += transform.right * 0.3f;
			}
			else if (Input.GetKey ("d") && ! Input.GetKey ("a")) { 
				horzPos += transform.right * -0.3f;
			}


			//Movement forward and backward
			//Moving forwards


	

			if (Input.GetKey ("w") && !Input.GetKey ("s")) { 
				if (acc < accMax) {
					acc += accCount;
					accCount += 0.005f;
					if (acc > accMax) {
						acc = accMax;
					}
				}
			}
		//Moving backwards
			else if (Input.GetKey ("s") && !Input.GetKey ("w")) {
				if (acc > deccMax) {
					acc -= deccCount;
					deccCount += 0.005f;
					if (acc < deccMax) {
						acc = deccMax;
					}
				}

			}  else {
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
			
			direction = transform.forward*-1 + outsideFactor;
			vel = direction * distMag * Time.deltaTime * abilitySpeed * speedMod;

			if (acc != 0) {
				movement = vel * acc + transform.position + elevation + horzPos;
				rb.MovePosition (movement);
			} else {
				movement = outsideFactor + transform.position + elevation + horzPos;
				rb.MovePosition (movement);
			}

			if(waveAcc) {
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
