using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class TutorialObject : MonoBehaviour {

	public bool debugStatements = true;
	public GameObject tutorialText;
	private Text tutText;
	//private Text textHolder = GetComponent<Text>();
	public GameObject player;
	private GameObject egg;
	public GameObject tutorialBox;
	public GameObject tutOrigin;
	public GameObject pressEText;
	private GameObject uiQuestZero;
	private GameObject uiQuestOne;
	private GameObject uiQuestTwo;
	private GameObject uiQuestThree;
	private GameObject uiQuestFour;
	private GameObject uiQuestFive;
	private GameObject uiQuestSix;
	private GameObject uiMissionText;
	private GameObject uiMissionBox;
	private GameObject brokenGlassTube;
	private GameObject incompleteMissionText;
	private GameObject completeMissionText;
	private GameObject returnToBorkText;
	private GameObject borkObjectAttached;
	private GameObject borkObjectUnattached;
	private GameObject plateWithScript;
	private GameObject plateNoScript;
	private Mesh squidMesh;
	private Mesh tempMesh;
	private Mesh eggMesh;
	private bool somethingToSay;
	private bool dialogStarted = false;
	private bool inLOS = false;
	private bool inRangeToHear = false;
	private bool inRangeToInt = false;
	private bool inLOS_inRange = false;
	public float letterPause;
	public string[] narrText = new string[200];
	public bool[] narrTextTrigger = new bool[200];
	public int posInDialogue;
	private int posInDialogueHolder;
	private bool firstDialogueTrigger = false;
	private bool playedStamTT = false;
	private bool tooltipInProgress = false;
	public bool isEgg = true;
	public bool hasGrabbed = false;
	public bool gateIsOpen = false;
	public bool hasGrabbedCheck = false;
	private bool borkAttached = false;
	private bool acceptQuest = false;
	private bool questZeroComplete = false;
	private bool questOneComplete = false;
	private bool questTwoComplete = false;
	private bool questThreeComplete = false;
	private bool questFourComplete = false;
	private bool questFiveComplete = false;
	private bool questSixComplete = false;
	private bool inCavern = false;
	private bool tempBool;
	public bool isGlassBroken;
	private bool hasPressedEveryKey;
	private bool hasInked;
	private bool hasSped;
	private bool hasSanic;
	private int dist;
	private int distToInteract;
	private bool w;
	private bool s;
	private bool a;
	private bool d;
	private bool r;
	private bool f;


	void Start(){
		fillNarrativeString ();
		tutText = tutorialText.GetComponent<Text> ();
		uiQuestZero = GameObject.Find ("QuestZero");
		uiQuestZero.SetActive (false);
		uiQuestOne = GameObject.FindGameObjectWithTag ("uiQuestOne");
		uiQuestOne.SetActive (false);
		uiQuestTwo = GameObject.FindGameObjectWithTag ("uiQuestTwo");
		uiQuestTwo.SetActive (false);
		uiQuestThree = GameObject.FindGameObjectWithTag ("uiQuestThree");
		uiQuestThree.SetActive (false);
		uiQuestFour = GameObject.Find ("QuestFour");
		uiQuestFour.SetActive (false);
		uiQuestFive = GameObject.Find ("QuestFive");
		uiQuestFive.SetActive (false);
		uiQuestSix = GameObject.Find ("QuestSix");
		uiQuestSix.SetActive (false);
		uiMissionText = GameObject.FindGameObjectWithTag ("uiMissionText");
		uiMissionText.SetActive (false);
		uiMissionBox = GameObject.FindGameObjectWithTag ("uiQuestBox");
		uiMissionBox.SetActive (false);
		borkObjectAttached = GameObject.FindGameObjectWithTag ("borkAttached");
		borkObjectAttached.SetActive (false);
		borkObjectUnattached = GameObject.FindGameObjectWithTag ("borkunattached");
		incompleteMissionText = GameObject.FindGameObjectWithTag ("incomplete");
		incompleteMissionText.SetActive (false);
		completeMissionText = GameObject.FindGameObjectWithTag ("complete");
		completeMissionText.SetActive (false);
		returnToBorkText = GameObject.FindGameObjectWithTag ("QuestReturn");
		returnToBorkText.SetActive (false);
		player = GameObject.FindGameObjectWithTag("Player");
		egg = GameObject.FindGameObjectWithTag ("krakenEgg");
		plateWithScript = GameObject.Find ("pressurewithscript");
		plateWithScript.SetActive (false);
		plateNoScript = GameObject.Find ("pressurenoscript");
		tutorialText.SetActive (false);
		tutorialBox.SetActive (false);
	}


	void Update ()
	{
		keyCheck ();
		//Debug.Log (posInDialogue);
		inCavern = GameObject.Find("Cavern").GetComponent<LocationTracking>().here;
		hasInked = GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().firstTimeInking;
		hasSped = GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().firstTimeSpeeding;
		hasSanic = GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().firstTimeSanic;
		if (!borkAttached) {
			distanceNotify ();
		} else {
			inRangeToHear = false;
			inLOS = false;
		}
		if (hasPressedEveryKey && inRangeToInt && acceptQuest && !questZeroComplete) {
			acceptQuest = false;
			questZeroComplete = true;
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestZero.SetActive (false);
			narrTextTrigger[posInDialogue] = true;
			plateNoScript.SetActive (false);
			plateWithScript.SetActive (true);
		}

		if (isGlassBroken && acceptQuest && !questOneComplete) {
			acceptQuest = false;
			questOneComplete = true;
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestOne.SetActive (false);
			narrTextTrigger[posInDialogue] = true;
			plateNoScript.SetActive (false);
			plateWithScript.SetActive (true);
		}
		if (gateIsOpen && acceptQuest && !questTwoComplete && questOneComplete) {
			acceptQuest = false;
			questTwoComplete = true;
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestTwo.SetActive (false);
			narrTextTrigger [posInDialogue] = true;
		}
		if (inCavern && acceptQuest && !questThreeComplete && questTwoComplete) {
			acceptQuest = false;
			questThreeComplete = true;
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestThree.SetActive (false);
			narrTextTrigger [posInDialogue] = true;
		}
		if (hasInked && acceptQuest && !questFourComplete && questThreeComplete) {
			acceptQuest = false;
			questFourComplete = true;
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestFour.SetActive (false);
			narrTextTrigger [posInDialogue] = true;
		}
		if (hasSped && acceptQuest && !questFiveComplete && questFourComplete) {
			acceptQuest = false;
			questFiveComplete = true;
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestFive.SetActive (false);
			narrTextTrigger [posInDialogue] = true;
		}
		if (hasSanic && acceptQuest && !questSixComplete && questFiveComplete) {
			acceptQuest = false;
			questSixComplete = true;
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestSix.SetActive (false);
			narrTextTrigger [posInDialogue] = true;
		}

		if (isEgg) {
			if (!dialogStarted) {
				dialogStarted = true;
				StartCoroutine (waitForFirstDialogueTrigger (1f));
			}
		}
		// Quest Zero
		if (posInDialogue == 1 && !acceptQuest && !questZeroComplete) {
			acceptQuest = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestZero.SetActive (true);
			incompleteMissionText.SetActive (true);
		}
		//complete quest zero
		if (posInDialogue == 2) {
			//borkAttached = true;
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestZero.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			//borkObjectAttached.SetActive (true);
			//borkObjectAttached.GetComponent<NPCHighlighting>().changeMatToHL ();
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			//borkObjectUnattached.SetActive (false);
		}


		//Quest one
		if (posInDialogue == 3 && !acceptQuest && !questOneComplete) {
			acceptQuest = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestOne.SetActive(true);
			incompleteMissionText.SetActive (true);
		}
		//Complete quest one
		if (posInDialogue == 4) {
			borkAttached = true;
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestOne.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			borkObjectAttached.SetActive (true);
			//borkObjectAttached.GetComponent<NPCHighlighting>().changeMatToHL ();
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			borkObjectUnattached.SetActive (false);
		}
		//Quest Two
		Debug.Log(acceptQuest + "," + questTwoComplete);
		if (posInDialogue == 5 && !acceptQuest && !questTwoComplete) {
			acceptQuest = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestTwo.SetActive (true);
			incompleteMissionText.SetActive (true);
			pressEText.SetActive (false);
			//borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToNml ();
		} else if (posInDialogue == 5 && acceptQuest && !questTwoComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToNml ();
		} else if (posInDialogue == 5 && !acceptQuest && questTwoComplete) {
			Debug.Log ("Calling this one");
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
			//borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToNml ();
		}
		//Complete Quest Two
		if (posInDialogue == 6) {
			
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestTwo.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (true);
			//borkObjectAttached.GetComponent<NPCHighlighting>().changeMatToHL ();
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		//Quest Three
		if (posInDialogue == 7 && !acceptQuest && !questThreeComplete) {
			acceptQuest = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestThree.SetActive (true);
			completeMissionText.SetActive (false);
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (false);
			//borkObjectAttached.GetComponent<NPCHighlighting>().changeMatToNml ();
		}else if (posInDialogue == 7 && acceptQuest && !questThreeComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		}
		else if (posInDialogue == 7 && !acceptQuest && questThreeComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
		}
		//Complete Quest Three
		if (posInDialogue == 8) {
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestFour.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (true);
			//borkObjectAttached.GetComponent<NPCHighlighting>().changeMatToHL ();
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		//Quest Four
		if (posInDialogue == 9 && !acceptQuest && !questFourComplete) {
			acceptQuest = true;
			GameObject.FindGameObjectWithTag("Player").GetComponent<Abilities>().inkIcon.enabled = true;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().abilities [1] = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestFour.SetActive (true);
			completeMissionText.SetActive (false);
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (false);
			//borkObjectAttached.GetComponent<NPCHighlighting>().changeMatToNml ();
		}else if (posInDialogue == 9 && acceptQuest && !questFourComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		}
		else if (posInDialogue == 9 && !acceptQuest && questFourComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
		}
		//Complete Quest Four
		if (posInDialogue == 10) {

			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestFour.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (true);
			//borkObjectAttached.GetComponent<NPCHighlighting>().changeMatToHL ();
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		//Quest Five
		if (posInDialogue == 11 && !acceptQuest && !questFiveComplete) {
			acceptQuest = true;
			GameObject.FindGameObjectWithTag("Player").GetComponent<Abilities>().speedIcon.enabled = true;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().abilities [0] = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestFive.SetActive (true);
			completeMissionText.SetActive (false);
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (false);
			//borkObjectAttached.GetComponent<NPCHighlighting>().changeMatToNml ();
		}else if (posInDialogue == 11 && acceptQuest && !questFiveComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		}
		else if (posInDialogue == 11 && !acceptQuest && questFiveComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
		}
		//Complete Quest Five
		if (posInDialogue == 12) {

			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestFive.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (true);
			//borkObjectAttached.GetComponent<NPCHighlighting>().changeMatToHL ();
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		if (posInDialogue == 13 && !acceptQuest && !questSixComplete) {
			acceptQuest = true;
			GameObject.FindGameObjectWithTag("Player").GetComponent<Abilities>().currentIcon.enabled = true;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().abilities [2] = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestSix.SetActive (true);
			completeMissionText.SetActive (false);
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (false);
			//borkObjectAttached.GetComponent<NPCHighlighting>().changeMatToNml ();
		}else if (posInDialogue == 13 && acceptQuest && !questSixComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		}
		else if (posInDialogue == 13 && !acceptQuest && questSixComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
		}
	

		if (inLOS && inRangeToHear) {
			inLOS_inRange = true;
		} else {
			inLOS_inRange = false;
		}
		//Before bork is attached
		if (inRangeToHear && firstDialogueTrigger && !borkAttached) {
			if (!acceptQuest) {
				tutorialText.SetActive (true);
				tutorialBox.SetActive (true);
			} else {
				tutorialText.SetActive (false);
				tutorialBox.SetActive (false);
			}
			//if the current dialogue is active and hasnt been spelled out yet, spell it out
			if (narrTextTrigger [posInDialogue]) {
				if (posInDialogue == 3 && acceptQuest && !questOneComplete) {
					narrTextTrigger [posInDialogue] = false;
				} else if (posInDialogue == 1 && acceptQuest && !questZeroComplete) {
						narrTextTrigger [posInDialogue] = false;
				} else if (posInDialogue == 5 && acceptQuest && !questTwoComplete) {
					narrTextTrigger [posInDialogue] = false;
				} else if (posInDialogue == 7 && acceptQuest && !questThreeComplete) {
					narrTextTrigger [posInDialogue] = false;
				} else {
					tutText.text = "";
					narrTextTrigger [posInDialogue] = false;
					StartCoroutine (spellItOut ());
				}
			}
			if (isEgg) {
				eggECaller ();
			} else if (Input.GetKeyDown ("e") && inRangeToInt && !acceptQuest && narrTextTrigger [posInDialogue + 1] && !questOneComplete) {
				posInDialogue++;
			} else if (Input.GetKeyDown ("e") && !borkAttached && !acceptQuest && narrTextTrigger [posInDialogue + 1] && questOneComplete) {
				//Debug.Log ("calling this one now");
				posInDialogue++;
			} else if (Input.GetKeyDown ("e") && borkAttached && !acceptQuest && narrTextTrigger [posInDialogue + 1] && questOneComplete) {
				posInDialogue++;
			}
			//Once Bork is attached use this
		} else if (borkAttached) {
			if (!acceptQuest) {
				tutorialText.SetActive (true);
				tutorialBox.SetActive (true);
			} else {
				tutorialText.SetActive (false);
				tutorialBox.SetActive (false);
			}
			if (narrTextTrigger [posInDialogue]) {
				if (posInDialogue == 3 && acceptQuest && !questOneComplete) {
					narrTextTrigger [posInDialogue] = false;
				} else if (posInDialogue == 5 && acceptQuest && !questTwoComplete) {
					narrTextTrigger [posInDialogue] = false;
				} else if (posInDialogue == 7 && acceptQuest && !questThreeComplete) {
					narrTextTrigger [posInDialogue] = false;
				} else if (posInDialogue == 9 && acceptQuest && !questFourComplete) {
					narrTextTrigger [posInDialogue] = false;
				}
				else if (posInDialogue == 11 && acceptQuest && !questFiveComplete) {
					narrTextTrigger [posInDialogue] = false;
				}
				else if (posInDialogue == 13 && acceptQuest && !questSixComplete) {
					narrTextTrigger [posInDialogue] = false;
				}
				else {
					tutText.text = "";
					narrTextTrigger [posInDialogue] = false;
					StartCoroutine (spellItOut ());
				}
			}
			else if (Input.GetKeyDown ("e") && borkAttached && !acceptQuest && narrTextTrigger [posInDialogue + 1] && !questTwoComplete) {
				posInDialogue++;
			}
			else if (Input.GetKeyDown ("e") && borkAttached && !acceptQuest && narrTextTrigger [posInDialogue + 1] && questTwoComplete) {
				posInDialogue++;
			}
			else if (Input.GetKeyDown ("e") && borkAttached && !acceptQuest && narrTextTrigger [posInDialogue + 1] && questThreeComplete) {
				posInDialogue++;
			}
			else if (Input.GetKeyDown ("e") && borkAttached && !acceptQuest && narrTextTrigger [posInDialogue + 1] && questFourComplete) {
				posInDialogue++;
			}
			else if (Input.GetKeyDown ("e") && borkAttached && !acceptQuest && narrTextTrigger [posInDialogue + 1] && questFiveComplete) {
				posInDialogue++;
			}
			else if (Input.GetKeyDown ("e") && borkAttached && !acceptQuest && narrTextTrigger [posInDialogue + 1] && questSixComplete) {
				posInDialogue++;
			}

		}
		else  {
			tutorialText.SetActive (false);
			tutorialBox.SetActive (false);

		}

	}

	void distanceNotify(){
		dist = (int)Vector3.Distance (player.transform.position, tutOrigin.transform.position);
		if (dist <= 150) {
			inRangeToHear = true;
			if (dist <= 20) {
				inRangeToInt = true;
				GameObject.FindWithTag("BorkNPCLocation").GetComponent<NPCHighlighting>().changeMatToHL ();
				if (!acceptQuest)
					pressEText.SetActive (true);
				else
					pressEText.SetActive (false);
			} else {
				pressEText.SetActive (false);
				inRangeToInt = false;
				GameObject.FindWithTag("BorkNPCLocation").GetComponent<NPCHighlighting>().changeMatToNml();
			}

		} else {
			inRangeToHear = false;
		}
	}


	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject == player)
		{
			inLOS = true;
		}

	}
	void OnTriggerStay(Collider other){
		if(other.gameObject == player)
		{
			inLOS = true;
		}

	}
	void OnTriggerExit(Collider other){
		if(other.gameObject == player)
		{
			inLOS = false;
			tutorialText.SetActive (false);
			tutorialBox.SetActive (false);
		}
	}
	IEnumerator waitForFirstDialogueTrigger (float x){
		yield return new WaitForSeconds (x);
		firstDialogueTrigger = true;
		posInDialogue = 0;
	}

	void eggECaller(){
		if (Input.GetKeyDown ("e") && narrTextTrigger [posInDialogue + 1] && isEgg) {
			posInDialogue++;
			isEgg = false;
			egg.SetActive (false);
		}
	}

	void keyCheck(){
		if (Input.GetKeyDown ("w")) {
			w = true;
		}
		if (Input.GetKeyDown ("a")) {
			a = true;
		}
		if (Input.GetKeyDown ("s")) {
			s = true;
		}
		if (Input.GetKeyDown ("d")) {
			d = true;
		}
		if (Input.GetKeyDown ("r")) {
			r = true;
		}
		if (Input.GetKeyDown ("f")) {
			f = true;
		}
		if(w && a && s && d && r && f){
			hasPressedEveryKey = true;
		}

	}
		

	IEnumerator spellItOut(){
		foreach (char letter in narrText[posInDialogue].ToCharArray()) {
			if(Input.GetKeyDown("e") && !tooltipInProgress){
				break;
			}
			tutText.text += letter;
			yield return new WaitForSeconds (letterPause);
		}
		tutText.text = "";
		tutText.text = narrText [posInDialogue];
		narrTextTrigger [posInDialogue + 1] = true;
	}



	void fillNarrativeString(){
		narrTextTrigger [0] = true;
		narrText [0] = "Hey it would be very helpful if you were to hatch sometime soon. [E]";
		narrText [1] = "Bork: Oh you are intelligent, and... my goodness you are interesting looking. Well... Please break me out of this strange prison, someone left the volcano on and you need to turn it off. [E]";
		narrText [2] = "Bork: I suggest finding a box or book, picking it up [Hold LMB], and tossing it at this glass [While holding LMB, press RMB]. [E]";
		narrText [3] = "Bork: Oh how charming of you to throw glass everywhere. Well, let's get to it I suppose. [E]";
		narrText [4] = "Bork: Now on to opening that blasted gate. [E]";
		narrText [5] = "Bork: How nice, let's leave this decrepit place. [E]";
		narrText [6] = "Bork: Let's move into the cavern, you are a weak infant and there are some things you need to learn. [E]";
		narrText [7] = "Bork: Ah, it's just as a I remember it from twenty minutes ago... turquoise.  [E]";
		narrText [8] = "Bork: Behold, I shall now unlock your inking ability! You now feel different. Activate your Inking ability [1] and use it [Space]. [E]";
		narrText [9] = "Bork: Very good, you can use Ink to stop pursuing fish in their tracks. [E]";
		narrText [10] = "Bork: Now let's unlock your movement ability [2] and use it [Space]. [E]";
		narrText [11] = "Bork: Speed can be very useful to make a quick getaway from pursuing fish. [E]";
		narrText [12] = "Bork: Next up will be your sonic wave, this ability [3] will confuse fish and compel them to swim away from you. Try it out now [Space]. [E]";

	}




}
