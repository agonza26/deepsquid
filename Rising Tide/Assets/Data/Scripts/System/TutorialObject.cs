using UnityEngine;
using System.Collections;



public class TutorialObject : MonoBehaviour {
	private bool isActive = true;
	public bool debugStatements = true;

                   // Reference to the sphere collider trigger component.
	public GameObject tutorialText;
	public GameObject player;                      // Reference to the player.
	private bool possiblyActive = true;

	void Start(){
		tutorialText.SetActive (false);
	}
	void Awake ()
	{
		tutorialText.SetActive(false);
		player = GameObject.FindGameObjectWithTag("Player");

	}

	void Update ()
	{
		
	}


	void OnTriggerEnter(Collider other)
	{

		if(other.gameObject == player)
		{
			if (isActive) {
				StartCoroutine (waitToTurnOff (5f));
			}

		}

			

	}


	IEnumerator waitToTurnOff(float x){
		tutorialText.SetActive (true);
		yield return new WaitForSeconds(x);
		isActive = false;
		tutorialText.SetActive (false);
		
	}



	void OnTriggerStay (Collider other)
	{
		// If the player has entered the trigger sphere...
		if(other.gameObject == player)
		{
			//Debug.Log (isActive);

		}


	}





	void OnTriggerExit (Collider other)
	{
		// If the player leaves the trigger zone...
		if (other.gameObject == player) {
			tutorialText.SetActive(false);

		}
	}
}
