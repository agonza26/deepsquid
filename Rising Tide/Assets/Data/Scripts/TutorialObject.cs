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
	private GameObject uiQuestOne;
	private GameObject uiMissionText;
	private GameObject uiMissionBox;
	private Mesh squidMesh;
	private Mesh tempMesh;
	private Mesh eggMesh;
	private bool dialogStarted = false;
	private bool inLOS = false;
	private bool inRangeToHear = false;
	private bool inRangeToInt = false;
	private bool inLOS_inRange = false;
	public float letterPause;
	public string[] narrText = new string[200];
	public bool[] narrTextTrigger = new bool[200];
	private int posInDialogue;
	private int posInDialogueHolder;
	private bool firstDialogueTrigger = false;
	private bool tooltipStamCom = false;
	private bool tooltipInProgress = false;
	public bool isEgg = true;
	public bool hasGrabbed = false;
	public bool hasGrabbedCheck = false;
	private bool acceptQuest = false;
	private int dist;
	private int distToInteract;


	void Start(){
		fillNarrativeString ();
		tutText = tutorialText.GetComponent<Text> ();
		uiQuestOne = GameObject.FindGameObjectWithTag ("uiQuestOne");
		uiQuestOne.SetActive (false);
		uiMissionText = GameObject.FindGameObjectWithTag ("uiMissionText");
		uiMissionText.SetActive (false);
		uiMissionBox = GameObject.FindGameObjectWithTag ("uiQuestBox");
		uiMissionBox.SetActive (false);

		player = GameObject.FindGameObjectWithTag("Player");
		egg = GameObject.FindGameObjectWithTag ("krakenEgg");
		tutorialText.SetActive (false);
		tutorialBox.SetActive (false);
		//rt = tutorialText.GetComponent<RectTransform> ();
	}


	void Update ()
	{
		distanceNotify ();

		if (isEgg) {
			if (!dialogStarted) {
				dialogStarted = true;
				StartCoroutine (waitForFirstDialogueTrigger (1f));
			}
		}

		if (inLOS && inRangeToHear) {
			inLOS_inRange = true;
		} else {
			inLOS_inRange = false;
		}

		if ((inLOS_inRange || inRangeToHear && firstDialogueTrigger)) {
			//If youve accepted a quest, turn off the textbox. else keep it up while youre in range and los
			Debug.Log("inrangeInt, acceptQuest, tooltipinprogress: " + inRangeToInt + "," + acceptQuest + "," + tooltipInProgress);
			Debug.Log("hasgrabbedcheck, tooltipStamCom, tooltipinprogress: " + hasGrabbedCheck + "," + tooltipStamCom + "," + tooltipInProgress);
			Debug.Log (posInDialogue);
			if (!acceptQuest || tooltipInProgress) {
				tutorialText.SetActive (true);
				tutorialBox.SetActive (true);
			} else {
				tutorialText.SetActive (false);
				tutorialBox.SetActive (false);
			}

			if (narrTextTrigger [posInDialogue]) {
				tutText.text = "";
				narrTextTrigger [posInDialogue] = false;
				StartCoroutine (spellItOut ());

			}
			if (hasGrabbed) {
				
				if (!hasGrabbedCheck) {
					tooltipInProgress = true;
					hasGrabbedCheck = true;
					posInDialogueHolder = posInDialogue;
					narrTextTrigger [posInDialogueHolder+1] = false;
					posInDialogue = 100;
					narrTextTrigger [posInDialogue] = true;
					narrTextTrigger [posInDialogue+1] = true;
				}
			}
			if (Input.GetKeyDown ("e") && narrTextTrigger [posInDialogue + 1]) {
				//Debug.Log ("Pressing E and narrTextTrigger pos+! is true");
					if (isEgg) {
						if (posInDialogue == 0) {
							posInDialogue++;
						} else {
							isEgg = false;
							egg.SetActive (false);
							posInDialogue++;
						}
				} else if (hasGrabbedCheck && !tooltipStamCom && tooltipInProgress) {
						tooltipInProgress = false;
						tooltipStamCom = true;
						narrTextTrigger [posInDialogue] = false;
						narrTextTrigger [posInDialogue + 1] = false;
						posInDialogue = posInDialogueHolder;
						narrTextTrigger [posInDialogue] = true;
						narrTextTrigger [posInDialogue+1] = true;
				} else if (inRangeToInt && !acceptQuest && !tooltipInProgress) {
					//Debug.Log ("inrangeto int, !acceptquest, !tooltipinProgress");
						posInDialogue++;
					}
				}
				if (posInDialogue == 5) {
				//Debug.Log ("Got in here for somereason");
					uiMissionText.SetActive (true);
					uiQuestOne.SetActive (true);
					uiMissionBox.SetActive (true);
					tutorialText.SetActive (false);
					tutorialBox.SetActive (false);
					acceptQuest = true;
				}
				//If youre not in range or los or on a quest turn off textboxes
			} else {
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
			//Debug.Log ("Not In LOS");

		}
	}
	IEnumerator waitForFirstDialogueTrigger (float x){
		yield return new WaitForSeconds (x);
		firstDialogueTrigger = true;
		posInDialogue = 0;
	}
		

	IEnumerator spellItOut(){
		foreach (char letter in narrText[posInDialogue].ToCharArray()) {
			if(Input.GetKeyDown("e")){
				break;
			}
			tutText.text += letter;
			yield return new WaitForSeconds (letterPause);
		}
		tutText.text = "";
		tutText.text = narrText [posInDialogue];
		if (!tooltipStamCom) {
			narrTextTrigger [posInDialogue + 1] = true;
		}


	}



	void fillNarrativeString(){
		narrTextTrigger [0] = true;
		narrText [0] = "Hey, my lil' Krakenling, it would be very helpful if you were to hatch sometime soon. [E]";
		narrText [1] = "Look... we don't have all day, we have important work to attend to and this container is getting cramped and stuffy. Shake a tentacle and break out of that prison of yours. [E]";
		narrText [2] = "Oh thank goodness you are relatively intelligent. My name is Bork the Delightful, now come yonder and so I can see you. [E]";
		narrText [3] = "Bork: My goodness you are interesting looking. Regardless of your appearance, we do not have much time to chat. Please get me out of here, those rude red eyes will back soon. Do so and you can help me save the neighborhood. [E]";
		narrText [4] = "Bork: I suggest finding a box, picking it up [Hold LMB], and tossing it at this sinister glass [While holding LMB, RMB]. [E]";
		//narrTextTrigger [4] = false;


		//This shit is tooltip stuff
		narrText [100] = "Bork: Oh by the way, when you grab something you'll probably get tired and lose stamina, 'cause youre a weak infant. How fascinatingly bland your species is. [E]";
	}
	//Pos 3 = first quest - break bork out.
	void triggerNarrText(){
		narrTextTrigger [posInDialogue+1] = true;
	}

	//Do break glass scenario, if break glass increment the dialogue update the dialogue text to the next one, and print it
	// out again.




}
