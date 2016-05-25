using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;




public class TutorialObject : MonoBehaviour {
	private string[] fishNames = new string[]{ "dankFish", "barracuda","snapper", "angler","dolphin","flounder" ,"manta", "tuna", "swordfish","sting ray", "manta ray", "whale"};
	public bool debugStatements = true;
	public GameObject tutorialText;
	private Text tutText;
	//private Text textHolder = GetComponent<Text>();
	private GameObject playerBabyModel;
	private GameObject playerJuveModel;
	private GameObject playerAdultModel;
	private Scene sceneTemp;
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
	private GameObject uiQuestThirteen;
	private GameObject uiQuestFourteen;
	private GameObject uiQuestFifteen;
	private GameObject uiQuestSixteen;
	private GameObject uiQuestSixteenOne;
	private GameObject uiQuestSixteenTwo;
	private GameObject uiQuestSixteenComp;
	private GameObject uiQuestSeventeen;
	private GameObject uiQuestEighteen;
	private GameObject uiQuestNineteen;
	private GameObject uiQuestTwentyOne;
	private GameObject uiQuestTwenty;
	private GameObject uiQuestTwentyTwo;
	private GameObject uiQuestTwentyThree;
	private GameObject uiQuestTwentyThreeInc1;
	private GameObject uiQuestTwentyThreeInc2;
	private GameObject uiQuestTwentyThreeInc3;
	private GameObject uiQuestTwentyThreeInc4;
	private GameObject uiQuestTwentyThreeInc5;
	private GameObject uiQuestTwentyFour;
	private GameObject uiQuestTwentyFive;
	private GameObject uiQuestTwentySix;
	private GameObject uiQuestTwentySeven;
	private AudioSource questCompleteSound;
	private AudioSource tubeBreakSound;
	private AudioSource borkDialogueSound;
	private AudioSource chadDialogueSound;
	private AudioSource dadDialogueSound;
	private AudioSource eelDialogueSound;

	private GameObject uiMissionText;
	private GameObject uiQuestOutline;
	private GameObject uiBoxOutline;
	private GameObject uiMissionBox;
	private GameObject brokenGlassTube;
	private GameObject incompleteMissionText;
	private GameObject completeMissionText;
	private GameObject returnToBorkText;
	private GameObject returnToDadText;
	private GameObject borkObjectAttached;
	private GameObject borkObjectUnattached;
	private GameObject plateWithScript;
	private GameObject plateNoScript;
	private GameObject milkCartonRock;
	private GameObject turtlePillowRock;
	private GameObject chadLocOriginWithRigid;
	private GameObject chadLocOriginWithNo;
	private GameObject sealLocOrigin;
	private GameObject eelLocOrigin;
	private GameObject beautyKitImg;
	private Mesh squidMesh;
	private Mesh tempMesh;
	private Mesh eggMesh;
	private bool somethingToSay;
	private bool dialogStarted = false;
	private bool inRangeToHear = false;
	private bool inRangeToInt = false;
	public bool beautyKitFound;
	private bool inRangeToHearChad = false;
	private bool inRangeToHearEel = false;
	private bool inRangeToHearSeal = false;
	private bool inRangeToIntChad = false;
	private bool inRangeToIntSeal = false;
	private bool inRangeToIntEel = false;

	public float letterPause;
	public string[] narrText = new string[200];
	public bool[] narrTextTrigger = new bool[200];
	public int posInDialogue;
	private int posInDialogueHolder;
	private bool firstDialogueTrigger = false;
	private bool tooltipInProgress = false;
	public bool isEgg;
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
	private bool questThirteenComplete = false;
	private bool questFourteenComplete = false;
	private bool questFifteenComplete = false;
	private bool questSixteenComplete = false;
	private bool questSeventeenComplete = false;
	private bool questEighteenComplete = false;
	private bool questNineteenComplete = false;
	private bool questTwentyComplete = false;
	private bool questTwentyOneComplete = false;
	private bool questTwentyTwoComplete = false;
	private bool questTwentyThreeComplete = false;
	private bool questTwentyFourComplete = false;
	private bool questTwentyFiveComplete = false;
	private bool questTwentySixComplete = false;
	private bool questTwentySevenComplete = false;
	private bool winGame;
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
	private bool hasEnteredKelpForest;
	private bool hasEnteredVolcVicinity;
	private bool hasEnteredKGY;
	private bool inRangeToSeeChad;
	private bool inRangeToSeeSeal;
	private bool inRangeToSeeEel;
	private bool interactWithChadOne;
	private bool interactWithChadTwo;
	private bool interactWithSealOne;
	private bool interactWithEelOne;
	private bool interactWithEelTwo;
	private bool interactWithSealTwo;
	private int dist;
	private int distToInteract;
	private bool anglersKilled;
	private bool w;
	private bool s;
	private bool a;
	private bool d;
	private bool r;
	private bool f;
	private bool barracudaKilled;
	private bool broughtDaMilk;
	private bool broughtDaPillow;
	private bool findEelChan;
	public bool skipQuests = true;
	private bool turtleTalk = false;
	private bool sealTalk = false;
	private bool eelTalk = false;
	private PickupObject fishStats;
	private outlineLerp colorControl;
	private bool jumpedAhead = false;
	private bool visitLastTime;
	private bool dialogueSoundPlay = false;
	void Start(){
		fishStats = GameObject.Find ("Player").GetComponent<PickupObject> ();
		colorControl = GameObject.Find ("Outline").GetComponent<outlineLerp> ();
		fillNarrativeString ();
		tutText = tutorialText.GetComponent<Text> ();
		questCompleteSound = GameObject.Find("Player").transform.Find ("questCompleteSound").GetComponent<AudioSource> ();
		tubeBreakSound = GameObject.Find("Player").transform.Find ("tubeBreak").GetComponent<AudioSource> ();
		borkDialogueSound = GameObject.Find("Player").transform.Find ("borkSound").GetComponent<AudioSource> ();
		eelDialogueSound = GameObject.Find("Player").transform.Find ("eelSound").GetComponent<AudioSource> ();
		dadDialogueSound = GameObject.Find("Player").transform.Find ("dadSound").GetComponent<AudioSource> ();
		chadDialogueSound = GameObject.Find("Player").transform.Find ("chadSound").GetComponent<AudioSource> ();

		playerBabyModel = GameObject.Find("chibiSquid");
		playerJuveModel = GameObject.FindGameObjectWithTag ("krakenJuvenile");
		playerJuveModel.SetActive (false);
		playerAdultModel = GameObject.FindGameObjectWithTag ("krakenAdult");
		playerAdultModel.SetActive (false);

		sceneTemp = SceneManager.GetActiveScene ();
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
		uiQuestThirteen = GameObject.Find ("QuestThirteen");
		uiQuestThirteen.SetActive (false);
		uiQuestFourteen = GameObject.Find ("QuestFourteen");
		uiQuestFourteen.SetActive (false);
		uiQuestFifteen = GameObject.Find ("QuestFifteen");
		uiQuestFifteen.SetActive (false);
		uiQuestSixteen = GameObject.Find ("QuestSixteen");
		uiQuestSixteen.SetActive (false);
		uiQuestSixteenOne = GameObject.Find ("QuestSixteenOne");
		uiQuestSixteenOne.SetActive (false);
		uiQuestSixteenTwo = GameObject.Find ("QuestSixteenTwo");
		uiQuestSixteenTwo.SetActive (false);
		uiQuestSixteenComp = GameObject.Find ("QuestSixteenComp");
		uiQuestSixteenComp.SetActive (false);
		uiQuestSeventeen = GameObject.Find ("QuestSeventeen");
		uiQuestSeventeen.SetActive (false);
		uiQuestEighteen = GameObject.Find ("QuestEighteen");
		uiQuestEighteen.SetActive (false);
		uiQuestNineteen = GameObject.Find ("QuestNineteen");
		uiQuestNineteen.SetActive (false);
		uiQuestTwenty = GameObject.Find ("QuestTwenty");
		uiQuestTwenty.SetActive (false);
		uiQuestTwentyOne = GameObject.Find ("QuestTwentyOne");
		uiQuestTwentyOne.SetActive (false);
		uiQuestTwentyTwo = GameObject.Find ("QuestTwentyTwo");
		uiQuestTwentyTwo.SetActive (false);
		uiQuestTwentyThree = GameObject.Find ("QuestTwentyThree");
		uiQuestTwentyThree.SetActive (false);
		uiQuestTwentyFour = GameObject.Find ("QuestTwentyFour");
		uiQuestTwentyFour.SetActive (false);
		uiQuestTwentyFive = GameObject.Find ("QuestTwentyFive");
		uiQuestTwentyFive.SetActive (false);
		uiQuestTwentySix = GameObject.Find ("QuestTwentySix");
		uiQuestTwentySix.SetActive (false);
		uiQuestTwentySeven = GameObject.Find ("QuestTwentySeven");
		uiQuestTwentySeven.SetActive (false);
		uiQuestTwentyThreeInc1 = GameObject.Find ("QuestTwentyThreeInc1");
		uiQuestTwentyThreeInc1.SetActive (false);
		uiQuestTwentyThreeInc2 = GameObject.Find ("QuestTwentyThreeInc2");
		uiQuestTwentyThreeInc2.SetActive (false);
		uiQuestTwentyThreeInc3 = GameObject.Find ("QuestTwentyThreeInc3");
		uiQuestTwentyThreeInc3.SetActive (false);
		uiQuestTwentyThreeInc4 = GameObject.Find ("QuestTwentyThreeInc4");
		uiQuestTwentyThreeInc4.SetActive (false);
		uiQuestTwentyThreeInc5 = GameObject.Find ("QuestTwentyThreeInc5");
		uiQuestTwentyThreeInc5.SetActive (false);
		uiMissionText = GameObject.FindGameObjectWithTag ("uiMissionText");
		uiMissionText.SetActive (false);
		uiQuestOutline = GameObject.Find ("Outline");
		uiQuestOutline.SetActive (false);
		uiBoxOutline = GameObject.Find ("textBoxOutline");
		uiBoxOutline.SetActive (false);
		uiMissionBox = GameObject.FindGameObjectWithTag ("uiQuestBox");
		uiMissionBox.SetActive (false);
		borkObjectAttached = GameObject.FindGameObjectWithTag ("borkAttached");

		borkObjectAttached.SetActive (false);
		borkObjectUnattached = GameObject.FindGameObjectWithTag ("BorkNPCLocation");
		/*
		GameObject.FindGameObjectWithTag ("borkunattached").GetComponent<NPCHighlighting>().changeMatToNml();
		GameObject.FindGameObjectWithTag ("borkunattached").GetComponent<NPCHighlighting>().changeMatToHL();
		GameObject.FindGameObjectWithTag ("borkunattached").GetComponent<NPCHighlighting>().changeMatToNml();
		*/
		GameObject.FindGameObjectWithTag ("borkunattached");
		incompleteMissionText = GameObject.FindGameObjectWithTag ("incomplete");
		incompleteMissionText.SetActive (false);
		completeMissionText = GameObject.FindGameObjectWithTag ("complete");
		completeMissionText.SetActive (false);
		returnToBorkText = GameObject.FindGameObjectWithTag ("QuestReturn");
		returnToBorkText.SetActive (false);
		returnToDadText = GameObject.Find ("QuestReturnSeal");
		returnToDadText.SetActive (false);
		player = GameObject.FindGameObjectWithTag("Player");
		chadLocOriginWithRigid = GameObject.Find ("chadLocationObjectWithRigid");
		chadLocOriginWithRigid.SetActive (false);
		chadLocOriginWithNo = GameObject.Find ("chadLocationObjectWithNo");
		chadLocOriginWithNo.SetActive (true);
		sealLocOrigin = GameObject.Find ("sealDadLocationObject");
		eelLocOrigin = GameObject.Find ("eelLocationObject");
		egg = GameObject.FindGameObjectWithTag ("krakenEgg");
		plateWithScript = GameObject.Find ("pressurewithscript");
		plateWithScript.SetActive (false);
		plateNoScript = GameObject.Find ("pressurenoscript");
		milkCartonRock = GameObject.Find ("SealDadsMilkRock");
		turtlePillowRock = GameObject.Find ("TurtlePillowRock");
		beautyKitImg = GameObject.Find ("BeautyKitImage");
		beautyKitImg.SetActive (false);
		tutorialText.SetActive (false);
		tutorialBox.SetActive (false);

	}


