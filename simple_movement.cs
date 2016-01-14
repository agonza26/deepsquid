using UnityEngine;
using System.Collections;

public class simple_movement : MonoBehaviour {

	public float xSpeed = 120.0f;
	public float ySpeed = 120.0f;
	public float yMinLimit = -20f;
	public float yMaxLimit = 80f;
	public float distance = 5.0f;
	public float camRotMult = 200f;
	float x = 0.0f;
	float y = 0.0f;
	public float playerSpeed = 12.5f;
	public float distanceMin = .5f;
	public float distanceMax = 15f;
	private float tempSpeed;
	private Transform thisTransform;


	// Use this for initialization
	void Start () 
	{
		thisTransform = transform;
		tempSpeed = playerSpeed;
	}
	
	// Update is called once per frame
	void Update () {

		x += Input.GetAxis ("Mouse X") * xSpeed * distance * 0.02f;
		y -= Input.GetAxis ("Mouse Y") * ySpeed * 0.02f;

		y = ClampAngle (y, yMinLimit, yMaxLimit);

		Quaternion rotation = Quaternion.Euler (y, x, 0);

		distance = Mathf.Clamp (distance - Input.GetAxis ("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

		RaycastHit hit;
		if (Physics.Linecast (thisTransform.position, transform.position, out hit)) {
			distance -= hit.distance;
		}
		if (Input.GetKey ("a")) //move left
		{
			x -= Time.deltaTime*camRotMult;
		}
		if (Input.GetKey ("d")) 
		{
			x += Time.deltaTime*camRotMult;
		}
			Vector3 negDistance = new Vector3 (0.0f, 0.0f, -distance);
			transform.rotation = rotation;
		if (Input.GetKey("w")) //move forwards
		{
			transform.Translate(Vector3.forward*Time.deltaTime*playerSpeed);
		}
		if (Input.GetKey ("s")) //move backwards
		{
			transform.Translate(-Vector3.forward*Time.deltaTime*playerSpeed);
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
}
