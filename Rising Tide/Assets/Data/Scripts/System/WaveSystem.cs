using UnityEngine;
using System.Collections;

public class WaveSystem : MonoBehaviour {



	[Range(-3.000f, 3.000f)] public float xCom;
	[Range(-3.000f, 3.000f)] public float yCom;
	[Range(-3.000f, 3.000f)] public float zCom;
	public Vector3 moveDir = new Vector3(0,0,3);
	public GameObject cameraObject;




	//private Vector3 homePos;
	private Vector3 waveFactor;
	private Vector3 waveStartPos = new Vector3(0, 0, 0);

	void Start(){
		waveFactor = new Vector3 (xCom, yCom, zCom);
		waveStartPos = transform.position;
	}
	void Update(){
		Debug.DrawRay(transform.position, waveFactor);
		if (transform.position.z >= 740) {
			transform.position = waveStartPos;
			//transform.position = homePos;
		} else {
			transform.Translate (moveDir);
		}





		Physics.IgnoreCollision (cameraObject.GetComponent<Collider> (), GetComponent<Collider>());
	}


	//waveAcc = false;


	void OnTriggerEnter(Collider other){
		GameObject it = other.gameObject;

		switch(it.tag) {
			case "Player":
				if (it.GetComponent<improved_movement> () != null) {
					it.GetComponent<improved_movement> ().waveAcc = false;
				}
				break;
			case "Enemy":
				
				if (it.GetComponent<BasicEnemy> () != null) {
				it.GetComponent<BasicEnemy> ().changeAcc( false);
				}
				break;
			case "CameraTarget":
				break;
		}


	}


	void OnTriggerStay(Collider other){
		GameObject it = other.gameObject;
		switch(it.tag) {
			case "Player":
				if (it.GetComponent<improved_movement> () != null) {
					it.GetComponent<improved_movement> ().outsideFactor+=waveFactor;
				}
				break;
			case "Enemy":

				if (it.GetComponent<BasicEnemy> () != null) {
					it.GetComponent<BasicEnemy> ().outsideFactor+=waveFactor;
				}
				break;
			case "CameraTarget":
				break;
		}
	}



	void OnTriggerExit(Collider other)
	{
		GameObject it = other.gameObject;
		switch(it.tag) {
			case "Player":
				if (it.GetComponent<improved_movement> () != null) {
					it.GetComponent<improved_movement> ().waveAcc = true;
					it.GetComponent<improved_movement> ().changeDec ();
				}
				break;
			case "Enemy":
				if (it.GetComponent<BasicEnemy> () != null) {
				it.GetComponent<BasicEnemy> ().changeAcc(true);
					it.GetComponent<BasicEnemy> ().changeDec ();
				}
				break;
			case "CameraTarget":
				break;
		}
	}



}
