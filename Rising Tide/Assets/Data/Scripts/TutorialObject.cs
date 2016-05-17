﻿using UnityEngine;
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
	private GameObject uiQuestSeven;
	private GameObject uiQuestEight;
	private GameObject uiQuestNine;
	private GameObject uiQuestTen;
	private GameObject uiQuestEleven;
	private GameObject uiQuestTwelve;
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
	private GameObject chadLocOrigin;
	private Mesh squidMesh;
	private Mesh tempMesh;
	private Mesh eggMesh;
	private bool somethingToSay;
	private bool dialogStarted = false;
	private bool inLOS = false;
	private bool inRangeToHear = false;
	private bool inRangeToInt = false;

	private bool inRangeToHearChad = false;
	private bool inRangeToIntChad = false;

	public float letterPause;
	public string[] narrText = new string[200];
	public bool[] narrTextTrigger = new bool[200];
	public int posInDialogue;
	private int posInDialogueHolder;
	private bool firstDialogueTrigger = false;
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
	private bool questSevenComplete = false;
	private bool questEightComplete = false;
	private bool questNineComplete = false;
	private bool questTenComplete = false;
	private bool questElevenComplete = false;
	private bool questTwelveComplete = false;
	private bool inCavern = false;
	private bool tempBool;
	public bool isGlassBroken;
	private bool hasPressedEveryKey;
	private bool hasInked;
	private bool hasSped;
	private bool hasSanic;
	private bool hasEmp;
	private bool hasEnteredTemple;
	private bool hasEnteredReef;
	private bool hasEnteredVolcVicinity;
	private bool hasSpokenToChadOne;
	private bool inRangeToSeeChad;
	private int dist;
	private int distToInteract;
	private bool w;
	private bool s;
	private bool a;
	private bool d;
	private bool r;
	private bool f;

	private bool turtleTalk = false;


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
		uiQuestSeven = GameObject.Find ("QuestSeven");
		uiQuestSeven.SetActive (false);
		uiQuestEight = GameObject.Find ("QuestEight");
		uiQuestEight.SetActive (false);
		uiQuestNine = GameObject.Find ("QuestNine");
		uiQuestNine.SetActive (false);
		uiQuestTen = GameObject.Find ("QuestTen");
		uiQuestTen.SetActive (false);
		uiQuestEleven = GameObject.Find ("QuestEleven");
		uiQuestEleven.SetActive (false);
		uiQuestTwelve = GameObject.Find ("QuestTwelve");
		uiQuestTwelve.SetActive (false);
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
		chadLocOrigin = GameObject.Find ("chadLocationObject");
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
		if (turtleTalk) {
			distanceNotifyChad ();
		}
		if (!inRangeToSeeChad && inRangeToHearChad) {
			inRangeToSeeChad = true;
		}
		//Debug.Log (posInDialogue);
		inCavern = GameObject.Find("Cavern").GetComponent<LocationTracking>().here;
		hasEnteredTemple = GameObject.Find("TempleLoc").GetComponent<LocationTracking>().here;
		hasEnteredReef = GameObject.Find("ReefLoc").GetComponent<LocationTracking>().here;
		hasEnteredVolcVicinity = GameObject.Find("VolcLoc").GetComponent<LocationTracking>().here;
		hasInked = GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().firstTimeInking;
		hasSped = GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().firstTimeSpeeding;
		hasSanic = GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().firstTimeSanic;
		hasEmp = GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().firstTimeEmp;
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
		if (hasEmp && acceptQuest && !questSevenComplete && questSixComplete) {
			acceptQuest = false;
			questSevenComplete = true;
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestSeven.SetActive (false);
			narrTextTrigger [posInDialogue] = true;
		}
		if (hasEnteredTemple && acceptQuest && !questEightComplete && questSevenComplete) {
			acceptQuest = false;
			questEightComplete = true;
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestEight.SetActive (false);
			narrTextTrigger [posInDialogue] = true;
		}
		if (hasEnteredReef && acceptQuest && !questNineComplete && questEightComplete) {
			acceptQuest = false;
			questNineComplete = true;
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestNine.SetActive (false);
			narrTextTrigger [posInDialogue] = true;
		}
		if (hasEnteredVolcVicinity && acceptQuest && !questTenComplete && questNineComplete) {
			acceptQuest = false;
			questTenComplete = true;
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestTen.SetActive (false);
			narrTextTrigger [posInDialogue] = true;
		}
		if (inRangeToSeeChad && acceptQuest && !questElevenComplete && questTenComplete) {
			acceptQuest = false;
			questElevenComplete = true;
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestEleven.SetActive (false);
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
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			borkObjectUnattached.SetActive (false);
		}
		//Quest Two
		if (posInDialogue == 5 && !acceptQuest && !questTwoComplete) {
			acceptQuest = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestTwo.SetActive (true);
			incompleteMissionText.SetActive (true);
			pressEText.SetActive (false);
		} else if (posInDialogue == 5 && acceptQuest && !questTwoComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
		} else if (posInDialogue == 5 && !acceptQuest && questTwoComplete) {
			Debug.Log ("Calling this one");
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);

		}
		//Complete Quest Two
		if (posInDialogue == 6) {
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestTwo.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (true);
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
		//Quest Six
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
		//Complete Quest Six
		if (posInDialogue == 14) {

			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestSix.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (true);
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		//Quest Seven
		if (posInDialogue == 15 && !acceptQuest && !questSevenComplete) {
			acceptQuest = true;
			GameObject.FindGameObjectWithTag("Player").GetComponent<Abilities>().currentIcon.enabled = true;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().abilities [3] = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestSeven.SetActive (true);
			completeMissionText.SetActive (false);
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (false);
		}else if (posInDialogue == 15 && acceptQuest && !questSevenComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		}
		else if (posInDialogue == 15 && !acceptQuest && questSevenComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
		}
		//Complete Quest Seven
		if (posInDialogue == 16) {

			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestSeven.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (true);
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		//Quest 8
		if (posInDialogue == 17 && !acceptQuest && !questEightComplete) {
			acceptQuest = true;
			GameObject.FindGameObjectWithTag("Player").GetComponent<Abilities>().currentIcon.enabled = true;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().abilities [3] = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestEight.SetActive (true);
			completeMissionText.SetActive (false);
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (false);
		}else if (posInDialogue == 17 && acceptQuest && !questEightComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		}
		else if (posInDialogue == 17 && !acceptQuest && questEightComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
		}
		//Complete Quest Eight
		if (posInDialogue == 18) {
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestEight.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (true);
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		//Dialogue
		if (posInDialogue == 19) {
			pressEText.SetActive (true);
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		//Quest Nine
		if (posInDialogue == 20 && !acceptQuest && !questNineComplete) {
			acceptQuest = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestNine.SetActive (true);
			completeMissionText.SetActive (false);
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (false);
		}else if (posInDialogue == 20 && acceptQuest && !questNineComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		}
		else if (posInDialogue == 20 && !acceptQuest && questNineComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
		}
		//Complete Quest Nine
		if (posInDialogue == 21) {
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestNine.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (true);
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		//Quest Ten
		if (posInDialogue == 22 && !acceptQuest && !questTenComplete) {
			acceptQuest = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestTen.SetActive (true);
			completeMissionText.SetActive (false);
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (false);
		}else if (posInDialogue == 22 && acceptQuest && !questTenComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		}
		else if (posInDialogue == 22 && !acceptQuest && questTenComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
		}
		//Complete Quest Ten
		if (posInDialogue == 23) {
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestTen.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (true);
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		//Quest Eleven
		if (posInDialogue == 24 && !acceptQuest && !questElevenComplete) {
			acceptQuest = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestEleven.SetActive (true);
			completeMissionText.SetActive (false);
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (false);

			turtleTalk = true;
		}else if (posInDialogue == 24 && acceptQuest && !questElevenComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		}
		else if (posInDialogue == 24 && !acceptQuest && questElevenComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
		}
		//Quest Twelve
		if (posInDialogue == 25 && !acceptQuest && !questTwelveComplete) {
			acceptQuest = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestTwelve.SetActive (true);
			completeMissionText.SetActive (false);
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (false);
			turtleTalk = true;
		}else if (posInDialogue == 25 && acceptQuest && !questTwelveComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		}
		else if (posInDialogue == 25 && !acceptQuest && questTwelveComplete) {
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
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
		} else if (borkAttached && !turtleTalk) {
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
				else if (posInDialogue == 15 && acceptQuest && !questSevenComplete) {
					narrTextTrigger [posInDialogue] = false;
				}
				else if (posInDialogue == 17 && acceptQuest && !questEightComplete) {
					narrTextTrigger [posInDialogue] = false;
				}
				else if (posInDialogue == 20 && acceptQuest && !questNineComplete) {
					narrTextTrigger [posInDialogue] = false;
				}
				else if (posInDialogue == 22 && acceptQuest && !questTenComplete) {
					narrTextTrigger [posInDialogue] = false;
				}
				else if (posInDialogue == 24 && acceptQuest && !questElevenComplete) {
					narrTextTrigger [posInDialogue] = false;
				}
				else {
					tutText.text = "";
					narrTextTrigger [posInDialogue] = false;
					StartCoroutine (spellItOut ());
				}
			}
			else if (Input.GetKeyDown ("e") && borkAttached && !acceptQuest && narrTextTrigger [posInDialogue + 1]) {
				posInDialogue++;
			}

		} else if (borkAttached && turtleTalk) {
			if (!acceptQuest) {
				tutorialText.SetActive (true);
				tutorialBox.SetActive (true);
			} else {
				tutorialText.SetActive (false);
				tutorialBox.SetActive (false);
			}
			if (narrTextTrigger [posInDialogue]) {
				if (posInDialogue == 24 && acceptQuest && !questElevenComplete) {
					narrTextTrigger [posInDialogue] = false;
				}else if (posInDialogue == 25 && acceptQuest && !questTwelveComplete) {
					narrTextTrigger [posInDialogue] = false;
				}
				else {
					tutText.text = "";
					narrTextTrigger [posInDialogue] = false;
					StartCoroutine (spellItOut ());
				}
			}
			else if (Input.GetKeyDown ("e") && inRangeToIntChad && !acceptQuest && narrTextTrigger [posInDialogue + 1]) {
				posInDialogue++;
			}
			else if (Input.GetKeyDown ("e") && !acceptQuest && narrTextTrigger [posInDialogue + 1]) {
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

	void distanceNotifyChad(){
		dist = (int)Vector3.Distance (player.transform.position, chadLocOrigin.transform.position);
		if (dist <= 150) {
			inRangeToHearChad = true;
			if (dist <= 20) {
				inRangeToIntChad = true;
				chadLocOrigin.GetComponent<NPCHighlighting>().changeMatToHL ();
				if (!acceptQuest)
					pressEText.SetActive (true);
				else
					pressEText.SetActive (false);
			} else {
				pressEText.SetActive (false);
				inRangeToIntChad = false;
				chadLocOrigin.GetComponent<NPCHighlighting>().changeMatToNml();
			}

		} else {
			inRangeToHearChad = false;
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
		narrText [13] = "Bork: The sonic wave can be very useful when being pursued by large groups of enemies. [E]";
		narrText [14] = "Bork: Your final ability I shall unlock is the EMP, activate it [4] and use it[Space]. [E]";
		narrText [15] = "Bork: The EMP ability is useful when it comes to stopping enemies in their tracks, stunning them and dealing a small amount of damage. [E]";
		narrText [16] = "Bork: Finally, as you can see, each of your abilities will drain your stamina [Top Left]. Now let's explore this cavern, however be wary of those fish, they are not themselves. [E]";
		narrText [17] = "Bork: Oh come now, this cave could not possibly be this dull... there must be a way out. [E]";
		narrText [18] = "Bork: Ah how nice, there is a precariously placed hole in the ceiling. [E]";
		narrText [19] = "Bork: Now, I know you seem capable, but please take care out in the world, we are still attached and I would rather you not be the last thing I see in this world. [E]";
		narrText [20] = "Bork: Dear lord the fog is dense, must be a product of the volcano, or some developers.... [E]";
		narrText [21] = "Bork: Let's move through this reef towards the volcano and see if my second worst fear has come true. [E]";
		narrText [22] = "Bork: I mean, normally things are rather dull around here, but considering the hostility around here. Things are not bueno. [E]";
		narrText [23] = "Bork: Ah... I see yes it looks like some irresponsible peasant left the volcano on... let's go turn it off so I can get back to the Karfishians. [E]";
		narrText [24] = "Bork: Ugh... it's Chad. Let's go talk to him I guess. [E]";

	}




}
