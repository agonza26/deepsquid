using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public Transform playerCameraTarget;
	public Transform player;
	public Vector3 offset = new Vector3 (0f, 0f, -7.5f);
	private float rcMaxDist;
	public Vector3 camDistSave;
	public float minCameraDist = -5f;
	public float minCameraDistAlphaDropRange;
	public float maxCameraDist = -15f;
	private bool AlphaDrop = false;
	private Material temp;
	//private bool isTouching = false;
	
	public float positionDampening = 8f; //controls how snappy the camera follows the camera object. a higher number means more snappy. lower number means more flowy
	public float rotationDampening = 5f; //see above, but applies to rotation
	
	private Transform thisTransform;

	public float minX = -360.0f;
	public float maxX = 360.0f;

	public float minY = -45.0f;
	public float maxY = 45.0f;

	public float sensX = 100.0f;
	public float sensY = 100.0f;

	float rotationY = 0.0f;
	float rotationX = 0.0f;

	int touchedTimer = 0;
		
	void Start () 
	{
		thisTransform = transform; //cache transform default
		camDistSave = offset;
		temp = playerCameraTarget.GetComponentInParent<Material>();
		minCameraDistAlphaDropRange = minCameraDist + 1.6f;
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		rcMaxDist = -offset.z;
		Debug.DrawRay(transform.position, Vector3.forward * rcMaxDist);
		if(!playerCameraTarget)
		{
			return;   //if there is no game object for the camera to follow, return
		}
		rotationX += Input.GetAxis ("Mouse X") * sensX * Time.deltaTime;
		rotationY += Input.GetAxis ("Mouse Y") * sensY * Time.deltaTime;
		rotationY = Mathf.Clamp (rotationY, minY, maxY);

		//mouse scroll wheel. positive means that mousewheel scroll up. negative means mousewheel scroll down.
		//controls moving the camera forward and backward facing the object
		if (Input.GetAxis ("Mouse ScrollWheel") > 0 && offset.z < minCameraDist) 
		{
			offset.z += 0.8f;
			camDistSave.z += 0.8f;
			rcMaxDist -= 0.8f;
		} else if (Input.GetAxis ("Mouse ScrollWheel") < 0 && offset.z > maxCameraDist) 
		{
			offset.z -= 0.8f;
			camDistSave.z -= 0.8f;
			rcMaxDist += 0.8f;
			AlphaDrop = false;
		}
		if(Physics.Raycast(transform.position, Vector3.forward, rcMaxDist))
		{
			offset.z += 1f;
		} 
		
		/*if(AlphaDrop && player.material.color.a > 0.35f)
		{
			player.material.color.a -= 0.2f;
		}*/
		if(offset.z > camDistSave.z && !Physics.Raycast(transform.position, Vector3.forward, rcMaxDist))
		{
			offset.z -= 0.8f;
		} 

		Vector3 wantedPosition = playerCameraTarget.position + (playerCameraTarget.rotation * offset);
		Vector3 currentPosition = Vector3.Lerp(thisTransform.position, wantedPosition, positionDampening * Time.deltaTime);

		thisTransform.position = currentPosition;
		
		Quaternion wantedRotation = Quaternion.LookRotation (playerCameraTarget.position - thisTransform.position, playerCameraTarget.up);
		
		thisTransform.rotation = wantedRotation;
		

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
