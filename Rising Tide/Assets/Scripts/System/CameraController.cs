using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public Transform playerCameraTarget;
	public Transform player;
	private Vector3 offset = new Vector3 (0f, 0f, -7.5f);
	private float rcMaxDist;
	private Vector3 camDistSave;
	public float minCameraDist = -5f;
	public float maxCameraDist = -15f;
	private Material temp;
	private bool isTouching = false;
	private bool CameraChildTouching = false;
	
	public float positionDampening = 8f; //controls how snappy the camera follows the camera object. a higher number means more snappy. lower number means more flowy
	public float rotationDampening = 5f; //see above, but applies to rotation
	private float PDsave;
	
	private Transform thisTransform;

	public float minX = -360.0f;
	public float maxX = 360.0f;

	public float minY = -45.0f;
	public float maxY = 45.0f;

	public float sensX = 100.0f;
	public float sensY = 100.0f;

	float rotationY = 0.0f;
	float rotationX = 0.0f;

		
	void Start () 
	{
		thisTransform = transform; //cache transform default
		camDistSave = offset;
		PDsave = positionDampening;
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		rcMaxDist = Vector3.Distance(transform.position, playerCameraTarget.position);
		Debug.DrawRay(transform.position, transform.forward * rcMaxDist);
		RaycastHit hit;
		rotationX += Input.GetAxis ("Mouse X") * sensX * Time.deltaTime;
		rotationY += Input.GetAxis ("Mouse Y") * sensY * Time.deltaTime;
		rotationY = Mathf.Clamp (rotationY, minY, maxY);
		if(-rcMaxDist > minCameraDist)
		{
			player.GetComponent<Player_stats>().changePlayerAlphaDown();
		} 
		else
		{
			player.GetComponent<Player_stats>().changePlayerAlphaUp();
		}		
		
		if(!playerCameraTarget)
		{
			return;   //if there is no game object for the camera to follow, return
		}
		//mouse scroll wheel. positive means that mousewheel scroll up. negative means mousewheel scroll down.
		//controls moving the camera forward and backward facing the object
		if (Input.GetAxis ("Mouse ScrollWheel") > 0 && offset.z < minCameraDist) 
		{
			offset.z += 0.8f;
			camDistSave.z += 0.8f;
			rcMaxDist -= 0.8f;
		} else if (Input.GetAxis ("Mouse ScrollWheel") < 0 && offset.z > maxCameraDist && !Physics.Raycast(transform.position, -transform.forward, out hit, 1f)) 
		{
			offset.z -= 0.8f;
			camDistSave.z -= 0.8f;
			rcMaxDist += 0.8f;
		}

		
		if(Physics.Raycast(transform.position, transform.forward, out hit, rcMaxDist) && offset.z < -2f)
		{
			if(hit.transform.tag != "Player")
			{
				pushInFront(hit);		
			}
		} 
		else if (offset.z > camDistSave.z && !Physics.Raycast(transform.position, transform.forward, rcMaxDist) && !isTouching && !Physics.Raycast(transform.position, -transform.forward, out hit, 1f))
		{
			offset.z = Mathf.Lerp(offset.z, camDistSave.z, positionDampening * Time.deltaTime);
			//Debug.Log(hit.transform.tag);
		}

		if(isTouching && offset.z < -2f)
		{
			offset.z = Mathf.Lerp(offset.z, playerCameraTarget.position.z, positionDampening * Time.deltaTime);
		}
		
		Vector3 wantedPosition = playerCameraTarget.position + (playerCameraTarget.rotation * offset);
		Vector3 currentPosition = Vector3.Lerp(thisTransform.position, wantedPosition, positionDampening * Time.deltaTime);
 		
		thisTransform.position = currentPosition;
		//Quaternion wantedRotation = Quaternion.LookRotation (playerCameraTarget.position - thisTransform.position, playerCameraTarget.up);
		
		//thisTransform.rotation = wantedRotation;
		
		transform.LookAt(playerCameraTarget);
		positionDampening = PDsave;
	}
	
	private void pushInFront(RaycastHit hit)
	{
		positionDampening = Mathf.Abs(hit.distance/Time.deltaTime);
		offset.z = -Mathf.Lerp(offset.z, hit.distance, positionDampening * Time.deltaTime);
	}
	
	private void OnTriggerEnter(Collider collider)
	{
		isTouching = true;
	}

	private void OnTriggerExit (Collider collider)
	{
		isTouching = false;
	}
		
	public void InnerCamT()
	{
		CameraChildTouching = true;
	}
	
	public void InnerCamNT()
	{
		CameraChildTouching = false;
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
