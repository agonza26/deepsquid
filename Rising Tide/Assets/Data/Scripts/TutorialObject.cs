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

	//0 = ink
	//1 = current
	//2 = emp
	//3 = death
	private bool[] fishQuestCheck = new bool[4];

	private bool speakWithBorkOne;
	private bool speakWithBorkTwo;
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
		if (posInDialogue == 1) {
			speakWithBork ();
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
		else if (fishStats.getTargetProgress () >= 5 && !questTwentyThreeComplete && posInDialogue == 52&& acceptQuest) {
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
		else if (fishStats.getTargetProgress () >= 3 && !questSixteenComplete) {
			uiQuestSixteenTwo.SetActive (false);
			barracudaKilled = true;
		}

		//Debug.Log (posInDialogue);
		inCavern = GameObject.Find("Cavern").GetComponent<LocationTracking>().here;
		if (posInDialogue == 17) {
			hasEnteredTemple = GameObject.Find ("TempleLoc").GetComponent<LocationTracking> ().here;
		}
		if (posInDialogue == 20) {
			hasEnteredReef = GameObject.Find ("ReefLoc").GetComponent<LocationTracking> ().here;
		}
		hasEnteredVolcVicinity = GameObject.Find("VolcLoc").GetComponent<LocationTracking>().here;
		if (posInDialogue == 31) {
			hasEnteredKelpForest = GameObject.Find ("KelpLoc").GetComponent<LocationTracking> ().here;
		}
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
		if (!borkAttached) {
			distanceNotify ();
		}

		if (speakWithBorkOne && inRangeToInt && acceptQuest && !questZeroComplete && posInDialogue == 1) {
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
			//borkObjectAttached.GetComponent<NPCHighlighting> ().changeMatToHL ();

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
		if (fishQuestCheck[3] && acceptQuest && !questThreeComplete && questTwoComplete) {
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
		if (fishQuestCheck[0] && acceptQuest && !questFourComplete && questThreeComplete) {
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
		if (fishQuestCheck[1] && acceptQuest && !questSixComplete && questFiveComplete) {
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
		if (fishQuestCheck[2] && acceptQuest && !questSevenComplete && questSixComplete) {
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
			uiQuestSixteen.SetActive (false);
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
			//pressEText.SetActive (true);
			uiQuestOutline.SetActive (true);
			incompleteMissionText.SetActive (true);

		}
		//complete quest zero
		if (posInDialogue == 2) {
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
			//Try jumping over quest ten here
			/*
			posInDialogue = 24;
			hasEnteredVolcVicinity = true;
			acceptQuest = false;
			*/
			//GameObject.FindGameObjectWithTag("borkAttached").GetComponent<NPCHighlighting> ().changeMatToHL ();
		}
		//Quest Ten
		//REmove This one
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
			//sealTalk = false;
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
			sealTalk = false;
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
		if (firstDialogueTrigger && !borkAttached) {
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
			} else if (Input.GetKeyDown ("e") && inRangeToInt && !acceptQuest && narrTextTrigger [posInDialogue + 1] && !questOneComplete && posInDialogue != 1) {
				posInDialogue++;
				Debug.Log ("one");
			} 
			else if (Input.GetKeyDown ("e") && inRangeToInt && speakWithBorkTwo && !acceptQuest && narrTextTrigger [posInDialogue + 1] && !questOneComplete && posInDialogue == 1) {
				posInDialogue++;
				Debug.Log ("one");
			} 
			else if (Input.GetKeyDown ("e") && !borkAttached && !acceptQuest && narrTextTrigger [posInDialogue + 1] && questOneComplete) {
				Debug.Log ("two");
				posInDialogue++;
			} else if (Input.GetKeyDown ("e") && borkAttached && !acceptQuest && narrTextTrigger [posInDialogue + 1] && questOneComplete) {
				posInDialogue++;
				Debug.Log ("three");
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
		if (dist <= 20) {
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
			pressEText.SetActive (false);
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
	void speakWithBork(){
		if(inRangeToInt && Input.GetKeyDown("e") && acceptQuest && !questZeroComplete){
			speakWithBorkOne = true;
		}
		else if(inRangeToInt && Input.GetKeyDown("e") && !acceptQuest && questZeroComplete){
			speakWithBorkTwo = true;
		}
	}
	void jumpAhead(){
		player.transform.localPosition = new Vector3 (-219.0f, 450.3f, 690.9f);
		narrTextTrigger [0] = false;
		narrTextTrigger [1] = false;
		posInDialogue = 20;
		questZeroComplete = true;
		questOneComplete = true;
		questTwoComplete = true;
		questThreeComplete = true;
		questFourComplete = true;
		questFiveComplete = true;
		questSixComplete = true;
		questSevenComplete = true;
		questEightComplete = true;
		acceptQuest = false;
		//questNineComplete = true;
		/*
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
		questTwentyFiveComplete = true;*/
		//completeMissionText.SetActive (true);
		/*
		broughtDaPillow = true;
		interactWithChadTwo = true;
		interactWithEelOne = true;
		interactWithEelTwo = true;
		returnToBorkText.SetActive (false);
		*/
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
		fishQuestCheck [0] = true;
		fishQuestCheck [1] = true;
		fishQuestCheck [2] = true;
		fishQuestCheck [3] = true;
		/*
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
		*/
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

	public void abilityUsageCheck (string boobies){
		switch (boobies) {
		case "ink":
			fishQuestCheck [0] = true;
			break;
		case "current":
			fishQuestCheck [1] = true;
			break;
		case "emp":
			fishQuestCheck [2] = true;
			break;
		case "kill":
			fishQuestCheck [3] = true;
			break;

		}
	}


	void fillNarrativeString(){
		narrTextTrigger [0] = true;
		narrText [0] = "Bork: Someone please help! Something has trapped me in this heinous prison and I have no way to escape! [E]";
		narrText [1] = "Bork: Ah a Squidling! Release me from this prison, and we can work together to get out of here. [E]";
		narrText [2] = "Bork: Look for an object to throw, perhaps a box or book and toss it at the glass to free me. [E]";
		narrText [3] = "Bork: Great work, now I am just going to have a seat on your head and we can be off. [E]";
		narrText [4] = "Bork: Now, last I knew the gate to this strange place closed behind me, we need a way to open it to get out of here. [E]";
		narrText [5] = "Bork: Fantastic, now I can imagine you are quite hungry, so let's head out of here into the cavern so we can get you something to eat. [E]";
		narrText [6] = "Bork: Oh, looks like breakfast has come to us, I sense there is a fish at the entrance to the cavern, let's eat! [E]";
		narrText [7] = "Bork: Delicious, though that was rather odd the way he was behaving... I am weary that there is something wrong here. But now that you have eaten, let's learn some things.  [E]";
		narrText [8] = "Bork: If I remember correctly, your kind have certain potentials. Try activating your Inking ability [1] and using it on a fish [Space]. [E]";
		narrText [9] = "Bork: Very good, you can use this Ink to stop fish in their tracks. [E]";
		narrText [10] = "Bork: Your kind are also very quick on their tentacles, try activating your movement ability [2] and while moving and use it [Space]. [E]";
		narrText [11] = "Bork: Wow! You are exceptionally quick. That can be very useful to make a quick getaway from hostiles. [E]";
		narrText [12] = "Bork: Squids are also rather adept at sonic waves, this ability [3] will confuse fish and compel them to swim away from you. Try it out on a fish now [Space]. [E]";
		narrText [13] = "Bork: Wow, that is actually very impressive to see in person. [E]";
		narrText [14] = "Bork: Your final ability is also the most powerful, it is an Electro Magnetic Pulse, activate it [4] and use it on some fish [Space]. [E]";
		narrText [15] = "Bork: The EMP ability is useful when it comes to stopping enemies in their tracks and dealing a massive amount of damage. [E]";
		narrText [16] = "Bork: Each of your abilities will drain your stamina, and will take time to recharge for further use. Now that you have some footing I fear that something is sincerely wrong, the fish are not normally this hostile. [E]";
		narrText [17] = "Bork: This temple must be ages old... there must be a way out of here. [E]";
		narrText [18] = "Bork: Ah, look up! There is a hole in the ceiling. [E]";
		narrText [19] = "Bork: Please take care out in the world, we are attached now and I would like to see my bed at the end of the day. [E]";
		narrText [20] = "Bork: Ah, yes things are worse than I feared, hopefully my friends are okay. It looks like most of the fish have turned hostile";
		narrText [21] = "Bork: Let's move through this reef towards the volcano in the far distance and see if my suspicion are correct, red crystals will guide your way there. [E]";
		narrText [22] = "Bork: Normally things are rather dull, but considering how every fish seems to see us as en enemy I feel that it must be the volcano causing this, but no one would turn that volcano on.... [E]";
		narrText [23] = "Bork: Ah... I see yes it looks like I was unfortunately correct... let's go turn it off so we can go about our daily lives without fear of being mugged. [E]";
		narrText [24] = "Bork: Ugh, it's Chad... who else would have done this. This should be an interesting encounter. [E]";
		narrText [25] = "Bork: Chad, you cannot whole up in the volcano and treat it as a personal sauna, we have talked about this. [E]";
		narrText [26] = "Chad: Bork, relax man. I am not hurting anyone by chilling here. This hot vent is awesome though, isn't it? You should try it!. [E]";
		narrText [27] = "Bork: Chad,  we had this conversation last week, how do you not remember the implications of turning the volcano on, it turns all the fish hostile. [E]";
		narrText [28] = "Chad: Ah, they can't hurt me though man! Relax I am perfectly safe here! [E]";
		narrText [29] = "Bork: He simply never learns. Come on, he won't leave this hole himself, so we will have to do it. However, you are in no state to do so yourself in your current state. [E]";
		narrText [30] = "Bork: You're gonna have to get a bit stronger first and I know the perfect meathead. He is somewhere in the Kelp Forest which is back towards the entrance to the reef. [E]";
		narrText [31] = "Bork: This seems to be on the right track, Seal Dad will be a bit farther in, be on the lookout for sugar crystals, he loves those. [E]";
		narrText [32] = "Bork: Ah there he is, let's go talk to him about helping us out with Chad. [E]";
		narrText [33] = "Seal Dad: Who's this little lad? [E]";
		narrText [34] = "Bork: I'm not honestly not sure, we never fully exchanged names, he just hatched and is still pretty weak. Normally this is just fine, but Chad is being nuisance. [E]";
		narrText [35] = "Seal Dad: Yes, I can see from here that he is no definition in his tentacles, and yes I could hear your conversation with Chad from here... gosh darn turtle ruining my afternoon. [E]";
		narrText [36] = "Seal Dad: I got the medicine for this, you gotta get Chad out of that, and I need dinner. Kill 3 Barracudas for me and come back, after that we will talk more about bulking you up. [E]";
		narrText [37] = "Bork: You fight in a very grotesque way but you've already improved vastly, let's head back to Seal Dad. [E]";
		narrText [38] = "Seal Dad: Now that you have worked them muscles, we need protein for growth. [E]";
		narrText [39] = "Seal Dad: Procure some discus milk and set it down on this here orange rock, we shall share a pint together. The milk should be near the amber crystals in the far corner of the kelp forest. [E]";
		narrText [40] = "Seal Dad: Delicious Discus Milk! Now quench thy thirst and drink up, for your muscles and bone will grow large and strong. [E]";
		narrText [41] = "Bork: Heavens, I will admit you look pretty cool, this might be enough to move Chad. Let's head back over to him and try to reason him out of there with our new strength. [E]";
		narrText [42] = "Bork: Look at him, still as frustratingly carefree as he was before. [E]";
		narrText [43] = "Bork: Chad, seriously things are not safe for most of us out here and you are the one thing causing it. [E]";
		narrText [44] = "Chad: Alright fine, if you can grab my pillow and bring it to this here rock of mine I might consider vacating. The pillow is somewhere on the other side of this volcano. If you do this i'll take my spice elsewhere. [E]";
		narrText [45] = "Chad: Wow, you actually did it. Well thanks for the pillow man you didn't have to do that. I am not gonna take a nap now...zzz. [E]";
		narrText [46] = "Bork: Did he seriously just fall asleep? This is incredibly frustrating.... Come on, we really only have one choice left and she is in the Squid Grav.. Place. [E]";
		narrText [47] = "Bork: Wow these are really interesting rocks right...? Right? Anyway Eel-Chan seems to find purple fetching these days, I would say find the biggest cluster of them and see if we can draw her out. [E]";
		narrText [48] = "Bork: Eel-Chan, how are you doin my beauty? [E]";
		narrText [49] = "Eel-Chan: Aww Bork you charmer! Well I am not well, those blasted anglers just decided to run off with my beauty kit and I haven't had a chance to do myself up yet. [E]";
		narrText [50] = "Bork: Could we help in some way? We need your help, Chad is using the volcano as a personal suana and the reason the anglers stole your things. [E]";
		narrText [51] = "Eel-Chan: That makes so much sense now! Yes, please, if you could return my turquoise Seafora case, and deal with some of those anglers I will help you. [E]";
		narrText [52] = "Bork: Man that was ugly, I hate doing things like this. Let's get this back to Eel-Chan. [E]";
		narrText [53] = "Bork: Eel-Chan, we have your beauty kit, now will you help us stop Chad's escapade? [E]";
		narrText [54] = "Eel Chan: Oh I suppose, here. A dab of fabulous there, a smudge of stoic here, and just a hint of sexy and bam you're just fetching! [E]";
		narrText [55] = "Bork: Good lord, you lord you're no squid are you? You might be one of their ancestors, the Kraken! I am sure you are more than enough to convince Chad to vacate the volcano, and if not then just give him a good toss! [E]";
		narrText [56] = "Bork: Chad, we are gonna give you one last chance! The ocean is no longer safe and we cannot handle your shenanigans. Vacate that volcano or we will evict you ourselves. [E]";
		narrText [57] = "Chad: Hey man, now you're just being rude! Here I am, minding my own business and you guys just want to bully me! [E]";
		narrText [58] = "Bork: You know that's it, this here Kraken is gonna take good care of you. [E]";
		narrText [59] = "Bork: Wonderful, now everything is well in the world! The fish are no longer hostile and now I can live my afternoon in peace, thank you kind Kraken. [E]";
	}




}
