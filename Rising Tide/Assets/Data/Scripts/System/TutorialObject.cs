using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class TutorialObject : MonoBehaviour {

	public bool debugStatements = true;
	private int minimumDist = 20;
	private int maximumDist = 120;
	public GameObject tutorialText;
	private Text tutText;
	public GameObject player;
	public AudioSource ding;
	public GameObject tutorialBox;
	public GameObject tutOrigin;
	RectTransform rt;
	private bool inLOS = false;
	private bool inRangeToHear = false;
	private bool inRangeToInt = false;
	private bool inLOS_inRange = false;
	public string[] narrText = new string[20];
	public bool[] narrTextTrigger = new bool[20];
	private int posInDialogue = 0;
	private bool firstDialogueTrigger = false;
	private int dist;
	private int distToInteract;
	private int clampedDist;

	void Start(){
		narrTextTrigger [0] = true;
		fillNarrativeString ();
		player = GameObject.FindGameObjectWithTag("Player");
		tutorialText.SetActive (false);
		tutorialBox.SetActive (false);
		tutText = tutorialText.GetComponent<Text> ();
	}

	//Max fontsize = 20, minimum = 5. at Max distance, font = 5, outside the distance text doesnt show. 
	void Update ()
	{
		if (inLOS && inRangeToHear) {
			inLOS_inRange = true;
		} else {
			inLOS_inRange = false;
		}
		if (inLOS_inRange) {
			tutorialText.SetActive (true);
			tutorialBox.SetActive (true);
			rt = tutorialText.GetComponent<RectTransform> ();
			tutText.text = narrText [posInDialogue];
			rt.sizeDelta = Vector2.Lerp (rt.sizeDelta, new Vector2 (550, 35), Time.deltaTime / 0.5f);
			if(Input.GetKeyDown("e") && firstDialogueTrigger && inRangeToInt && narrTextTrigger[posInDialogue+1]){
				posInDialogue++;
				Debug.Log (posInDialogue);
				rt.sizeDelta = new Vector2(100, 23);
			}
			if (!firstDialogueTrigger) {
				firstDialogueTrigger = true;
				StartCoroutine (waitForDialogueTrigger(5f));

			}
		} else {
			tutorialText.SetActive (false);
			tutorialBox.SetActive (false);

		}
		distanceNotify ();
		Debug.Log (posInDialogue);
		//Debug.Log ("In Range: " + inRangeToHear + ", In LOS: " + inLOS + ", In LOSINRANGE: " + inLOS_inRange);


	}

	void distanceNotify(){
		dist = (int)Vector3.Distance (player.transform.position, tutOrigin.transform.position);
		clampedDist = Mathf.Clamp(dist, minimumDist, maximumDist);
	
		if (dist <= 120) {
			inRangeToHear = true;
			//Debug.Log ("In Range");
			if (dist <= 20) {
				inRangeToInt = true;
				triggerNarrText ();
				Debug.Log ("Close enough to interact");
			} else {
				inRangeToInt = false;
			}

		} else {
			inRangeToHear = false;
			//Debug.Log ("Not In Range");

		}


	}


	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject == player)
		{
			inLOS = true;
			//Debug.Log ("In LOS");
		}

	}
	void OnTriggerStay(Collider other){
		if(other.gameObject == player)
		{
			inLOS = true;
			Debug.Log ("In LOS");


		}

	}
	void OnTriggerExit(Collider other){
		if(other.gameObject == player)
		{
			inLOS = false;
			tutorialText.SetActive (false);
			tutorialBox.SetActive (false);
			//Debug.Log ("Not In LOS");

		}
	}

	IEnumerator waitForDialogueTrigger (float x){
		yield return new WaitForSeconds (x);
		rt.sizeDelta = new Vector2(100, 23);
		posInDialogue++;
	}


	void fillNarrativeString(){
		narrText [0] = "Hey! Calimari brain! Come over here and help an old geezer out!";
		narrText [1] = "If you want me to start moving the conversation forward... press something called... [E]? What a strange thing to say.";
		narrText [2] = "Lovely, you are smart! Now come closer and break me out of here. Try picking up one of those boxes [Hold LMB] and tossing it at the glass [While holding LMB, RMB].";
	}
	void triggerNarrText(){
		narrTextTrigger [posInDialogue+1] = true;

	}

	//Do break glass scenario, if break glass increment the dialogue update the dialogue text to the next one, and print it
	// out again.




}
