using UnityEngine;
using System.Collections;

public class LocationTracking : MonoBehaviour {
	public bool here;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider o){
		if (o.gameObject == player) {
			if (gameObject.name == "KelpLoc" && GameObject.FindGameObjectWithTag ("borkVisualCollider").GetComponent<TutorialObject> ().posInDialogue == 31) {
				here = true;
			} else if (gameObject.name == "TempleLoc" && GameObject.FindGameObjectWithTag ("borkVisualCollider").GetComponent<TutorialObject> ().posInDialogue == 17) {
				here = true;
			}
			else if (gameObject.name == "Cavern") {
				here = true;
			}
			else if (gameObject.name == "KrakenGYLoc" && GameObject.FindGameObjectWithTag ("borkVisualCollider").GetComponent<TutorialObject> ().posInDialogue == 47) {
				here = true;
			}
			else if (gameObject.name == "LabLoc") {
				here = true;
			}
			else if (gameObject.name == "ReefLoc") {
				here = true;
			}
			else if (gameObject.name == "VolcLoc"&& GameObject.FindGameObjectWithTag ("borkVisualCollider").GetComponent<TutorialObject> ().posInDialogue == 22) {
				here = true;
			}
		}
			

		

	}
	
}
