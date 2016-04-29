using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public Transform playerCameraTarget;
	public Transform player;
	public Vector3 offset = new Vector3 (0f, 0f, -7.5f);
	private float rcMaxDist;
	private float camDistSave;
	public float minCameraDist = -5f;
	public float maxCameraDist = -15f;
	private Material temp;
	private bool touchingEnvironment;
	private bool isTouchingAnything = false;
	private bool isTouchingCam = false;
	public float tooClose = 1.75f;
	
    float positionDampening = 25f; //controls how snappy the camera follows the camera object. a higher number means more snappy. lower number means more flowy
	//private float rotationDampening = 5f; //see above, but applies to rotation
	private float PDsave;
	
	private Transform thisTransform;

	public float minX = -360.0f;
	public float maxX = 360.0f;


	public float sensX = 100.0f;
	public float sensY = 100.0f;

	
	/*
	MAKE SURE THAT RIGID BODY COMPONENTS ARE ATTACHED TO ENVIRONMENT OBJECTS. THATS THE ONLY WAY THAT ONTRIGGERENTER/EXIT WILL DETECT COLLISION.
	and tag environment objects with "Environment"
	*/
		
	void Start () 
	{
		thisTransform = transform; //cache transform default
		camDistSave = offset.z;
		PDsave = positionDampening;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		rcMaxDist = Vector3.Distance(transform.position, playerCameraTarget.position);
		Debug.DrawRay(transform.position, -transform.forward * rcMaxDist);
		Debug.DrawRay(GameObject.FindWithTag("MainCamera").transform.position, transform.forward * 7.5f);
		RaycastHit hit;
		RaycastHit backHit;

		if(-rcMaxDist > minCameraDist)
		{
			player.GetComponent<Player_stats>().changePlayerAlphaDown();
		} 
		else
		{
			player.GetComponent<Player_stats>().changePlayerAlphaUp();
		}		
		
		if(offset.z >= -1)
		{
			offset.z = -1f;
		}
		
		if(!playerCameraTarget)
		{
			return;
		}
		//mouse scroll wheel. positive means that mousewheel scroll up. negative means mousewheel scroll down.
		//controls moving the camera forward and backward facing the object
		if (Input.GetAxis ("Mouse ScrollWheel") > 0 && offset.z < minCameraDist) 
		{
			offset.z += 0.8f;
			camDistSave += 0.8f;
			rcMaxDist -= 0.8f;
		} else if (Input.GetAxis ("Mouse ScrollWheel") < 0 && offset.z > maxCameraDist && !Physics.Raycast(transform.position, -transform.forward, out hit, 1f)) 
		{
			offset.z -= 0.8f;
			camDistSave -= 0.8f;
			rcMaxDist += 0.8f;
		}

		if (Physics.Raycast (GameObject.FindGameObjectWithTag ("MainCamera").transform.position, -transform.forward, out backHit, 7.5f) || ) {
			if (backHit.transform.tag == "Environment") {
				touchingEnvironment = true;
				if (backHit.distance < tooClose) {
					pushInFront (backHit);

				} 

			}
		} else {
			touchingEnvironment = false;
		}
		if (!touchingEnvironment) {
			offset.z = camDistSave;
		}

		/*
		if (Physics.Raycast (GameObject.FindWithTag("MainCamera").transform.position, -transform.forward, out backHit, 7.5f) && offset.z < -0.5f) {
			if (backHit.transform.tag == "Environment") {
				isTouchingAnything = true;
				if (backHit.distance < tooClose) {
					pushInFrontToo (backHit);

				} 

			} else { 
				isTouchingAnything = false;
		
			}
		}

		else if (!isTouchingAnything && !isTouchingCam) {
			offset.z = camDistSave;
		} else {
			isTouchingAnything = false;
		}


		if (Physics.Raycast (playerCameraTarget.position, -transform.forward, out hit, rcMaxDist + 3f) && offset.z < -0.5f) {
			if (hit.transform.tag == "Environment") {
				isTouchingAnything = true;
				pushInFront (hit);		
			} else if (hit.transform.tag == "MainCamera") {
				isTouchingCam = false;
				isTouchingAnything = true;

			} else {
				isTouchingCam = false;
				isTouchingAnything = false;
			}
		} else if (!isTouchingAnything && !isTouchingCam) {

		} else {
			isTouchingCam = false;
		}
		
		if(Physics.Raycast(transform.position, transform.right, out hit, 5f) || Physics.Raycast(transform.position, -transform.right, out hit, 5f))
		{
			if(!Physics.Raycast(playerCameraTarget.position, -transform.forward, out hit, rcMaxDist))
			{

				offset.z += positionDampening * Time.deltaTime;	
			}
		}*/

		
		Vector3 wantedPosition = playerCameraTarget.position + (playerCameraTarget.rotation * offset);
		Vector3 currentPosition = Vector3.Lerp(thisTransform.position, wantedPosition, positionDampening * Time.deltaTime);
		thisTransform.position = currentPosition;
		transform.LookAt(playerCameraTarget);
		positionDampening = PDsave;
	}
	
	private void pushInFront(RaycastHit hit)
	{

		offset = Vector3.Lerp(offset, -(new Vector3(0,0,hit.distance+0.2f)), 1f*Time.deltaTime);
		//offset = -(new Vector3(0,0,hit.distance+0.1f));

	}
	private void pushInFrontToo(RaycastHit heckHit){
		
		offset = Vector3.Lerp(offset, new Vector3(0,0,offset.z+1.1f),1f*Time.deltaTime);
		//offset = new Vector3(0,0,heckHit.distance+0.1f);
	}
	
	private void OnTriggerEnter(Collider collider)
	{

        /*if (collider.gameObject.transform.tag != "Environment")
        {
            return;
        }
		if(collider.gameObject.tag == "MainCamera"){
			isTouchingCam = true;
		}*/
	
	}

	private void OnTriggerExit (Collider collider)
	{

	}

	
	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}
}
