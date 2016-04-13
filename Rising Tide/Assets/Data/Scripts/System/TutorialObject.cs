using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class TutorialObject : MonoBehaviour {
	private bool isActive = true;
	public bool debugStatements = true;
	private int minimumDist = 20;
	private int maximumDist = 120;
                   // Reference to the sphere collider trigger component.
	public GameObject tutorialText;
	float counter = 0;
	private Text tutText;
	public GameObject player;                      // Reference to the player.
	public AudioSource ding;
	public GameObject tutorialBox;
	public GameObject tutOrigin;
	RectTransform rt;
	private bool possiblyActive = true;
	private int dist;
	private int clampedDist;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
		tutorialText.SetActive (false);
		tutorialBox.SetActive (false);
		tutText = tutorialText.GetComponent<Text> ();
		//tutText.fontSize = (int)(20 / dist);
	}

	//Max fontsize = 20, minimum = 5. at Max distance, font = 5, outside the distance text doesnt show. 
	void Update ()
	{
		distanceNotify ();

	}

	void distanceNotify(){
		dist = (int)Vector3.Distance (player.transform.position, tutOrigin.transform.position);
		clampedDist = Mathf.Clamp(dist, minimumDist, maximumDist);
		//tutText.fontSize = Mathf.Clamp ((int)(120 / clampedDist)*4, 5, 20);
		//Debug.Log ((120 / clampedDist) * 6 + "," + clampedDist);
	
		if (dist <= 120) {
			tutorialText.SetActive (true);
			tutorialBox.SetActive (true);

			rt = tutorialText.GetComponent<RectTransform> ();

			rt.sizeDelta = Vector2.Lerp (rt.sizeDelta, new Vector2(600, 23), Time.deltaTime/2);
			

		} else {
			tutorialText.SetActive (false);
			tutorialBox.SetActive (false);
		}
		//Debug.Log (dist, tutText.fontSize);
	}


	void OnTriggerEnter(Collider other)
	{

		if(other.gameObject == player)
		{
			if (isActive) {
				//ding.Play();
				StartCoroutine (waitToTurnOff (5f));
			}

		}

			

	}


	IEnumerator waitToTurnOff(float x){
		
		tutorialText.SetActive (true);
		tutorialBox.SetActive (true);
		yield return new WaitForSeconds(x);
		//isActive = false;
		//tutorialText.SetActive (false);
		//tutorialBox.SetActive (false);
		//ding.Stop ();
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
