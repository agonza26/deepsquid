using UnityEngine;
using System.Collections;

public class CurrentSystem : MonoBehaviour {



	[Range(-3.000f, 3.000f)] public float xCom;
	[Range(-3.000f, 3.000f)] public float yCom;
	[Range(-3.000f, 3.000f)] public float zCom;

	public Vector3 moveDir = new Vector3(0,0,3);
	public GameObject cameraObject;




	private Vector3 homePos;
	private Vector3 waveFactor;
	private Vector3 waveStartPos = new Vector3(0, 0, 0);

	void Start(){
		waveFactor = new Vector3 (xCom, yCom, zCom);
		waveStartPos = transform.position;
	}
	void Update(){
		Debug.DrawRay(transform.position, waveFactor);






		if (transform.position.z >= 740) {
			transform.position = homePos;
		} else {
			transform.Translate (moveDir);
		}





		Physics.IgnoreCollision (cameraObject.GetComponent<Collider> (), GetComponent<Collider>());
	}


	//waveAcc = false;


	void OnTriggerEnter(Collider other){

		switch(other.gameObject.tag) {
		case "Player":
			if (other.gameObject.GetComponent<improved_movement> () != null) {


				other.gameObject.GetComponent<improved_movement> ().waveAcc = false;

			}
			break;
		case "enemy":
			break;
		case "CameraTarget":
			break;
		}

		//other.gameObject.GetComponent<improved_movement> ().waveAcc = false;
	}


	void OnTriggerStay(Collider other){
		switch(other.gameObject.tag) {
		case "Player":
			if (other.gameObject.GetComponent<improved_movement> () != null) {
				


				other.gameObject.GetComponent<improved_movement> ().outsideFactor+=waveFactor;

			}
			break;
		case "enemy":
			break;
		case "CameraTarget":
			break;
		}
	}



	void OnTriggerExit(Collider other)
	{

		switch(other.gameObject.tag) {
			case "Player":
				if (other.gameObject.GetComponent<improved_movement> () != null) {
					other.gameObject.GetComponent<improved_movement> ().waveAcc = true;
				other.gameObject.GetComponent<improved_movement> ().changeDec ();
				}
				break;
			case "enemy":
				break;
			case "CameraTarget":
				break;
		}
	}



}
