using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class TutorialObject : MonoBehaviour {

	public bool debugStatements = true;
	private int minimumDist = 20;
	private int maximumDist = 120;
	public GameObject tutorialText;
	private Text tutText;
	//private Text textHolder = GetComponent<Text>();
	public GameObject player;
	private GameObject egg;
	public GameObject tutorialBox;
	public GameObject tutOrigin;
	public GameObject pressEText;
	private GameObject uiQuestOne;
	private GameObject uiMissionText;
	RectTransform rt;
	private Mesh squidMesh;
	private Mesh tempMesh;
	private Mesh eggMesh;
	private bool dialogStarted = false;
	private bool inLOS = false;
	private bool inRangeToHear = false;
	private bool inRangeToInt = false;
	private bool inLOS_inRange = false;
	public float letterPause = 0.1f;
	public string[] narrText = new string[200];
	public bool[] narrTextTrigger = new bool[200];
	private int posInDialogue;
	private int posInDialogueHolder;
	private bool firstDialogueTrigger = false;
	private bool secondDialogueTrigger = false;
	private bool canPressE = true;
	public bool isEgg = true;
	public bool hasGrabbed = false;
	public bool hasGrabbedCheck = false;
	private bool acceptQuest = false;
	private int dist;
	private int distToInteract;
	private int clampedDist;


	void Start(){
		fillNarrativeString ();
		tutText = tutorialText.GetComponent<Text> ();
		uiQuestOne = GameObject.FindGameObjectWithTag ("uiQuestOne");
		uiMissionText = GameObject.FindGameObjectWithTag ("uiMissionText");
		player = GameObject.FindGameObjectWithTag("Player");
		egg = GameObject.FindGameObjectWithTag ("krakenEgg");
		tutorialText.SetActive (false);
		tutorialBox.SetActive (false);

		rt = tutorialText.GetComponent<RectTransform> ();
		//textHolder.text = "";
	}


	void Update ()
	{
		
		if (isEgg) {
			if (!dialogStarted) {
				dialogStarted = true;
				StartCoroutine (waitForFirstDialogueTrigger (2f));

			}

		}
		if (inLOS && inRangeToHear) {
			inLOS_inRange = true;
		} else {
			inLOS_inRange = false;
		}
		if (inLOS_inRange && firstDialogueTrigger) {
			Debug.Log ("trigger one");
			if (!acceptQuest) {
				tutorialText.SetActive (true);
				tutorialBox.SetActive (true);
			} else {
				tutorialText.SetActive (false);
				tutorialBox.SetActive (false);
			}

			if (narrTextTrigger [posInDialogue]) {
				tutText.text = "";
				StartCoroutine (spellItOut ());
				narrTextTrigger [posInDialogue] = false;
			}
			if (hasGrabbed && !hasGrabbedCheck) {
				posInDialogueHolder = posInDialogue;
				narrTextTrigger [100] = true;
				posInDialogue = 100;
				hasGrabbed = false;
				hasGrabbedCheck = true;
			}
			if (Input.GetKeyDown ("e") && narrTextTrigger [posInDialogue + 1] && isEgg && posInDialogue == 0) {
				posInDialogue++;
			}
			//Player breaks out of egg
			if (Input.GetKeyDown ("e") && narrTextTrigger [posInDialogue + 1] && isEgg && posInDialogue == 1) {
				isEgg = false;
				egg.SetActive (false);
				//rt.sizeDelta = new Vector2(100, 23);
				posInDialogue++;
			}
			if(Input.GetKeyDown("e") && inRangeToInt && narrTextTrigger[posInDialogue+1] && !isEgg && !acceptQuest ){
				posInDialogue++;
				//Debug.Log (posInDialogue);
				//rt.sizeDelta = new Vector2(100, 23);
			}
			//Accepted first quest
			//When quest completed, be sure to set uiquestone to inactive and uimissiontext = completed
			if (posInDialogue == 5) {
				uiMissionText.SetActive (true);
				uiQuestOne.SetActive (false);
				tutorialText.SetActive (false);
				tutorialBox.SetActive (false);
				acceptQuest = true;
			}
		} else {
			tutorialText.SetActive (false);
			tutorialBox.SetActive (false);

		}
		distanceNotify ();
		Debug.Log (posInDialogue + ", " +  narrTextTrigger[posInDialogue]);


	}

	void distanceNotify(){
		dist = (int)Vector3.Distance (player.transform.position, tutOrigin.transform.position);
		clampedDist = Mathf.Clamp(dist, minimumDist, maximumDist);
	
		if (dist <= 120) {
			inRangeToHear = true;
			//Debug.Log ("In Range");
			if (dist <= 20) {
				inRangeToInt = true;
				if(!acceptQuest)
					pressEText.SetActive (true);
				//Debug.Log ("Close enough to interact");
				GameObject.FindWithTag("BorkNPCLocation").GetComponent<NPCHighlighting>().changeMatToHL ();
				//GetComponent<NPCHighlighting>().changeMatToHL ();

			} else {
				pressEText.SetActive (false);
				inRangeToInt = false;
				GameObject.FindWithTag("BorkNPCLocation").GetComponent<NPCHighlighting>().changeMatToNml();
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
			//Debug.Log ("In LOS");


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
	IEnumerator waitForFirstDialogueTrigger (float x){
		yield return new WaitForSeconds (x);
		firstDialogueTrigger = true;
		//rt.sizeDelta = new Vector2(100, 23);
		posInDialogue = 0;
		//triggerNarrText ();
		//StartCoroutine (waitForDialogueTrigger (10f));
	}

	IEnumerator waitForDialogueTrigger (float x){
		yield return new WaitForSeconds (x);
		//rt.sizeDelta = new Vector2(100, 23);
		secondDialogueTrigger = true;
		posInDialogue++;
		triggerNarrText ();
		//StartCoroutine (waitForInteraction (6f));
	}

	IEnumerator waitForInteraction (float x){
		yield return new WaitForSeconds (x);
		canPressE = true;
	}

	IEnumerator spellItOut(){
		foreach (char letter in narrText[posInDialogue].ToCharArray()) {
			tutText.text += letter;
			yield return new WaitForSeconds (letterPause);
		}
		narrTextTrigger [posInDialogue + 1] = true;
	}



	void fillNarrativeString(){
		narrTextTrigger [0] = true;
		narrText [0] = "Hey, my lil' Krakenling, it would be very helpful if you were to hatch sometime soon. [E]";

		narrText [1] = "Look... we don't have all day, we have important work to attend to and this container is getting cramped and stuffy. Shake a tentacle and break out of that prison of yours. [E]";
		//narrTextTrigger [1] = true;
		narrText [2] = "Oh thank goodness you are relatively intelligent. My name is Bork the Delightful, now come yonder and help me out of here. [E]";
		//narrTextTrigger [2] = true;
		narrText [3] = "Now that I can see you... my goodness you are interesting looking. Well regardless of your looks, we do not have much time to chat at the moment. Thems sinister fish comin' back soon. Please break me out of here, and I will bestow my knowledge upon you. [E]";
		//narrTextTrigger [3] = true;
		narrText[4] = "Try picking up one of those boxes [Hold LMB] and tossing it at this blasted glass [While holding LMB, RMB]. [E]";
		//narrTextTrigger [4] = false;


		//This shit is tooltip stuff
		narrText [100] = "Oh look, when you grab something your stamina drops. Oh also look, your stamina regenerates on its own. How fascinatingly bland your species is, isn't it?";
	}
	//Pos 3 = first quest - break bork out.
	void triggerNarrText(){
		narrTextTrigger [posInDialogue+1] = true;
	}

	//Do break glass scenario, if break glass increment the dialogue update the dialogue text to the next one, and print it
	// out again.




}
