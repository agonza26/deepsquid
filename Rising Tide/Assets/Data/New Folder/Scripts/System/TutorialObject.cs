using UnityEngine;
using System.Collections;

public class TutorialObject : MonoBehaviour {

public bool debugStatements = true;
          // Last place this enemy spotted the player.

		public SphereCollider col;                     // Reference to the sphere collider trigger component.
		public GameObject tutorialText;
		public GameObject player;                      // Reference to the player.
              // Where the player was sighted last frame.
		
		//private float timer = 0f;
		public float timerLimit = 5f;

		void Start(){
			tutorialText.SetActive(false);
		}
		void Awake ()
		{
			tutorialText.SetActive(false);
			//col = GetComponent<SphereCollider>();
			player = GameObject.FindGameObjectWithTag("Player");

		}


		void Update ()
		{


		}


		void OnTriggerEnter(Collider other)
		{
		// If the player has entered the trigger sphere...
			if(other.gameObject == player)
			{
			//Debug.Log("We hella now");
				tutorialText.SetActive(true);

			}


		}





		void OnTriggerStay (Collider other)
		{
			// If the player has entered the trigger sphere...
			if(other.gameObject == player)
			{
				//Debug.Log("We hella now");
				tutorialText.SetActive(true);
				
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