	void Update ()
	{
		if (skipQuests && !jumpedAhead) {
			jumpedAhead = true;
			jumpAhead ();
		}
		keyCheck ();
		//Debug.Log ("turtletalk = " + turtleTalk);
		if (turtleTalk) {
			distanceNotifyChad ();
			if (inRangeToIntChad) {
				speakWithChad ();
			}
		}
		if (sealTalk) {
			distanceNotifySealDad ();
			speakWithSeal ();
		}
		if (eelTalk) {
			distanceNotifyEel ();
			speakWithEel ();
		}
		if (!inRangeToSeeChad && inRangeToHearChad) {
			inRangeToSeeChad = true;
		} 
		if (!inRangeToSeeSeal && inRangeToHearSeal) {
			inRangeToSeeSeal = true;
		}
		if (!inRangeToSeeEel && inRangeToHearEel) {
			inRangeToSeeEel = true;
		}
		if (fishStats.getTargetProgress () == 1 && !questTwentyThreeComplete && posInDialogue == 52 && acceptQuest) {
			uiQuestTwentyThree.SetActive (false);
			uiQuestTwentyThreeInc1.SetActive (true);
		} else if (fishStats.getTargetProgress () == 2 && !questTwentyThreeComplete && posInDialogue == 52&& acceptQuest) {
			uiQuestTwentyThreeInc1.SetActive (false);
			uiQuestTwentyThreeInc2.SetActive (true);
		}
		else if (fishStats.getTargetProgress () == 3 && !questTwentyThreeComplete && posInDialogue == 52&& acceptQuest) {
			uiQuestTwentyThreeInc2.SetActive (false);
			uiQuestTwentyThreeInc3.SetActive (true);
		}
		else if (fishStats.getTargetProgress () == 4 && !questTwentyThreeComplete && posInDialogue == 52&& acceptQuest) {
			uiQuestTwentyThreeInc3.SetActive (false);
			uiQuestTwentyThreeInc4.SetActive (true);

		}
		else if (fishStats.getTargetProgress () == 5 && !questTwentyThreeComplete && posInDialogue == 52&& acceptQuest) {
			uiQuestTwentyThreeInc4.SetActive (false);
			uiQuestTwentyThreeInc5.SetActive (true);
			anglersKilled = true;
		}

		if (fishStats.getTargetProgress () == 1 && !questSixteenComplete) {
			uiQuestSixteen.SetActive (false);
			uiQuestSixteenOne.SetActive (true);
		} else if (fishStats.getTargetProgress () == 2 && !questSixteenComplete) {
			uiQuestSixteenOne.SetActive (false);
			uiQuestSixteenTwo.SetActive (true);
		}
		else if (fishStats.getTargetProgress () == 3 && !questSixteenComplete) {
			uiQuestSixteenTwo.SetActive (false);
			barracudaKilled = true;
		}

		//Debug.Log (posInDialogue);
		inCavern = GameObject.Find("Cavern").GetComponent<LocationTracking>().here;
		hasEnteredTemple = GameObject.Find("TempleLoc").GetComponent<LocationTracking>().here;
		hasEnteredReef = GameObject.Find("ReefLoc").GetComponent<LocationTracking>().here;
		hasEnteredVolcVicinity = GameObject.Find("VolcLoc").GetComponent<LocationTracking>().here;
		hasEnteredKelpForest = GameObject.Find("KelpLoc").GetComponent<LocationTracking>().here;
		hasEnteredKGY = GameObject.Find("KrakenGYLoc").GetComponent<LocationTracking>().here;
		hasInked = GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().firstTimeInking;
		hasSped = GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().firstTimeSpeeding;
		hasSanic = GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().firstTimeSanic;
		hasEmp = GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().firstTimeEmp;
		broughtDaMilk = milkCartonRock.GetComponent<SealSwitch> ().questComplete;
		broughtDaPillow = GameObject.Find("TurtlePillowRock").GetComponent<TurtleSwitch> ().questComplete;
		winGame = GameObject.Find ("endGameButton").GetComponent<endGameSwitch> ().questComplete;
		if (!skipQuests) {
			

		}
		if (!borkAttached && !questZeroComplete && !isGlassBroken) {
			distanceNotify ();
		}

		if (hasPressedEveryKey && inRangeToInt && acceptQuest && !questZeroComplete) {
			acceptQuest = false;
			questCompleteSound.Play ();
			questZeroComplete = true;
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestZero.SetActive (false);
			narrTextTrigger[posInDialogue] = true;
			pressEText.SetActive (true);
			colorControl.endColor = Color.green;
		}

		if (isGlassBroken && acceptQuest && !questOneComplete) {
			acceptQuest = false;
			questOneComplete = true;
			completeMissionText.SetActive (true);
			tubeBreakSound.Play ();
			questCompleteSound.Play ();
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestOne.SetActive (false);
			narrTextTrigger[posInDialogue] = true;
			plateNoScript.SetActive (false);
			plateWithScript.SetActive (true);
			pressEText.SetActive (true);
			colorControl.endColor = Color.green;
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();

		}
		if (gateIsOpen && acceptQuest && !questTwoComplete && questOneComplete) {
			acceptQuest = false;
			questCompleteSound.Play ();
			questTwoComplete = true;
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestTwo.SetActive (false);
			narrTextTrigger [posInDialogue] = true;
			pressEText.SetActive (true);
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
			colorControl.endColor = Color.green;
		}
		if (inCavern && acceptQuest && !questThreeComplete && questTwoComplete) {
			acceptQuest = false;
			questThreeComplete = true;
			questCompleteSound.Play ();
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestThree.SetActive (false);
			narrTextTrigger [posInDialogue] = true;
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
			colorControl.endColor = Color.green;
		}
		if (hasInked && acceptQuest && !questFourComplete && questThreeComplete) {
			acceptQuest = false;
			questFourComplete = true;
			questCompleteSound.Play ();
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestFour.SetActive (false);
			narrTextTrigger [posInDialogue] = true;
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
			colorControl.endColor = Color.green;
		}
		if (hasSped && acceptQuest && !questFiveComplete && questFourComplete) {
			acceptQuest = false;
			questFiveComplete = true;
			questCompleteSound.Play ();
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestFive.SetActive (false);
			pressEText.SetActive (true);
			narrTextTrigger [posInDialogue] = true;
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
			colorControl.endColor = Color.green;
		}
		if (hasSanic && acceptQuest && !questSixComplete && questFiveComplete) {
			acceptQuest = false;
			questSixComplete = true;
			questCompleteSound.Play ();
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestSix.SetActive (false);
			pressEText.SetActive (true);
			narrTextTrigger [posInDialogue] = true;
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
			colorControl.endColor = Color.green;
		}
		if (hasEmp && acceptQuest && !questSevenComplete && questSixComplete) {
			acceptQuest = false;
			questSevenComplete = true;
			questCompleteSound.Play ();
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestSeven.SetActive (false);
			pressEText.SetActive (true);
			narrTextTrigger [posInDialogue] = true;
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
			colorControl.endColor = Color.green;
		}
		if (hasEnteredTemple && acceptQuest && !questEightComplete && questSevenComplete) {
			acceptQuest = false;
			questEightComplete = true;
			questCompleteSound.Play ();
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestEight.SetActive (false);
			pressEText.SetActive (true);
			narrTextTrigger [posInDialogue] = true;
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
			colorControl.endColor = Color.green;
		}
		if (hasEnteredReef && acceptQuest && !questNineComplete && questEightComplete) {
			acceptQuest = false;
			questNineComplete = true;
			questCompleteSound.Play ();
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestNine.SetActive (false);
			pressEText.SetActive (true);
			narrTextTrigger [posInDialogue] = true;
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
			colorControl.endColor = Color.green;
		}
		if (hasEnteredVolcVicinity && acceptQuest && !questTenComplete && questNineComplete) {
			acceptQuest = false;
			questTenComplete = true;
			questCompleteSound.Play ();
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestTen.SetActive (false);
			pressEText.SetActive (true);
			narrTextTrigger [posInDialogue] = true;
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
			colorControl.endColor = Color.green;
		}
		if (inRangeToSeeChad && acceptQuest && !questElevenComplete && questTenComplete) {
			acceptQuest = false;
			questElevenComplete = true;
			questCompleteSound.Play ();
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestEleven.SetActive (false);
			pressEText.SetActive (true);
			narrTextTrigger [posInDialogue] = true;
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
			colorControl.endColor = Color.green;
		}
		if (interactWithChadOne && acceptQuest && !questTwelveComplete && questElevenComplete) {
			acceptQuest = false;
			questCompleteSound.Play ();
			questTwelveComplete = true;
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestTwelve.SetActive (false);
			narrTextTrigger [posInDialogue] = true;
			pressEText.SetActive (true);
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
			colorControl.endColor = Color.green;
		}
		if (hasEnteredKelpForest && acceptQuest && !questThirteenComplete && questTwelveComplete) {
			acceptQuest = false;
			questThirteenComplete = true;
			questCompleteSound.Play ();
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestThirteen.SetActive (false);
			narrTextTrigger [posInDialogue] = true;
			pressEText.SetActive (true);
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
			colorControl.endColor = Color.green;
		}
		if (inRangeToSeeSeal && acceptQuest && !questFourteenComplete && questThirteenComplete) {
			acceptQuest = false;
			questFourteenComplete = true;
			questCompleteSound.Play ();
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestFourteen.SetActive (false);
			narrTextTrigger [posInDialogue] = true;
			pressEText.SetActive (true);
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
			colorControl.endColor = Color.green;
		}
		if (interactWithSealOne && acceptQuest && !questFifteenComplete && questFourteenComplete) {
			acceptQuest = false;
			questFifteenComplete = true;
			questCompleteSound.Play ();
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestFifteen.SetActive (false);
			narrTextTrigger [posInDialogue] = true;
			pressEText.SetActive (true);
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
			colorControl.endColor = Color.green;
		}
		if (barracudaKilled && acceptQuest && !questSixteenComplete && questFifteenComplete) {
			acceptQuest = false;
			questSixteenComplete = true;
			questCompleteSound.Play ();
			completeMissionText.SetActive (true);
			uiQuestSixteenComp.SetActive (true);
			//returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			pressEText.SetActive (true);
			narrTextTrigger [posInDialogue] = true;
			colorControl.endColor = Color.green;
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		if (interactWithSealTwo && acceptQuest && !questSeventeenComplete && questSixteenComplete) {
			acceptQuest = false;
			questSeventeenComplete = true;
			questCompleteSound.Play ();
			completeMissionText.SetActive (true);
			uiQuestSeventeen.SetActive (true);
			//returnToDadText.SetActive (true);
			pressEText.SetActive (true);
			incompleteMissionText.SetActive (false);
			narrTextTrigger [posInDialogue] = true;
			colorControl.endColor = Color.green;
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		if (broughtDaMilk && acceptQuest && !questEighteenComplete && questSeventeenComplete) {
			//ADD WHITE FLASH AND CHANGE MODELS HERE.
			acceptQuest = false;
			questEighteenComplete = true;
			questCompleteSound.Play ();
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestEighteen.SetActive (false);
			pressEText.SetActive (true);

			narrTextTrigger [posInDialogue] = true;
			colorControl.endColor = Color.green;
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		if (interactWithChadTwo && acceptQuest && !questNineteenComplete && questEighteenComplete) {
			
			acceptQuest = false;
			questNineteenComplete = true;
			completeMissionText.SetActive (true);
			uiQuestNineteen.SetActive (false);
			questCompleteSound.Play ();
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			pressEText.SetActive (true);
			narrTextTrigger [posInDialogue] = true;
			colorControl.endColor = Color.green;
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		if (broughtDaPillow && acceptQuest && !questTwentyComplete && questNineteenComplete) {
			acceptQuest = false;
			questTwentyComplete = true;
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			questCompleteSound.Play ();
			incompleteMissionText.SetActive (false);
			uiQuestTwenty.SetActive (false);
			narrTextTrigger [posInDialogue] = true;
			colorControl.endColor = Color.green;
			pressEText.SetActive (true);
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		if (hasEnteredKGY && acceptQuest && !questTwentyOneComplete && questTwentyComplete) {
			acceptQuest = false;
			questTwentyOneComplete = true;
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			questCompleteSound.Play ();
			incompleteMissionText.SetActive (false);
			uiQuestTwentyOne.SetActive (false);
			narrTextTrigger [posInDialogue] = true;
			pressEText.SetActive (true);
			colorControl.endColor = Color.green;
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		if (interactWithEelOne && acceptQuest && !questTwentyTwoComplete && questTwentyOneComplete) {
			acceptQuest = false;
			questTwentyTwoComplete = true;
			questCompleteSound.Play ();
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestTwentyTwo.SetActive (false);
			pressEText.SetActive (true);
			narrTextTrigger [posInDialogue] = true;
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
			colorControl.endColor = Color.green;
		}
		if (anglersKilled && beautyKitFound && acceptQuest && !questTwentyThreeComplete && questTwentyTwoComplete) {
			
			acceptQuest = false;
			questTwentyThreeComplete = true;
			questCompleteSound.Play ();
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestTwentyThreeInc5.SetActive (false);
			narrTextTrigger [posInDialogue] = true;
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
			colorControl.endColor = Color.green;
		}
		if (interactWithEelTwo && acceptQuest && !questTwentyFourComplete && questTwentyThreeComplete) {
			//Change model here
			acceptQuest = false;
			questTwentyFourComplete = true;
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			questCompleteSound.Play ();
			incompleteMissionText.SetActive (false);
			uiQuestTwentyThreeInc5.SetActive (false);
			pressEText.SetActive (true);
			narrTextTrigger [posInDialogue] = true;
			playerJuveModel.SetActive (false);
			playerAdultModel.SetActive (true);

			colorControl.endColor = Color.green;
		}
		if (visitLastTime && acceptQuest && !questTwentyFiveComplete && questTwentyFourComplete) {
			acceptQuest = false;
			questTwentyFiveComplete = true;
			completeMissionText.SetActive (true);
			returnToBorkText.SetActive (true);
			questCompleteSound.Play ();
			incompleteMissionText.SetActive (false);
			uiQuestTwentyFive.SetActive (false);
			pressEText.SetActive (true);
			narrTextTrigger [posInDialogue] = true;
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
			colorControl.endColor = Color.green;
		}
		if (winGame && acceptQuest && !questTwentySixComplete && questTwentyFiveComplete) {
			acceptQuest = false;
			questTwentySixComplete = true;
			completeMissionText.SetActive (true);
			questCompleteSound.Play ();
			returnToBorkText.SetActive (true);
			incompleteMissionText.SetActive (false);
			uiQuestTwentySix.SetActive (false);
			pressEText.SetActive (true);
			narrTextTrigger [posInDialogue] = true;
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
			colorControl.endColor = Color.green;
		}


		if (beautyKitFound && !questTwentyThreeComplete) {
			beautyKitImg.SetActive (true);
		}

		if (isEgg) {
			if (!dialogStarted) {
				dialogStarted = true;
				StartCoroutine (waitForFirstDialogueTrigger (1f));
			}
		}
		if (posInDialogue == 0) {
			pressEText.SetActive (true);
			if (!dialogueSoundPlay) {
				dialogueSoundPlay = true;
				borkDialogueSound.Play ();
			}
		}
		// Quest Zero
		if (posInDialogue == 1 && !acceptQuest && !questZeroComplete) {
			acceptQuest = true;
			dialogueSoundPlay = false;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestZero.SetActive (true);
			pressEText.SetActive (true);
			uiQuestOutline.SetActive (true);
			incompleteMissionText.SetActive (true);

		}
		//complete quest zero
		if (posInDialogue == 2) {
			Debug.Log ("calling");
			if (!dialogueSoundPlay) {
				dialogueSoundPlay = true;
				borkDialogueSound.Play ();
			}
			uiQuestOutline.SetActive (false);
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestZero.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (true);
			colorControl.endColor = Color.red;

		}


		//Quest one
		if (posInDialogue == 3 && !acceptQuest && !questOneComplete) {
			acceptQuest = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestOne.SetActive(true);
			incompleteMissionText.SetActive (true);
			uiQuestOutline.SetActive (true);
			pressEText.SetActive (false);
			dialogueSoundPlay = false;
			colorControl.endColor = Color.red;
		}
		//Complete quest one
		if (posInDialogue == 4) {
			if (!dialogueSoundPlay) {
				dialogueSoundPlay = true;
				borkDialogueSound.Play ();
			}
			borkAttached = true;
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestOne.SetActive (false);
			uiQuestOutline.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			borkObjectAttached.SetActive (true);
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToNml ();
			borkObjectUnattached.SetActive (false);
		}
		//Quest Two
		if (posInDialogue == 5 && !acceptQuest && !questTwoComplete) {
			acceptQuest = true;
			uiQuestOutline.SetActive (true);
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestTwo.SetActive (true);
			incompleteMissionText.SetActive (true);
			dialogueSoundPlay = false;
			colorControl.endColor = Color.red;
		}
		else if (posInDialogue == 5 && acceptQuest && !questTwoComplete) {
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		}

		//Complete Quest Two
		if (posInDialogue == 6) {
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestTwo.SetActive (false);
			uiQuestOutline.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			if (!dialogueSoundPlay) {
				dialogueSoundPlay = true;
				borkDialogueSound.Play ();
			}
		}
		//Quest Three
		if (posInDialogue == 7 && !acceptQuest && !questThreeComplete) {
			acceptQuest = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestThree.SetActive (true);
			uiQuestOutline.SetActive (true);
			completeMissionText.SetActive (false);
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			dialogueSoundPlay = false;
			colorControl.endColor = Color.red;
		}else if (posInDialogue == 7 && acceptQuest && !questThreeComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		}

		//Complete Quest Three
		if (posInDialogue == 8) {
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestFour.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			uiQuestOutline.SetActive (false);
			if (!dialogueSoundPlay) {
				dialogueSoundPlay = true;
				borkDialogueSound.Play ();
			}

		}
		//Quest Four
		if (posInDialogue == 9 && !acceptQuest && !questFourComplete) {
			acceptQuest = true;
			GameObject.FindGameObjectWithTag("Player").GetComponent<Abilities>().inkIcon.enabled = true;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().abilities [1] = true;
			uiMissionBox.SetActive (true);
			uiQuestOutline.SetActive (true);
			uiMissionText.SetActive (true);
			dialogueSoundPlay = false;
			uiQuestFour.SetActive (true);
			completeMissionText.SetActive (false);
			colorControl.endColor = Color.red;
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
		}else if (posInDialogue == 9 && acceptQuest && !questFourComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		}

		//Complete Quest Four
		if (posInDialogue == 10) {
			uiQuestOutline.SetActive (false);
			if (!dialogueSoundPlay) {
				dialogueSoundPlay = true;
				borkDialogueSound.Play ();
			}
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestFour.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
		}
		//Quest Five
		if (posInDialogue == 11 && !acceptQuest && !questFiveComplete) {
			acceptQuest = true;
			GameObject.FindGameObjectWithTag("Player").GetComponent<Abilities>().speedIcon.enabled = true;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().abilities [0] = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestOutline.SetActive (true);
			colorControl.endColor = Color.red;
			uiQuestFive.SetActive (true);
			dialogueSoundPlay = false;
			completeMissionText.SetActive (false);
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
		}else if (posInDialogue == 11 && acceptQuest && !questFiveComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		}

		//Complete Quest Five
		if (posInDialogue == 12) {
			uiQuestOutline.SetActive (false);
			if (!dialogueSoundPlay) {
				dialogueSoundPlay = true;
				borkDialogueSound.Play ();
			}
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestFive.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (true);
		}
		//Quest Six
		if (posInDialogue == 13 && !acceptQuest && !questSixComplete) {
			acceptQuest = true;
			GameObject.FindGameObjectWithTag("Player").GetComponent<Abilities>().currentIcon.enabled = true;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().abilities [2] = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestSix.SetActive (true);
			dialogueSoundPlay = true;
			colorControl.endColor = Color.red;
			uiQuestOutline.SetActive (true);
			completeMissionText.SetActive (false);
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
		}else if (posInDialogue == 13 && acceptQuest && !questSixComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		}
		else if (posInDialogue == 13 && !acceptQuest && questSixComplete) {
			pressEText.SetActive (true);
		}
		//Complete Quest Six
		if (posInDialogue == 14) {
			uiQuestOutline.SetActive (false);
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestSix.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (true);
			if (!dialogueSoundPlay) {
				dialogueSoundPlay = true;
				borkDialogueSound.Play ();
			}

		}
		//Quest Seven
		if (posInDialogue == 15 && !acceptQuest && !questSevenComplete) {
			acceptQuest = true;
			GameObject.FindGameObjectWithTag("Player").GetComponent<Abilities>().currentIcon.enabled = true;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().abilities [3] = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestSeven.SetActive (true);
			uiQuestOutline.SetActive (true);
			dialogueSoundPlay = false;
			completeMissionText.SetActive (false);
			colorControl.endColor = Color.red;
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
		}else if (posInDialogue == 15 && acceptQuest && !questSevenComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		}
		else if (posInDialogue == 15 && !acceptQuest && questSevenComplete) {
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
		}
		//Complete Quest Seven
		if (posInDialogue == 16) {
			uiQuestOutline.SetActive (false);
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestSeven.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			if (!dialogueSoundPlay) {
				dialogueSoundPlay = true;
				borkDialogueSound.Play ();
			}
		}
		//Quest 8
		if (posInDialogue == 17 && !acceptQuest && !questEightComplete) {
			acceptQuest = true;
			GameObject.FindGameObjectWithTag("Player").GetComponent<Abilities>().currentIcon.enabled = true;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().abilities [3] = true;
			uiMissionBox.SetActive (true);
			uiQuestOutline.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestEight.SetActive (true);
			completeMissionText.SetActive (false);
			colorControl.endColor = Color.red;
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			dialogueSoundPlay = false;
			pressEText.SetActive (false);
		}else if (posInDialogue == 17 && acceptQuest && !questEightComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		}
		else if (posInDialogue == 17 && !acceptQuest && questEightComplete) {
			pressEText.SetActive (true);
		}
		//Complete Quest Eight
		if (posInDialogue == 18) {
			uiQuestOutline.SetActive (false);
			if (!dialogueSoundPlay) {
				dialogueSoundPlay = true;
				borkDialogueSound.Play ();
			}
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestEight.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (true);
		}
		//Dialogue
		if (posInDialogue == 19 && dialogueSoundPlay) {
			dialogueSoundPlay = false;
			if (!dialogueSoundPlay) {
				//dialogueSoundPlay = true;
				borkDialogueSound.Play ();
			}
			pressEText.SetActive (true);
		}
		//Quest Nine
		if (posInDialogue == 20 && !acceptQuest && !questNineComplete) {
			acceptQuest = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestOutline.SetActive (true);
			uiQuestNine.SetActive (true);
			colorControl.endColor = Color.red;
			completeMissionText.SetActive (false);
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (false);
			dialogueSoundPlay = false;
		}else if (posInDialogue == 20 && acceptQuest && !questNineComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		}
		else if (posInDialogue == 20 && !acceptQuest && questNineComplete) {
			pressEText.SetActive (true);
		}
		//Complete Quest Nine
		if (posInDialogue == 21 && !dialogueSoundPlay) {
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestNine.SetActive (false);
			uiQuestOutline.SetActive (false);
			if (!dialogueSoundPlay) {
				dialogueSoundPlay = true;
				borkDialogueSound.Play ();
			}
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (true);
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		//Quest Ten
		if (posInDialogue == 22 && !acceptQuest && !questTenComplete) {
			acceptQuest = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestTen.SetActive (true);
			colorControl.endColor = Color.red;
			uiQuestOutline.SetActive (true);
			dialogueSoundPlay = false;
			completeMissionText.SetActive (false);
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (false);
		}else if (posInDialogue == 22 && acceptQuest && !questTenComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		}
		else if (posInDialogue == 22 && !acceptQuest && questTenComplete) {
			pressEText.SetActive (true);
		}
		//Complete Quest Ten
		if (posInDialogue == 23) {
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestTen.SetActive (false);
			uiQuestOutline.SetActive (false);
			if (!dialogueSoundPlay) {
				dialogueSoundPlay = true;
				borkDialogueSound.Play ();
			}
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (true);
		}
		//Quest Eleven
		if (posInDialogue == 24 && !acceptQuest && !questElevenComplete) {
			acceptQuest = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestEleven.SetActive (true);
			uiQuestOutline.SetActive (true);
			colorControl.endColor = Color.red;
			completeMissionText.SetActive (false);
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (false);
			dialogueSoundPlay = false;
			if (!dialogueSoundPlay) {
				dialogueSoundPlay = true;
				borkDialogueSound.Play ();
			}
			turtleTalk = true;
		}else if (posInDialogue == 24 && acceptQuest && !questElevenComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		}
		else if (posInDialogue == 24 && !acceptQuest && questElevenComplete) {
			pressEText.SetActive (true);
		}
		//Quest Twelve
		if (posInDialogue == 25 && !acceptQuest && !questTwelveComplete) {
			acceptQuest = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestTwelve.SetActive (true);
			completeMissionText.SetActive (false);
			colorControl.endColor = Color.red;
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (false);
			turtleTalk = true;
			dialogueSoundPlay = false;

		}else if (posInDialogue == 25 && acceptQuest && !questTwelveComplete) {
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		}
		else if (posInDialogue == 25 && !acceptQuest && questTwelveComplete) {
			pressEText.SetActive (true);
		}
		//Complete Quest twelve
		if (posInDialogue == 26 && !dialogueSoundPlay) {
			dialogueSoundPlay = false;
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestTwelve.SetActive (false);
			colorControl.endColor = Color.red;
			uiQuestOutline.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (true);
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			//dialogueSoundPlay = false;
			if (!dialogueSoundPlay) {
				dialogueSoundPlay = true;
				chadDialogueSound.Play ();
			} 
		}
		//Dialogue
		if (posInDialogue == 27  && dialogueSoundPlay) {
			uiQuestOutline.SetActive (false);
			dialogueSoundPlay = false;
			if (!dialogueSoundPlay) {
				//dialogueSoundPlay = true;
				borkDialogueSound.Play ();
			}
			pressEText.SetActive (true);
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
		}
		//Dialogue
		if (posInDialogue == 28 && !dialogueSoundPlay) {
			pressEText.SetActive (true);
			dialogueSoundPlay = false;
			if (!dialogueSoundPlay) {
				dialogueSoundPlay = true;
				//Play chad sound
				chadDialogueSound.Play ();
			}
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		//Dialogue
		if (posInDialogue == 29 && dialogueSoundPlay) {
			dialogueSoundPlay = false;
			if (!dialogueSoundPlay) {
				//dialogueSoundPlay = true;
				borkDialogueSound.Play ();
			}
			pressEText.SetActive (true);

		}
		//Dialogue
		if (posInDialogue == 30 && !dialogueSoundPlay) {
			pressEText.SetActive (true);
			turtleTalk = false;
			dialogueSoundPlay = false;
			if (!dialogueSoundPlay) {
				dialogueSoundPlay = true;
				//Play chad sound
				borkDialogueSound.Play ();
			}


		}
		//Quest Thirteen
		if (posInDialogue == 31 && !acceptQuest && !questThirteenComplete) {
			acceptQuest = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestThirteen.SetActive (true);
			completeMissionText.SetActive (false);
			incompleteMissionText.SetActive (true);
			colorControl.endColor = Color.red;
			returnToBorkText.SetActive (false);
			uiQuestOutline.SetActive (true);

			pressEText.SetActive (false);
		} else if (posInDialogue == 31 && acceptQuest && !questThirteenComplete) {
			GameObject.FindGameObjectWithTag ("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		} else if (posInDialogue == 31 && !acceptQuest && questThirteenComplete) {
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
		}
		//Quest Thirteen
		if (posInDialogue == 32 && !acceptQuest && !questFourteenComplete) {
			acceptQuest = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestFourteen.SetActive (true);
			uiQuestOutline.SetActive (true);
			completeMissionText.SetActive (false);
			incompleteMissionText.SetActive (true);
			colorControl.endColor = Color.red;
			returnToBorkText.SetActive (false);
			pressEText.SetActive (false);
			sealTalk = true;
		} else if (posInDialogue == 32 && acceptQuest && !questFourteenComplete) {
			GameObject.FindGameObjectWithTag ("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		} else if (posInDialogue == 32 && !acceptQuest && questFourteenComplete) {
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
		}
		//Quest Fifteen
		if (posInDialogue == 33 && !acceptQuest && !questFifteenComplete) {
			acceptQuest = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestFifteen.SetActive (true);
			completeMissionText.SetActive (false);
			incompleteMissionText.SetActive (true);
			uiQuestOutline.SetActive (true);
			returnToBorkText.SetActive (false);
			colorControl.endColor = Color.red;
			pressEText.SetActive (false);
		} else if (posInDialogue == 33 && acceptQuest && !questFifteenComplete) {
			GameObject.FindGameObjectWithTag ("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		} else if (posInDialogue == 33 && !acceptQuest && questFifteenComplete) {
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
		}
		//Complete Quest fifteen
		if (posInDialogue == 34 && dialogueSoundPlay) {
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestFifteen.SetActive (false);
			uiQuestOutline.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (true);
			dialogueSoundPlay = false;
			if (!dialogueSoundPlay) {
				//dialogueSoundPlay = true;
				borkDialogueSound.Play ();
			}
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		//Dialogue
		if (posInDialogue == 35 && !dialogueSoundPlay) {
			uiQuestOutline.SetActive (false);
			//dialogueSoundPlay = ;
			if (!dialogueSoundPlay) {
				dialogueSoundPlay = true;
				dadDialogueSound.Play ();
			}
			pressEText.SetActive (true);
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
		}
		//Dialogue
		if (posInDialogue == 36 && dialogueSoundPlay) {
			uiQuestOutline.SetActive (false);
			dialogueSoundPlay = false;
			if (!dialogueSoundPlay) {
				//dialogueSoundPlay = true;
				dadDialogueSound.Play ();
			}
			pressEText.SetActive (true);
			sealTalk = false;
			GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
		}
		//Quest Sixteen
		if (posInDialogue == 37 && !acceptQuest && !questSixteenComplete) {
			//fishStats.targetReset ();
			fishStats.targetUpdate ("barracuda");
			acceptQuest = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestSixteen.SetActive (true);
			colorControl.endColor = Color.red;
			sealTalk = false;
			completeMissionText.SetActive (false);
			uiQuestOutline.SetActive (true);
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (false);
		} else if (posInDialogue == 37 && acceptQuest && !questSixteenComplete) {
			GameObject.FindGameObjectWithTag ("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		} else if (posInDialogue == 37 && !acceptQuest && questSixteenComplete) {
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
		}
		//Quest Seventeen
		if (posInDialogue == 38 && !acceptQuest && !questSeventeenComplete) {
			
			sealTalk = true;
			acceptQuest = true;
			colorControl.endColor = Color.red;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			completeMissionText.SetActive (false);
			uiQuestOutline.SetActive (true);
			uiQuestSixteenComp.SetActive (false);
			incompleteMissionText.SetActive (true);
			uiQuestSeventeen.SetActive (true);
			pressEText.SetActive (false);
			dialogueSoundPlay = false;
		} else if (posInDialogue == 38 && acceptQuest && !questSeventeenComplete) {
			GameObject.FindGameObjectWithTag ("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		} else if (posInDialogue == 38 && !acceptQuest && questSeventeenComplete) {
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
		}
		//Complete Quest seventen
		if (posInDialogue == 39 && !dialogueSoundPlay) {
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestSeventeen.SetActive (false);
			uiQuestOutline.SetActive (false);
			completeMissionText.SetActive (false);
			//returnToDadText.SetActive (false);

			if (!dialogueSoundPlay) {
				dialogueSoundPlay = true;
				dadDialogueSound.Play ();
			}
			pressEText.SetActive (true);
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
		}

		//Quest Eighteen
		if (posInDialogue == 40 && !acceptQuest && !questEighteenComplete) {
			acceptQuest = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestEighteen.SetActive (true);
			completeMissionText.SetActive (false);
			uiQuestOutline.SetActive (true);
			colorControl.endColor = Color.red;
			incompleteMissionText.SetActive (true);
			//returnToDadText.SetActive (false);
			dialogueSoundPlay = false;
			pressEText.SetActive (false);
		} else if (posInDialogue == 40 && acceptQuest && !questEighteenComplete) {
			GameObject.FindGameObjectWithTag ("borkAttached").GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		} else if (posInDialogue == 40 && !acceptQuest && questEighteenComplete) {
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
		}
		//Complete Quest sixteen
		if (posInDialogue == 41 && !dialogueSoundPlay) {
			sealTalk = false;
			playerBabyModel.SetActive (false);
			playerJuveModel.SetActive (true);
			borkObjectAttached = GameObject.FindGameObjectWithTag ("borkAttachedJuvenile");
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestEighteen.SetActive (false);
			uiQuestOutline.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (true);
			if (!dialogueSoundPlay) {
				dialogueSoundPlay = true;
				borkDialogueSound.Play ();
			}
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		//Quest Sixteen
		if (posInDialogue == 42 && !acceptQuest && !questNineteenComplete) {
			acceptQuest = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestNineteen.SetActive (true);
			completeMissionText.SetActive (false);
			uiQuestOutline.SetActive (true);
			colorControl.endColor = Color.red;
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (false);
			turtleTalk = true;
		} else if (posInDialogue == 42 && acceptQuest && !questNineteenComplete) {
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		} else if (posInDialogue == 42 && !acceptQuest && questNineteenComplete) {
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
		}
		//Complete Quest sixteen
		if (posInDialogue == 43 && dialogueSoundPlay) {
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestNineteen.SetActive (false);
			uiQuestOutline.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (true);
			dialogueSoundPlay = false;
			if (!dialogueSoundPlay) {
				//dialogueSoundPlay = true;
				borkDialogueSound.Play ();
			}
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		//Dialogue
		if (posInDialogue == 44 && !dialogueSoundPlay) {
			uiQuestOutline.SetActive (false);
			dialogueSoundPlay = false;
			if (!dialogueSoundPlay) {
				dialogueSoundPlay = true;
				chadDialogueSound.Play ();
			}
			pressEText.SetActive (true);
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToNml ();
		}
		if (posInDialogue == 45 && !acceptQuest && !questTwentyComplete) {
			acceptQuest = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestTwenty.SetActive (true);
			colorControl.endColor = Color.red;
			completeMissionText.SetActive (false);
			uiQuestOutline.SetActive (true);
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (false);

		} else if (posInDialogue == 45 && acceptQuest && !questTwentyComplete) {
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (false);
		} else if (posInDialogue == 45 && !acceptQuest && questTwentyComplete) {
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
		}
		//Complete Quest sixteen
		if (posInDialogue == 46 && dialogueSoundPlay) {
			sealTalk = false;
			dialogueSoundPlay = false;
			if (!dialogueSoundPlay) {
				//dialogueSoundPlay = true;
				borkDialogueSound.Play ();
			}
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestTwenty.SetActive (false);
			uiQuestOutline.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (true);
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		if (posInDialogue == 47 && !acceptQuest && !questTwentyOneComplete) {
			acceptQuest = true;
			turtleTalk = false;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestTwentyOne.SetActive (true);
			completeMissionText.SetActive (false);
			uiQuestOutline.SetActive (true);
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (false);
			colorControl.endColor = Color.red;
		} else if (posInDialogue == 47 && acceptQuest && !questTwentyOneComplete) {
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		} else if (posInDialogue == 47 && !acceptQuest && questTwentyOneComplete) {
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
		}
		if (posInDialogue == 48 && !acceptQuest && !questTwentyTwoComplete) {
			acceptQuest = true;
			eelTalk = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestTwentyTwo.SetActive (true);
			completeMissionText.SetActive (false);
			uiQuestOutline.SetActive (true);
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (false);
			colorControl.endColor = Color.red;
			dialogueSoundPlay = false;
		} else if (posInDialogue == 48 && acceptQuest && !questTwentyTwoComplete) {
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		} else if (posInDialogue == 48 && !acceptQuest && questTwentyTwoComplete) {
			//ameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
		}
		if (posInDialogue == 49 && !dialogueSoundPlay) {
			//dialogueSoundPlay = false;
			if (!dialogueSoundPlay) {
				dialogueSoundPlay = true;
				eelDialogueSound.Play ();
			}
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestTwentyTwo.SetActive (false);
			uiQuestOutline.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (true);
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		//Dialogue
		if (posInDialogue == 50 && dialogueSoundPlay) {
			uiQuestOutline.SetActive (false);
			dialogueSoundPlay = false;
			if (!dialogueSoundPlay) {
				//dialogueSoundPlay = true;
				borkDialogueSound.Play ();
			}
			pressEText.SetActive (true);
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToNml ();
		}
		//Dialogue
		if (posInDialogue == 51 && !dialogueSoundPlay) {
			uiQuestOutline.SetActive (false);
			//dialogueSoundPlay = false;
			if (!dialogueSoundPlay) {
				dialogueSoundPlay = true;
				eelDialogueSound.Play ();
			}
			pressEText.SetActive (true);
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToNml ();
		}
		if (posInDialogue == 52 && !acceptQuest && !questTwentyThreeComplete) {
			acceptQuest = true;
			//Debug.Log (fishStats.getTargetProgress ());
			eelTalk = true;
			fishStats.targetUpdate ("angler");
			//fishStats.targetReset ();
			//Play eelchan sound
			colorControl.endColor = Color.red;
			Debug.Log (fishStats.getTargetProgress ());
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestTwentyThree.SetActive (true);
			completeMissionText.SetActive (false);
			uiQuestOutline.SetActive (true);
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (false);

		} else if (posInDialogue == 52 && acceptQuest && !questTwentyThreeComplete) {
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		} else if (posInDialogue == 52 && !acceptQuest && questTwentyThreeComplete) {
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
		}
		if (posInDialogue == 53 && !acceptQuest && !questTwentyFourComplete) {
			acceptQuest = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			beautyKitImg.SetActive (false);
			uiQuestTwentyThreeInc5.SetActive (true);
			completeMissionText.SetActive (false);
			uiQuestOutline.SetActive (true);
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (false);
			colorControl.endColor = Color.red;
			dialogueSoundPlay = false;
		} else if (posInDialogue == 53 && acceptQuest && !questTwentyFourComplete) {
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		} else if (posInDialogue == 53 && !acceptQuest && questTwentyFourComplete) {
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
		}
		if (posInDialogue == 54 && !dialogueSoundPlay) {
			dialogueSoundPlay = false;
			if (!dialogueSoundPlay) {
				dialogueSoundPlay = true;
				eelDialogueSound.Play ();
			}
			borkObjectAttached = GameObject.FindGameObjectWithTag ("borkAttachedJuvenile");
			borkObjectAttached = GameObject.FindGameObjectWithTag ("borkAttachedAdult");
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestTwentyFour.SetActive (false);
			uiQuestOutline.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (true);
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		//Dialogue
		if (posInDialogue == 55 && dialogueSoundPlay) {
			uiQuestOutline.SetActive (false);
			dialogueSoundPlay = false;
			if (!dialogueSoundPlay) {
				//dialogueSoundPlay = true;
				borkDialogueSound.Play ();
			}
			pressEText.SetActive (true);
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToNml ();
		}

		if (posInDialogue == 56 && !acceptQuest && !questTwentyFiveComplete) {
			acceptQuest = true;
			eelTalk = false;
			turtleTalk = true;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestTwentyFive.SetActive (true);
			completeMissionText.SetActive (false);
			colorControl.endColor = Color.red;
			uiQuestOutline.SetActive (true);
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (false);
			dialogueSoundPlay = false;
			eelTalk = false;
		} else if (posInDialogue == 56 && acceptQuest && !questTwentyFiveComplete) {
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		} else if (posInDialogue == 56 && !acceptQuest && questTwentyFiveComplete) {
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
		}
		if (posInDialogue == 57 && !dialogueSoundPlay) {
			uiMissionBox.SetActive (false);
			uiMissionText.SetActive (false);
			uiQuestTwentyFive.SetActive (false);
			//dialogueSoundPlay = false;
			if (!dialogueSoundPlay) {
				dialogueSoundPlay = true;
				chadDialogueSound.Play ();
			}
			uiQuestOutline.SetActive (false);
			completeMissionText.SetActive (false);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (true);
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		//Dialogue
		if (posInDialogue == 58 && dialogueSoundPlay) {
			uiQuestOutline.SetActive (false);
			dialogueSoundPlay = false;
			if (!dialogueSoundPlay) {
				//dialogueSoundPlay = true;
				borkDialogueSound.Play ();
			}
			pressEText.SetActive (true);
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToNml ();
		}
		if (posInDialogue == 59 && !acceptQuest && !questTwentySixComplete) {
			acceptQuest = true;
			turtleTalk = true;
			colorControl.endColor = Color.red;
			uiMissionBox.SetActive (true);
			uiMissionText.SetActive (true);
			uiQuestTwentySix.SetActive (true);
			completeMissionText.SetActive (false);
			uiQuestOutline.SetActive (true);
			incompleteMissionText.SetActive (true);
			returnToBorkText.SetActive (false);
			pressEText.SetActive (false);
			chadLocOriginWithRigid.SetActive(true);
			chadLocOriginWithRigid.GetComponent<Rigidbody> ().isKinematic = true;
			chadLocOriginWithNo.SetActive (false);
			eelTalk = false;
		} else if (posInDialogue == 59 && acceptQuest && !questTwentySixComplete) {
			borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToNml ();
			pressEText.SetActive (false);
		} else if (posInDialogue == 59 && !acceptQuest && questTwentySixComplete) {
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
			pressEText.SetActive (true);
			if (Input.GetKeyDown ("e")) {
				SceneManager.LoadScene (sceneTemp.name);
			}
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
					uiBoxOutline.SetActive (false);
				} else if (posInDialogue == 1 && acceptQuest && !questZeroComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				} else if (posInDialogue == 5 && acceptQuest && !questTwoComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				} else if (posInDialogue == 7 && acceptQuest && !questThreeComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				} else {
					tutText.text = "";
					uiBoxOutline.SetActive (true);
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
		} else if (borkAttached && !turtleTalk && !sealTalk && !eelTalk) {
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
					uiBoxOutline.SetActive (false);
				} else if (posInDialogue == 5 && acceptQuest && !questTwoComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				} else if (posInDialogue == 7 && acceptQuest && !questThreeComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				} else if (posInDialogue == 9 && acceptQuest && !questFourComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				}
				else if (posInDialogue == 11 && acceptQuest && !questFiveComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				}
				else if (posInDialogue == 13 && acceptQuest && !questSixComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				}
				else if (posInDialogue == 15 && acceptQuest && !questSevenComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				}
				else if (posInDialogue == 17 && acceptQuest && !questEightComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				}
				else if (posInDialogue == 20 && acceptQuest && !questNineComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				}
				else if (posInDialogue == 22 && acceptQuest && !questTenComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				}
				else if (posInDialogue == 24 && acceptQuest && !questElevenComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				}
				else if (posInDialogue == 31 && acceptQuest && !questThirteenComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				}
				else if (posInDialogue == 32 && acceptQuest && !questFourteenComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				}
				else if (posInDialogue == 37 && acceptQuest && !questSixteenComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				}
				else if (posInDialogue == 47 && acceptQuest && !questTwentyOneComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				}
				else if (posInDialogue == 56 && acceptQuest && !questTwentyFiveComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				}


				else {
					tutText.text = "";
					uiBoxOutline.SetActive (true);
					narrTextTrigger [posInDialogue] = false;
					StartCoroutine (spellItOut ());
				}
			}
			else if (Input.GetKeyDown ("e") && borkAttached && !acceptQuest && narrTextTrigger [posInDialogue + 1]) {
				posInDialogue++;
			}

		} else if (borkAttached && !turtleTalk && sealTalk && !eelTalk) {

			if (!acceptQuest) {
				tutorialText.SetActive (true);
				tutorialBox.SetActive (true);
			} else {
				tutorialText.SetActive (false);
				tutorialBox.SetActive (false);
			}
			if (narrTextTrigger [posInDialogue]) {
				if (posInDialogue == 33 && acceptQuest && !questFifteenComplete) {
					uiBoxOutline.SetActive (false);
					narrTextTrigger [posInDialogue] = false;
				}
				else if (posInDialogue == 32 && acceptQuest && !questFourteenComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				}else if (posInDialogue == 37 && acceptQuest && !questSixteenComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				}
				else if (posInDialogue == 38 && acceptQuest && !questSeventeenComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				}
				else if (posInDialogue == 40 && acceptQuest && !questEighteenComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				}
			
				else {
					tutText.text = "";
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (true);
					StartCoroutine (spellItOut ());
				}
			}
			else if (Input.GetKeyDown ("e") && inRangeToIntSeal && !acceptQuest && narrTextTrigger [posInDialogue + 1]) {
				posInDialogue++;
			}

		}
		else if (borkAttached && turtleTalk && !sealTalk && !eelTalk) {

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
					uiBoxOutline.SetActive (false);
				}else if (posInDialogue == 25 && acceptQuest && !questTwelveComplete) {
					uiBoxOutline.SetActive (false);
					narrTextTrigger [posInDialogue] = false;
				}
				else if (posInDialogue == 42 && acceptQuest && !questNineteenComplete) {
					uiBoxOutline.SetActive (false);
					narrTextTrigger [posInDialogue] = false;
				}
				else if (posInDialogue == 45 && acceptQuest && !questTwentyComplete) {
					uiBoxOutline.SetActive (false);
					narrTextTrigger [posInDialogue] = false;
				}else if (posInDialogue == 56 && acceptQuest && !questTwentyFiveComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				}
				else if (posInDialogue == 59 && acceptQuest && !questTwentySixComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				}

				else {
					tutText.text = "";
					uiBoxOutline.SetActive (true);
					narrTextTrigger [posInDialogue] = false;
					StartCoroutine (spellItOut ());
				}
			}
			else if (Input.GetKeyDown ("e") && inRangeToIntChad && !acceptQuest && narrTextTrigger [posInDialogue + 1]) {
				posInDialogue++;
			}

		}
		else if (borkAttached && !turtleTalk && !sealTalk && eelTalk) {
			Debug.Log ("shoudl be hurr");
			if (!acceptQuest) {
				tutorialText.SetActive (true);
				tutorialBox.SetActive (true);
			} else {
				tutorialText.SetActive (false);
				tutorialBox.SetActive (false);
			}
			if (narrTextTrigger [posInDialogue]) {
				if (posInDialogue == 48 && acceptQuest && !questTwentyTwoComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				}
				else if (posInDialogue == 52 && acceptQuest && !questTwentyThreeComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				}
				else if (posInDialogue == 53 && acceptQuest && !questTwentyFourComplete) {
					narrTextTrigger [posInDialogue] = false;
					uiBoxOutline.SetActive (false);
				}
				else {
					tutText.text = "";
					uiBoxOutline.SetActive (true);
					narrTextTrigger [posInDialogue] = false;
					StartCoroutine (spellItOut ());
				}
			}
			else if (Input.GetKeyDown ("e") && inRangeToIntEel && !acceptQuest && narrTextTrigger [posInDialogue + 1]) {
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
		if (dist <= 100) {
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

			}

		} else {
			GameObject.FindWithTag("BorkNPCLocation").GetComponent<NPCHighlighting>().changeMatToNml();
			inRangeToHear = false;
		}
	}

	void distanceNotifyChad(){
		if (posInDialogue == 59) {
			dist = (int)Vector3.Distance (player.transform.position, chadLocOriginWithRigid.transform.position);
		} else {
			dist = (int)Vector3.Distance (player.transform.position, chadLocOriginWithNo.transform.position);
		}

		if (dist <= 200) {
			//Debug.Log ("in range to hear Chad <= 200");
			inRangeToHearChad = true;
			if (dist <= 200) {
				inRangeToIntChad = true;
				if (posInDialogue == 59) {
					
					chadLocOriginWithRigid.GetComponent<NPCHighlighting> ().changeMatToHL ();
				} else {
					chadLocOriginWithNo.GetComponent<NPCHighlighting> ().changeMatToHL ();
				}
				if (!acceptQuest)
					pressEText.SetActive (true);
				else
					pressEText.SetActive (false);
			} else {
				pressEText.SetActive (false);
				inRangeToIntChad = false;
				if (posInDialogue == 59) {

					chadLocOriginWithRigid.GetComponent<NPCHighlighting> ().changeMatToNml ();
				} else {
					chadLocOriginWithNo.GetComponent<NPCHighlighting> ().changeMatToNml ();
				}
			}

		} else {
			inRangeToHearChad = false;
			inRangeToIntChad = false;
			if (posInDialogue == 59) {

				chadLocOriginWithRigid.GetComponent<NPCHighlighting> ().changeMatToNml ();
			} else {
				chadLocOriginWithNo.GetComponent<NPCHighlighting> ().changeMatToNml ();
			}
		}
	}
	void distanceNotifySealDad(){
		dist = (int)Vector3.Distance (player.transform.position, sealLocOrigin.transform.position);
		if (dist <= 150) {
			inRangeToHearSeal = true;
			if (dist <= 150) {
				inRangeToIntSeal = true;

				sealLocOrigin.GetComponent<NPCHighlighting>().changeMatToHL ();
				if (!acceptQuest)
					pressEText.SetActive (true);
				else
					pressEText.SetActive (false);
			} else {
				pressEText.SetActive (false);
				inRangeToIntSeal = false;
				sealLocOrigin.GetComponent<NPCHighlighting>().changeMatToNml();
			}

		} else {
			inRangeToHearSeal= false;
			inRangeToIntSeal = false;
			sealLocOrigin.GetComponent<NPCHighlighting>().changeMatToNml();
		}
	}
	void distanceNotifyEel(){
		dist = (int)Vector3.Distance (player.transform.position, eelLocOrigin.transform.position);
		if (dist <= 150) {
			inRangeToHearEel = true;
			if (dist <= 150) {
				inRangeToIntEel = true;

				eelLocOrigin.GetComponent<NPCHighlighting>().changeMatToHL ();
				if (!acceptQuest)
					pressEText.SetActive (true);
				else
					pressEText.SetActive (false);
			} else {
				pressEText.SetActive (false);
				inRangeToIntEel = false;
				eelLocOrigin.GetComponent<NPCHighlighting>().changeMatToNml();
			}

		} else {
			inRangeToHearEel = false;
			inRangeToIntSeal = false;
			eelLocOrigin.GetComponent<NPCHighlighting>().changeMatToNml();
		}
	}


	void OnTriggerExit(Collider other){
		if(other.gameObject == player)
		{
			tutorialText.SetActive (false);
			tutorialBox.SetActive (false);
		}
	}
	IEnumerator waitForFirstDialogueTrigger (float x){
		yield return new WaitForSeconds (x);
		firstDialogueTrigger = true;
		posInDialogue = 0;
		pressEText.SetActive (true);
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
	void speakWithChad(){
		if(inRangeToIntChad && Input.GetKeyDown("e") && acceptQuest && !questTwelveComplete){
			//Debug.Log ("hasspokentoChadone = true");
			interactWithChadOne = true;
		}
		else if(inRangeToIntChad && Input.GetKeyDown("e") && acceptQuest && posInDialogue == 42){
			//Debug.Log ("hasspokentoChadone = true");
			interactWithChadTwo = true;
		}
		else if(inRangeToIntChad && Input.GetKeyDown("e") && acceptQuest && posInDialogue == 56){
			//Debug.Log ("hasspokentoChadone = true");
			visitLastTime = true;
		}
	}
	void speakWithSeal(){
		if(inRangeToIntSeal && Input.GetKeyDown("e") && acceptQuest && !questFifteenComplete){
			//Debug.Log ("hasspokentosealone = true");
			interactWithSealOne = true;
		}
		else if(inRangeToIntSeal && Input.GetKeyDown("e") && acceptQuest && !questSeventeenComplete && questFifteenComplete && questSixteenComplete){
			//Debug.Log ("hasspokentosealone = true");
			interactWithSealTwo = true;
		}
	}
	void speakWithEel(){
		if(inRangeToIntEel && Input.GetKeyDown("e") && acceptQuest && !questTwentyTwoComplete){
			//Debug.Log ("hasspokentosealone = true");
			interactWithEelOne = true;
		}
		else if(inRangeToIntEel && Input.GetKeyDown("e") && acceptQuest && !questTwentyFourComplete){
			//Debug.Log ("hasspokentosealone = true");
			interactWithEelTwo = true;
		}
	}
	void jumpAhead(){
		player.transform.localPosition = new Vector3 (747.0f, 562.3f, 1105.9f);
		narrTextTrigger [0] = false;
		narrTextTrigger [1] = false;
		posInDialogue = 59;
		questZeroComplete = true;
		questOneComplete = true;
		questTwoComplete = true;
		questThreeComplete = true;
		questFourComplete = true;
		questFiveComplete = true;
		questSixComplete = true;
		questSevenComplete = true;
		questEightComplete = true;
		questNineComplete = true;
		questTenComplete = true;
		questElevenComplete = true;
		questThirteenComplete = true;
		questFourteenComplete = true;
		questFifteenComplete = true;
		questSixteenComplete = true;
		questSeventeenComplete = true;
		questEighteenComplete = true;
		questNineteenComplete = true;
		questTwentyComplete = true;
		questTwentyOneComplete = true;
		questTwentyTwoComplete = true;
		questTwentyThreeComplete = true;
		questTwentyFourComplete = true;
		questTwentyFiveComplete = true;
		completeMissionText.SetActive (true);
		broughtDaPillow = true;
		interactWithChadTwo = true;
		interactWithEelOne = true;
		interactWithEelTwo = true;
		returnToBorkText.SetActive (false);
		isEgg = false;
		borkAttached = true;
		hasPressedEveryKey = true;
		isGlassBroken = true;
		gateIsOpen = true;
		inCavern = true;
		hasInked = true;
		hasSped = true;
		hasSanic = true;
		hasEmp = true;
		hasEnteredTemple = true;
		hasEnteredReef = true;
		hasEnteredVolcVicinity = true;
		inRangeToSeeChad = true;
		inRangeToSeeEel = true;
		interactWithChadOne = true;
		interactWithSealOne = true;
		interactWithSealTwo = true;
		barracudaKilled = true;
		hasEnteredKGY = true;
		broughtDaMilk = true;
		//acceptQuest = true;
		anglersKilled = true;
		beautyKitFound = true;
		GameObject.FindGameObjectWithTag("Player").GetComponent<Abilities>().speedIcon.enabled = true;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().abilities [0] = true;
		GameObject.FindGameObjectWithTag("Player").GetComponent<Abilities>().inkIcon.enabled = true;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().abilities [1] = true;
		GameObject.FindGameObjectWithTag("Player").GetComponent<Abilities>().currentIcon.enabled = true;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().abilities [2] = true;
		GameObject.FindGameObjectWithTag("Player").GetComponent<Abilities>().empIcon.enabled = true;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<Abilities> ().abilities [3] = true;
		egg.SetActive (false);
		plateNoScript.SetActive (false);
		plateWithScript.SetActive (true);
		//brokenGlassTube.SetActive (true);
		isGlassBroken = true;
		borkObjectAttached.SetActive (true);
		//acceptQuest = true;
		borkObjectUnattached.SetActive (false);
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
		narrText [0] = "Bork: It would be very helpful if you were to hatch sometime soon. [E]";
		narrText [1] = "Bork: You are intelligent, and very interesting looking. Regardless, break me out of this strange prison, something is wrong with the fish in this ocean. [E]";
		narrText [2] = "Bork: Find a box or book, pick it up [Hold LMB], and toss it at this glass [While holding LMB, press RMB]. [E]";
		narrText [3] = "Bork: How charming of you to throw glass everywhere. Well, let's get to it I suppose. [E]";
		narrText [4] = "Bork: Let's get out of this lab, head towards that blasted gate. [E]";
		narrText [5] = "Bork: Neat, now let's leave this decrepit place. [E]";
		narrText [6] = "Bork: Let's move into the cavern, you are quite weak and there are some things you need to learn. [E]";
		narrText [7] = "Bork: Ah, it's just as a I remember it from twenty minutes ago... turquoise.  [E]";
		narrText [8] = "Bork: Behold, I have unlocked your inking potential by fiddling with your brain! Activate your Inking ability [1] and use it [Space]. [E]";
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
		narrText [24] = "Bork: Ugh, its Chad... this will be interesting. [E]";
		narrText [25] = "Bork: Chad, we've talked about this man... you cannot whole up in the volcano like this, it ruins everyone's day. [E]";
		narrText [26] = "Chad: Bork do you wanna not? I was napping on this here hot vent. There was this awesome button in here that turned it on and it's just delightful. [E]";
		narrText [27] = "Bork: Chad, you are like 400 years old, how do you not know what turning that button on does? [E]";
		narrText [28] = "Chad: I care not for those heinous fish, they aren't my problem they cannot hurt this here shell? [E]";
		narrText [29] = "Bork: Ugh, what a prick. Come on, he won't leave this hole himself, we have to move him ourselves, and honestly you are in no state to do so yourself. [E]";
		narrText [30] = "Bork: We have to bulk you up, and I know the perfect meathead. He is somewhere in the kelpforest and we gotta get through that reef again. [E]";
		narrText [31] = "Bork: This seems to be on the right track, Seal Dad will be a bit farther in, be on the lookout for sugar crystals, he loves those things. [E]";
		narrText [32] = "Bork: Ah there he is, let's go talk to him about Chad. [E]";
		narrText [33] = "Seal Dad: Who's this little lad? [E]";
		narrText [34] = "Bork: I'm not honestly not sure what he is called but he has very weak arms, and Chad is being an abomination at the moment. [E]";
		narrText [35] = "Seal Dad: Even in my age I can see from here that he is no definition in his tentacles, and yes I could hear Chad from here... gosh darn turtle ruining my afternoon. [E]";
		narrText [36] = "Seal Dad: I got the medicine for this, you gotta get Chad out of that, and I need dinner. Kill 3 Barracudas and come back to me, after that we will talk more about bulking you up. [E]";
		narrText [37] = "Bork: That was actually nasty... but good job, you've proved you are not incompetent, let's head back to Seal Dad. [E]";
		narrText [38] = "Seal Dad: Now that you have worked them muscles, we need protein for growth. [E]";
		narrText [39] = "Seal Dad: Procure the milk and set it down on this here orange rock, we shall share a pint together and praise Brodin. The milk will be near the amber crystals in the far corner of the kelp forest. [E]";
		narrText [40] = "Seal Dad: Hot damn you did it, now quench thy thirst and drink up, for your muscles and bone will grow strong. [E]";
		narrText [41] = "Bork: Heavens, you look kinda cool now I will admit, let's go back and speak to Chad and see if we can get him to budge with our new strength. [E]";
		narrText [42] = "Bork: Alright... you, let's to talk chad out of there. [E]";
		narrText [43] = "Bork: Chad, bruh seriously things are not okay around here and you are literally the only thing causing it. [E]";
		narrText [44] = "Chad: Alright fine, grab my pillow and bring it to this here rock of mine, and kill me some tunas. The pillow is somewhere on the other side of this volcano. If you do this i'll take my spice elsewhere. [E]";
		narrText [45] = "Chad: Wow, you actually did it. Ha! Thanks for the pillow Chump, you and your jellyfish can stick it, I am not going anywhere. [E]";
		narrText [46] = "Bork: Dear Lord Chad you are actually a barnacle on this world, truly. Come on, we really only have one choice left and its in the Kraken Graveyard. [E]";
		narrText [47] = "Bork: Well I bet this is dreary for you, anyway Eel-Chan seems to like purple these days, I would say find the biggest cluster of them and see if we can draw her out. [E]";
		narrText [48] = "Bork: Eel-Chan, how you doin my slithery beauty? [E]";
		narrText [49] = "Eel-Chan: Please look away, I am hideous! Those blasted anglers seem to have run off with my beauty kit and even worse they are flaunting their light on unfetchingness. [E]";
		narrText [50] = "Bork: Could... you just deal with it and make this dingus pretty? Chad is the reason the anglers stole your things, he is using the volcano as a personal sauna. [E]";
		narrText [51] = "Eel-Chan: Bork you are being very insensitive right now, and Chad even more so, if you happen to return my kit and deal with some of those anglers I will help you. [E]";
		narrText [52] = "Bork: Nice job, your'e really not so bad. Let's get this back to Eel Chan, though I am really not sure how much this will help us. [E]";
		narrText [53] = "Bork: Eel Chan, we have your beauty kit, will you help us now? [E]";
		narrText [54] = "Eel Chan: Oh I suppose, here. A dab there a smudge there and bam youre not terrible looking! [E]";
		narrText [55] = "Bork: Good lord, you look actually spooky, I am sure this will be more than enough to scare Chad out of hiding, and if not then just give him a good toss! [E]";
		narrText [56] = "Bork: Chad, we are gonna give you one last chance! Vacate that hole or we will vacate you ourselves. [E]";
		narrText [57] = "Chad: You wouldn't dare! No one would dare disturb such a kindly turtle on a day like this! [E]";
		narrText [58] = "Bork: Have you met you? You know what we are done, squidlad, take care of this chump, and let's turn off that damn button. [E]";
		narrText [59] = "Bork: Cool, you win. [E]";
	}




}
