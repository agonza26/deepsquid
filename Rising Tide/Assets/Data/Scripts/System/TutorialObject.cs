using UnityEngine;
using System.Collections;



public class TutorialObject : MonoBehaviour {
	private bool isActive = true;
	public bool debugStatements = true;

                   // Reference to the sphere collider trigger component.
	public GameObject tutorialText;
	public GameObject player;                      // Reference to the player.
	public AudioSource ding;
	public GameObject tutorialBox;
	private bool possiblyActive = true;

	void Start(){
		tutorialText.SetActive (false);
		tutorialBox.SetActive (false);
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
				ding.Play();
				StartCoroutine (waitToTurnOff (5f));
			}

		}

			

	}


	IEnumerator waitToTurnOff(float x){
		
		tutorialText.SetActive (true);
		tutorialBox.SetActive (true);
		yield return new WaitForSeconds(x);
		isActive = false;
		tutorialText.SetActive (false);
		tutorialBox.SetActive (false);
		ding.Stop ();
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
