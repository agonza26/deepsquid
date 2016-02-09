using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform playerCameraTarget;
    public Transform player;
    private Vector3 offset = new Vector3(0f, 0f, -7.5f);
    private float rcMaxDist;
    private Vector3 camDistSave;
    public float minCameraDist = -5f;
    public float maxCameraDist = -15f;
    private bool AlphaDrop = false;
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


    void Start()
    {
        thisTransform = transform; //cache transform default
        camDistSave = offset;
        PDsave = positionDampening;
        //minCameraDistAlphaDropRange = minCameraDist + 1.6f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        rcMaxDist = -offset.z;
        Debug.DrawRay(transform.position, transform.forward * rcMaxDist);
        //Debug.DrawRay(transform.position, -transform.forward * 1f);
        if (!playerCameraTarget)
        {
            return;   //if there is no game object for the camera to follow, return
        }
        rotationX += Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
        rotationY += Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, minY, maxY);

        //mouse scroll wheel. positive means that mousewheel scroll up. negative means mousewheel scroll down.
        //controls moving the camera forward and backward facing the object
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && offset.z < minCameraDist)
        {
            offset.z += 0.8f;
            camDistSave.z += 0.8f;
            rcMaxDist -= 0.8f;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && offset.z > maxCameraDist)
        {
            offset.z -= 0.8f;
            camDistSave.z -= 0.8f;
            rcMaxDist += 0.8f;
            AlphaDrop = false;
        }
        RaycastHit hit;


        if (CameraChildTouching)
        {
            // = 1.5f/Time.deltaTime;
            //float objToPlayr = Vector3.Distance(hit.transform.position, playerCameraTarget.transform.position);
            offset.z += 0.25f;
        }
        else
        {
            //positionDampening = PDsave;
        }

        /*if(AlphaDrop && player.material.color.a > 0.35f)
		{
			player.material.color.a -= 0.2f;
		}*/
        if (offset.z > camDistSave.z && !Physics.Raycast(transform.position, transform.forward, rcMaxDist) && !isTouching && !Physics.Raycast(transform.position, -transform.forward, out hit, 1f))
        {
            offset.z -= 0.5f;
        }

        if (Physics.Raycast(transform.position, transform.forward, out hit, rcMaxDist))
        {
            float objToPlayr = Vector3.Distance(hit.transform.position, playerCameraTarget.transform.position);
            float camToPlayr = Vector3.Distance(transform.position, playerCameraTarget.transform.position);
            float pushCfrwrd = camToPlayr - objToPlayr;
            offset.z = -1f * objToPlayr + 1.125f;
            /*if(pushCfrwrd > 0)
			{
				offset.z += pushCfrwrd;
			} else 
			{
				offset.z -= pushCfrwrd;
			}*/
            positionDampening = Mathf.Abs(pushCfrwrd / Time.deltaTime);

            Debug.Log("pushCfrwrd " + pushCfrwrd);
        }
        Vector3 wantedPosition = playerCameraTarget.position + (playerCameraTarget.rotation * offset);
        Vector3 currentPosition = Vector3.Lerp(thisTransform.position, wantedPosition, positionDampening * Time.deltaTime);

        thisTransform.position = currentPosition;
        //Quaternion wantedRotation = Quaternion.LookRotation (playerCameraTarget.position - thisTransform.position, playerCameraTarget.up);

        //thisTransform.rotation = wantedRotation;

        transform.LookAt(playerCameraTarget);
        positionDampening = PDsave;
    }

    private void OnTriggerEnter(Collider collider)
    {
        isTouching = true;
        Debug.Log("Camera collided with wall");
    }

    private void OnTriggerExit(Collider collider)
    {
        isTouching = false;
    }

    public void InnerCamT()
    {
        CameraChildTouching = true;
        //positionDampening = 1f/Time.deltaTime;
        Debug.Log("CameraChild collision triggered");
    }

    public void InnerCamNT()
    {
        CameraChildTouching = false;
        //positionDampening = PDsave;
        Debug.Log("CameraChild left the wall");
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
